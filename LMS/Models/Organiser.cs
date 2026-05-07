using MySql.Data.MySqlClient;

namespace LMS.Models;

public class Organiser : User
{
    public Organiser()
    {
        role = "Organiser";
    }

    public override Form getDashboard()
    {
        return new OrganiserDashboard();
    }

    public List<Events> getEvents()
    {
        var events = new List<Events>();

        using (MySqlConnection connection = GlobalManager.GetConnection())
        {
            connection.Open();

            string query = @"SELECT e.eventId, e.title, e.category, e.eventDate,
                                    e.eventTime, e.durationMinutes, e.totalTickets, e.price, e.status,
                                    v.name AS venueName, v.address AS venueAddress,
                                    e.totalTickets - COALESCE((SELECT SUM(b.quantity) FROM bookings b WHERE b.eventId = e.eventId AND b.status = 'Confirmed'), 0) as availableTickets
                             FROM events e
                             JOIN venues v ON e.venueId = v.venueId
                             WHERE e.organiserId = @organiserId
                             ORDER BY CASE WHEN e.status = 'Approved' THEN 0 WHEN e.status = 'Pending' THEN 1 ELSE 2 END, e.eventDate ASC";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@organiserId", id);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        events.Add(new Events
                        {
                            eventId      = Convert.ToInt32(reader["eventId"]),
                            title        = reader["title"].ToString()!,
                            category     = reader["category"].ToString()!,
                            eventDate    = Convert.ToDateTime(reader["eventDate"]),
                            eventTime    = TimeSpan.Parse(reader["eventTime"].ToString()!),
                            durationMinutes = Convert.ToInt32(reader["durationMinutes"]),
                            totalTickets = Convert.ToInt32(reader["totalTickets"]),
                            price        = Convert.ToDecimal(reader["price"]),
                            status       = reader["status"].ToString()!,
                            venueName    = reader["venueName"].ToString()!,
                            availableTickets = Convert.ToInt32(reader["availableTickets"]),
                            venueAddress = reader["venueAddress"].ToString() ?? ""
                        });
                    }
                }
            }
        }

        return events;
    }
    
    public void cancelEvent(int eventId)
    {
        using (MySqlConnection connection = GlobalManager.GetConnection())
        {
            connection.Open();

            string getCustomersQuery = "SELECT DISTINCT customerId FROM bookings WHERE eventId = @eventId AND status = 'Confirmed'";            var customersToNotify = new List<int>();
            using (var cmd = new MySqlCommand(getCustomersQuery, connection))
            {
                cmd.Parameters.AddWithValue("@eventId", eventId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customersToNotify.Add(Convert.ToInt32(reader["customerId"]));
                    }
                }
            }

            string title = "";
            string getTitleQuery = "SELECT title FROM events WHERE eventId = @eventId";
            using (var cmd = new MySqlCommand(getTitleQuery, connection))
            {
                cmd.Parameters.AddWithValue("@eventId", eventId);
                var res = cmd.ExecuteScalar();
                if (res != null) title = res.ToString()!;
            }

            foreach (var cid in customersToNotify)
            {
                GlobalManager.sendNotification(cid, $"The event '{title}' has been cancelled by the organiser\". Please accept our apologies, a refund is processing.");
            }

            string updateBookings = "UPDATE bookings SET status = 'Cancelled' WHERE eventId = @eventId";
            using (var cmd = new MySqlCommand(updateBookings, connection))
            {
                cmd.Parameters.AddWithValue("@eventId", eventId);
                cmd.ExecuteNonQuery();
            }

            string updateEvent = "UPDATE events SET status = 'Rejected' WHERE eventId = @eventId";
            using (var cmd = new MySqlCommand(updateEvent, connection))
            {
                cmd.Parameters.AddWithValue("@eventId", eventId);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public (int ticketsSold, decimal moneyMade) getEventStats(int eventId)
    {
        int ticketsSold = 0;
        decimal moneyMade = 0m;

        using (var connection = GlobalManager.GetConnection())
        {
            connection.Open();
            string query = "" +
                           "SELECT SUM(b.quantity) as t, SUM(b.totalPrice) as m " +
                           "FROM bookings b " +
                           "JOIN users u ON b.customerId = u.id " +
                           "WHERE b.eventId = @eventId AND b.status = 'Confirmed' AND u.isActive = 1";
            using (var cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@eventId", eventId);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ticketsSold = reader["t"] != DBNull.Value ? Convert.ToInt32(reader["t"]) : 0;
                        moneyMade = reader["m"] != DBNull.Value ? Convert.ToDecimal(reader["m"]) : 0m;
                    }
                }
            }
        }
        return (ticketsSold, moneyMade);
    }

    public List<(TimeSpan start, int dur)> getExistingEventsForVenue(int venueId, string date, int excludeEventId = -1)
    {
        var existingEvents = new List<(TimeSpan start, int dur)>();

        using (var connection = GlobalManager.GetConnection())
        {
            connection.Open();
            string query = "SELECT eventTime, durationMinutes FROM events WHERE venueId = @vId AND eventDate = @d AND status != 'Rejected'";
            if (excludeEventId != -1)
            {
                query += " AND eventId != @eId";
            }

            using (var cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@vId", venueId);
                cmd.Parameters.AddWithValue("@d", date);
                if (excludeEventId != -1)
                {
                    cmd.Parameters.AddWithValue("@eId", excludeEventId);
                }

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        existingEvents.Add((TimeSpan.Parse(reader["eventTime"].ToString()!), Convert.ToInt32(reader["durationMinutes"])));
                    }
                }
            }
        }
        return existingEvents;
    }

    public (bool success, string message) addEvent(string title, string category, string date, string time, int durationMinutes, int totalTickets, decimal price, int venueId, int organiserId)
    {
        try
        {
            using (MySqlConnection connection = GlobalManager.GetConnection())
            {
                connection.Open();

                string query = @"INSERT INTO events
                    (title, category, eventDate, eventTime, durationMinutes, totalTickets, price, venueId, organiserId)
                    VALUES (@title, @category, @date, @time, @durationMinutes, @tickets, @price, @venueId, @organiserId)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@category", category);
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@time", time);
                    command.Parameters.AddWithValue("@durationMinutes", durationMinutes);
                    command.Parameters.AddWithValue("@tickets", totalTickets);
                    command.Parameters.AddWithValue("@price", price);
                    command.Parameters.AddWithValue("@venueId", venueId);
                    command.Parameters.AddWithValue("@organiserId", organiserId);

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                        return (true, "Event added! Awaiting admin approval.");
                    else
                        return (false, "Failed to add event.");
                }
            }
        }
        catch (MySqlException ex) when (ex.Number == 1062)
        {
            return (false, "This venue already has an event at that date and time.");
        }
        catch (Exception ex)
        {
            return (false, "Error: " + ex.Message);
        }
    }

    public (bool success, string message) updateEvent(int eventId, string title, string category, int tickets, decimal price, int venueId, string date, string time, int durationMinutes, int organiserId)
    {
        try
        {
            using (MySqlConnection connection = GlobalManager.GetConnection())
            {
                connection.Open();

                string query = @"
                    UPDATE events 
                    SET title = @title, category = @category, totalTickets = @tickets, price = @price, 
                        venueId = @venueId, eventDate = @date, eventTime = @time, durationMinutes = @durationMinutes, status = 'Pending'
                    WHERE eventId = @eventId AND organiserId = @organiserId";
                
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@eventId", eventId);
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@category", category);
                    command.Parameters.AddWithValue("@tickets", tickets);
                    command.Parameters.AddWithValue("@price", price);
                    command.Parameters.AddWithValue("@venueId", venueId);
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@time", time);
                    command.Parameters.AddWithValue("@durationMinutes", durationMinutes);
                    command.Parameters.AddWithValue("@organiserId", organiserId);

                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                        return (true, "Event updated and resubmitted for admin approval.");
                    else
                        return (false, "Unable to update event. You may not have permission.");
                }
            }
        }
        catch (MySqlException ex) when (ex.Number == 1062)
        {
            return (false, "That venue already has an event at that date and time.");
        }
        catch (MySqlException ex)
        {
            return (false, ex.Message);
        }
    }

    public Events? getEventDetails(int eventId)
    {
        using (MySqlConnection connection = GlobalManager.GetConnection())
        {
            connection.Open();
            string Query = @"SELECT title, category, eventDate, eventTime, durationMinutes, totalTickets, price, 
                            VenueId FROM events WHERE eventId = @eventId";
            using (MySqlCommand command = new MySqlCommand(Query, connection))
            {   
                command.Parameters.AddWithValue("@eventId", eventId);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Events
                        {
                            title = reader["title"].ToString()!,
                            category = reader["category"].ToString()!,
                            eventDate = Convert.ToDateTime(reader["eventDate"]),
                            eventTime = TimeSpan.Parse(reader["eventTime"].ToString()!),
                            durationMinutes = Convert.ToInt32(reader["durationMinutes"]),
                            totalTickets = Convert.ToInt32(reader["totalTickets"]),
                            price = Convert.ToDecimal(reader["price"]),
                            venueId = Convert.ToInt32(reader["venueId"])
                        };
                    }
                }
            }
        }
        return null;
    }


    public void markNotificationsRead()
    {
        using (MySqlConnection connection = GlobalManager.GetConnection())
        {
            connection.Open();
            string query = @"UPDATE notifications SET isRead = 1 WHERE userId = @userId AND isRead = 0";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@userId", id);
                command.ExecuteNonQuery();
            }
        }
    }
}