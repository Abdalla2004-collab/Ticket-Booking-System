namespace LMS.Models;
using MySql.Data.MySqlClient;

public class Admin : User
{
    public Admin()
    {
        CreatedAt = DateTime.UtcNow;
        role = "Admin";
    }

    public override Form getDashboard()
    {
        return new AdminDashboard();
    }
    
    public List<UserRow> getAllUsers()
    {
        var users = new List<UserRow>();

        using (MySqlConnection connection = GlobalManager.GetConnection())
        {
            connection.Open();

            string query = @"SELECT id, fullname, email, role FROM users WHERE role != 'Admin'
                            ORDER BY role ASC, fullname ASC";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new UserRow
                        {
                            userId = Convert.ToInt32(reader["id"]),
                            fullname = reader["fullname"].ToString(),
                            email = reader["email"].ToString(),
                            role = reader["role"].ToString()
                        });
                    }
                }
            }
        }
        return users;
    }

    public bool DeleteUser(int userId)
    {
        using (MySqlConnection connection = GlobalManager.GetConnection())
        {
            connection.Open();
            string query = @"DELETE FROM users  WHERE id = @userId and role != 'Admin'";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@userId", userId);
                return command.ExecuteNonQuery() > 0;
            }
        }
    }
    
    public List<Events> getEvents()
    {
        var events = new List<Events>();
        using (MySqlConnection connection = GlobalManager.GetConnection())
        {
            connection.Open();
            string query = @"SELECT e.eventId, e.organiserId, e.title, e.category, e.eventDate, e.eventTime, e.durationMinutes, e.totalTickets,
                                (e.totalTickets - COALESCE((SELECT SUM(quantity) FROM bookings WHERE eventId = e.eventId AND status = 'Confirmed'), 0)) as availableTickets,
		                        e.price, e.status, v.name as venueName, u.fullname as organiserName
                                from events e
                                Join Venues v on e.venueId = v.venueId
                                join users u on u.id = e.organiserId
                                order by case when e.status = 'Pending' then 0 else 1 end, status";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
        events.Add(new Events
                        {
                            eventId      = Convert.ToInt32(reader["eventId"]),
                            organiserId  = Convert.ToInt32(reader["organiserId"]),
                            title        = reader["title"].ToString(),
                            category     = reader["category"].ToString(),
                            eventDate    = Convert.ToDateTime(reader["eventDate"]),
                            eventTime    = TimeSpan.Parse(reader["eventTime"].ToString()),
                            durationMinutes = Convert.ToInt32(reader["durationMinutes"]),
                            totalTickets = Convert.ToInt32(reader["totalTickets"]),
                            availableTickets = Convert.ToInt32(reader["availableTickets"]),
                            price        = Convert.ToDecimal(reader["price"]),
                            status       = reader["status"].ToString(),
                            venueName    = reader["venueName"].ToString()
                        });
                    }
                }
            }
        }
        return events;
    }

    public bool updateEventStatus(int eventId, string newStatus)
    {
        using (MySqlConnection connection = GlobalManager.GetConnection())
        {
            connection.Open();
            string query = @"UPDATE events SET status = @newStatus where eventId = @eventId";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@newStatus", newStatus);
                command.Parameters.AddWithValue("@eventId", eventId);
                return command.ExecuteNonQuery() > 0;
            }
        }
    }
        
    public List<Discount> getDiscounts()
    {
        var discounts = new List<Discount>();
        using (MySqlConnection connection = GlobalManager.GetConnection())
        {
            connection.Open();
            string query = @"SELECT discountId, code, percentage, isActive, createdAt
                             FROM discounts ORDER BY createdAt DESC";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        discounts.Add(new Discount
                        {
                            discountId = Convert.ToInt32(reader["discountId"]),
                            code       = reader["code"].ToString(),
                            percentage = Convert.ToInt32(reader["percentage"]),
                            isActive   = Convert.ToBoolean(reader["isActive"]),
                            createdAt  = Convert.ToDateTime(reader["createdAt"])
                        });
                    }
                }
            }
        }
        return discounts;
    }

    public (bool success, string message) createDiscount(string code, int percentage)
    {
    
        if (string.IsNullOrWhiteSpace(code))
        {
            return (false, "Discount code can not be empty.");
        }

        if (percentage < 1 || percentage > 100)
        {
            return (false, "Percentage must be between 1 and 100.");
        }

        try
        {
            using (MySqlConnection connection = GlobalManager.GetConnection())
            {
                connection.Open();
                string query = @"INSERT INTO discounts (code, percentage) VALUES (@code, @percentage)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@code", code.ToUpper());
                    command.Parameters.AddWithValue("@percentage", percentage);
                    command.ExecuteNonQuery();
                    return (true, "Discount code created successfully!");
                }
            }
        }
        catch (MySqlException ex) when (ex.Number == 1062)
        {
            return (false, "A discount code with that name already exists.");
        }
    }

    public bool toggleDiscount(int discountId)
    {
        using (MySqlConnection connection = GlobalManager.GetConnection())
        {
            connection.Open();
            string query = @"UPDATE discounts SET isActive = NOT isActive WHERE discountId = @discountId";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@discountId", discountId);
                return command.ExecuteNonQuery() > 0;
            }
        }
    }
    
}