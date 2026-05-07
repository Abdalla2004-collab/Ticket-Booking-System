namespace LMS.Models;
using MySql.Data.MySqlClient;

public class Customer : User
{
    public Customer()
    {
        role = "Customer";
        CreatedAt = DateTime.Now;
    }

    public override Form getDashboard()
    {
        return new CustomerDashboard();
    }
    
    public List<Events> getApprovedEvents(string searchTitle = "", string filterCategory = "")
    {
        var events = new List<Events>();

        using (MySqlConnection connection = GlobalManager.GetConnection())
        {
            connection.Open();

            string query = @"SELECT e.eventId, e.title, e.category, e.eventDate, e.eventTime, e.durationMinutes, e.price, e.status,
                            v.name as venueName, v.address as venueAddress,
                            e.totalTickets - COALESCE((SELECT SUM(b.quantity) FROM bookings b Where b.eventId = e.eventId
                            AND b.status = 'Confirmed'), 0) as availableTickets FROM events e
                            JOIN venues v on e.venueId = v.venueId 
                            WHERE e.status = 'Approved' AND e.eventDate>= CURRENT_DATE()
                            AND (@title = '' OR e.title LIKE @titleSearch)
                            AND (@category = '' OR e.category = @category)
                            ORDER BY e.eventDate ASC";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@title", searchTitle);
                command.Parameters.AddWithValue("@titleSearch", "%" + searchTitle + "%");
                command.Parameters.AddWithValue("@category", filterCategory);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        events.Add(new Events
                        {
                            eventId = (int)reader["eventId"],
                            title = reader["title"].ToString(),
                            category = reader["category"].ToString(),
                            eventDate = Convert.ToDateTime(reader["eventDate"]),
                            eventTime = TimeSpan.Parse(reader["eventTime"].ToString()),
                            durationMinutes = Convert.ToInt32(reader["durationMinutes"]),
                            price = Convert.ToDecimal(reader["price"]),
                            status = reader["status"].ToString(),
                            venueName = reader["venueName"].ToString(),
                            availableTickets = Convert.ToInt32(reader["availableTickets"]),
                            venueAddress = reader["venueAddress"].ToString() ?? ""
                        });
                    }
                }
            }

            return events;
        }
    }
    
    public (bool success, string message) bookEvent(int eventId, int quantity, decimal pricePerTicket, int discountPercentage = 0)
    {
        using (MySqlConnection connection = GlobalManager.GetConnection())
        {
            connection.Open();

            string checkQuery = @"SELECT e.totalTickets - COALESCE((SELECT SUM(b.quantity) From bookings b
                                  WHERE b.eventId = @eventId AND b.status = 'Confirmed'),0) AS availableTickets
                                  from events e where e.eventId = @eventId";

            int available = 0;

            using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection))
            {
                checkCmd.Parameters.AddWithValue("@eventId", eventId);
                var result = checkCmd.ExecuteScalar();
                available = Convert.ToInt32(result);
            }

            if (available < quantity)
            {
                return (false, $"Only {available} tickets are available for this event.");
            }
            
            decimal subtotal = quantity * pricePerTicket;
            decimal totalPrice = subtotal * (1 - discountPercentage / 100m);

            string insertQuery = @"INSERT INTO bookings (customerId, eventId, quantity, totalPrice)
                                   VALUES (@customerId, @eventId, @quantity, @totalPrice)";

            using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection))
            {
                insertCmd.Parameters.AddWithValue("@customerId", id);
                insertCmd.Parameters.AddWithValue("@eventId", eventId);
                insertCmd.Parameters.AddWithValue("@quantity", quantity);
                insertCmd.Parameters.AddWithValue("@totalPrice", totalPrice);
                
                int rows = insertCmd.ExecuteNonQuery();
                return rows > 0 ? (true, "Booking confirmed!") : (false, "Booking failed, please try again!!");
            }
        }
    }

    public List<Booking> getMyBookings()
    {
        var bookings = new List<Booking>();

        using (MySqlConnection connection = GlobalManager.GetConnection())
        {  
            connection.Open();

            string query = @"select b.bookingId, b.eventId, b.quantity, b.totalPrice, b.bookingDate, b.status,
                                e.title as eventTitle, e.eventDate, e.eventTime, v.name as venueName, v.address as venueAddress
                                from bookings b
                                JOIN events e on b.eventId = e.eventId
                                JOIN venues v on e.venueId = v.venueId
                                where b.customerId = @customerId
                                order by b.bookingDate DESC";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("customerId", id);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bookings.Add(new Booking
                        {
                            bookingId = (int)reader["bookingId"],
                            eventId = (int)reader["eventId"],
                            quantity = (int)reader["quantity"],
                            totalPrice = (decimal)reader["totalPrice"],
                            bookingDate =  Convert.ToDateTime(reader["bookingDate"]),
                            status = reader["status"].ToString(),
                            eventTitle = reader["eventTitle"].ToString(),
                            venueName = reader["venueName"].ToString(),
                            venueAddress = reader["venueAddress"].ToString(),
                            eventDate = Convert.ToDateTime(reader["eventDate"]),
                            eventTime = TimeSpan.Parse(reader["eventTime"].ToString()),
                        });
                    }
                }
            }
            return bookings;
        }
    }

    public bool cancelBooking(int bookingId)
    {
        using (MySqlConnection connection = GlobalManager.GetConnection())
        {
            connection.Open();

            string query = @"UPDATE bookings SET status = 'Cancelled'
                            WHERE bookingId = @bookingId AND customerId = @customerId";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("bookingId", bookingId);
                command.Parameters.AddWithValue("customerId", id);
                
                int rows = command.ExecuteNonQuery();
                return rows > 0;
            }
        }
    }
        
    public (bool valid, int percentage) validateDiscount(string code)
    {
        using (MySqlConnection connection = GlobalManager.GetConnection())
        {
            connection.Open();
            string query = @"SELECT percentage FROM discounts WHERE code = @code AND isActive = 1";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@code", code.ToUpper());
                var result = command.ExecuteScalar();
                
                if (result != null)
                {
                    return (true, Convert.ToInt32(result));
                }
                return (false, 0);
            }
        }
    }
    public bool useDiscount(string code)
    {
        using (MySqlConnection connection = GlobalManager.GetConnection())
        {
            connection.Open();
            string query = @"UPDATE discounts SET isActive = NOT isActive WHERE code = @code";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@code", code.ToUpper());
                return command.ExecuteNonQuery() > 0;
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