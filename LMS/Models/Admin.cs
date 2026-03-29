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
            string query = @"SELECT e.eventId, e.title, e.category, e.eventDate, e.eventTime, e.totalTickets,
		                        e.price, e.status, v.name as venueName, u.fullname as organiserName
                                from events e
                                Join Venues v on e.venueId = v.venueId
                                join users u on u.id = e.organiserId
                                order by case when e.status = 'Pending' then 'Approved' else 'Rejected' end, status";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        events.Add(new Events
                        {
                            eventId      = Convert.ToInt32(reader["eventId"]),
                            title        = reader["title"].ToString(),
                            category     = reader["category"].ToString(),
                            eventDate    = Convert.ToDateTime(reader["eventDate"]),
                            eventTime    = TimeSpan.Parse(reader["eventTime"].ToString()),
                            totalTickets = Convert.ToInt32(reader["totalTickets"]),
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
    
}