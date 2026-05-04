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
    
    public (int totalUsers, int activeEvents, decimal totalRevenue, int totalTicketsSold) getAnalyticsStats()
    {
        int totalUsers = 0;
        int activeEvents = 0;
        decimal totalRevenue = 0m;
        int totalTicketsSold = 0;
        
        using (var connection = GlobalManager.GetConnection())
        {
            connection.Open();
            string statsQuery = @"
                SELECT 
                    (SELECT COUNT(*) FROM users WHERE isActive = 1) as UsersCount,
                    (SELECT COUNT(*) FROM events WHERE status = 'Approved') as EventsCount,
                    (SELECT COALESCE(SUM(b.totalPrice), 0) FROM bookings b JOIN users u ON b.customerId = u.id WHERE b.status = 'Confirmed' AND u.isActive = 1) as Revenue,
                    (SELECT COALESCE(SUM(b.quantity), 0) FROM bookings b JOIN users u ON b.customerId = u.id WHERE b.status = 'Confirmed' AND u.isActive = 1) as TicketsSold;
            ";
            
            using (var cmd = new MySqlCommand(statsQuery, connection))
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    totalUsers = Convert.ToInt32(reader["UsersCount"]);
                    activeEvents = Convert.ToInt32(reader["EventsCount"]);
                    totalRevenue = Convert.ToDecimal(reader["Revenue"]);
                    totalTicketsSold = Convert.ToInt32(reader["TicketsSold"]);
                }
            }
        }
        return (totalUsers, activeEvents, totalRevenue, totalTicketsSold);
    }
    
    public (bool success, string message) addVenue(string name, string address, int capacity)
    {
        try
        {
            using (MySqlConnection connection = GlobalManager.GetConnection())
            {
                connection.Open();
                string query = @"INSERT INTO Venues (name, address, capacity) values (@name, @address, @capacity)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@capacity", capacity);
                    
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return (true, "Successfully added Venues");
                    }
                    return (false, "Failed to add venue.");
                }
            }
        }
        catch (MySqlException ex)
        {
            return (false, ex.Message);
        }
    }

    public void rejectEventAndCancelBookings(int eventId, string title)
    {
        using (var connection = GlobalManager.GetConnection())
        {
            connection.Open();
            
            string getCustomersQuery = "SELECT DISTINCT customerId FROM bookings WHERE eventId = @eventId AND status = 'Confirmed'";
            var customersToNotify = new List<int>();
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

            foreach (var cid in customersToNotify)
            {
                GlobalManager.sendNotification(cid, $"The event '{title}' has been cancelled by an administrator. A refund is processing.");
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
    
    public List<UserRow> getAllUsers()
    {
        var users = new List<UserRow>();

        using (MySqlConnection connection = GlobalManager.GetConnection())
        {
            connection.Open();

            string query = @"SELECT id, fullname, email, role FROM users WHERE role != 'Admin' AND isActive = 1 
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
            string query = @"UPDATE users SET isActive = 0 WHERE id = @userId AND role != 'Admin'";

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

    public (bool success, string message) createAdmin(string fullname, string email, string password)
    {
        if (string.IsNullOrWhiteSpace(fullname) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            return (false, "All fields are required.");
        }

        try
        {
            using (MySqlConnection connection = GlobalManager.GetConnection())
            {
                connection.Open();
                
                string checkQuery = "SELECT COUNT(*) FROM users WHERE email = @email";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@email", email);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        return (false, "An account with this email already exists.");
                    }
                }

                string insertQuery = "INSERT INTO users (fullname, email, password, role) VALUES (@fullname, @email, @password, 'Admin')";
                using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection))
                {
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
                    insertCmd.Parameters.AddWithValue("@fullname", fullname);
                    insertCmd.Parameters.AddWithValue("@email", email);
                    insertCmd.Parameters.AddWithValue("@password", hashedPassword);
                    
                    int result = insertCmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return (true, "Admin account created successfully!");
                    }
                    return (false, "Failed to create admin account.");
                }
            }
        }
        catch (Exception ex)
        {
            return (false, "Database error: " + ex.Message);
        }
    }
}