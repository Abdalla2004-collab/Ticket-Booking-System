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
                                    v.name AS venueName,
                                    e.totalTickets - COALESCE((SELECT SUM(b.quantity) FROM bookings b WHERE b.eventId = e.eventId AND b.status = 'Confirmed'), 0) as availableTickets
                             FROM events e
                             JOIN venues v ON e.venueId = v.venueId
                             WHERE e.organiserId = @organiserId
                             ORDER BY e.eventDate ASC";

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
                            availableTickets = Convert.ToInt32(reader["availableTickets"])
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