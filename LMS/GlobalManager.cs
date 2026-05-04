using System.Diagnostics;
using dotenv.net;
using LMS.Models;
using MySql.Data.MySqlClient;
using BCrypt.Net;
namespace LMS;

public static class GlobalManager
{
    private static bool _envloaded = false;
    public static User? CurrentUser { get; private set; } = null;
    public static string connectionString
    {
        get
        {
            if (!_envloaded)
            {
                DotEnv.Load();
                _envloaded = true;
            }

            return $"server={Environment.GetEnvironmentVariable("DB_SERVER")};" +
                   $"database={Environment.GetEnvironmentVariable("DB_NAME")};" +
                   $"uid={Environment.GetEnvironmentVariable("DB_USER")};" +
                   $"pwd={Environment.GetEnvironmentVariable("DB_PASSWORD")}";
        }
        
    }

    public static MySqlConnection GetConnection()
    {
        return new MySqlConnection(connectionString);
    }
    public static void setCurrentUser(User user)
    {
        CurrentUser = user;
    }
    public static void clearCurrentUser()
    {
        CurrentUser = null;
    }
    public static bool IsLoggedIn  => CurrentUser != null;
    public static string UserName  => CurrentUser?.fullname ?? "";
    public static string UserRole  => CurrentUser?.role ?? "";
    public static int    UserId    => CurrentUser?.id ?? 0;
    public static User CreateUser(int id, string name, string email, string role)
    {
        User user = role switch
        {
            "Organiser" => new Organiser(),
            "Admin" => new Admin(),
            _ => new Customer()
        };

        user.id = id;
        user.fullname = name;
        user.email =  email;

        return user;
    }
    
    public static List<Notification> getUnreadNotifications()
    {
        var notifications = new List<Notification>();
        using (MySqlConnection connection = GlobalManager.GetConnection())
        {
            connection.Open();
            string query = @"SELECT notificationId, userId, message, isRead, createdAt
                             FROM notifications WHERE userId = @userId AND isRead = 0
                             ORDER BY createdAt DESC";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@userId", CurrentUser.id);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        notifications.Add(new Notification
                        {
                            notificationId = Convert.ToInt32(reader["notificationId"]),
                            userId         = Convert.ToInt32(reader["userId"]),
                            message        = reader["message"].ToString(),
                            isRead         = Convert.ToBoolean(reader["isRead"]),
                            createdAt      = Convert.ToDateTime(reader["createdAt"])
                        });
                    }
                }
            }
        }
        return notifications;
    }

    
    public static void sendNotification(int userId, string message)
    {
        try
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = @"INSERT INTO notifications (userId, message) VALUES (@userId, @message)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@message", message);
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to send notification: {ex.Message}");
        }
    }

    public static bool UpdateUserProfile(string name, string email, string password = "")
    {
        try
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                string query;
                if (!string.IsNullOrEmpty(password))
                {
                    query = "UPDATE users SET fullname = @name, email = @email, password = @password WHERE id = @userId";
                }
                else
                {
                    query = "UPDATE users SET fullname = @name, email = @email WHERE id = @userId";
                }

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@userId", UserId);
                    if (!string.IsNullOrEmpty(password))
                    {
                        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
                        command.Parameters.AddWithValue("@password", hashedPassword);
                    }

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        ReloadCurrentUser();
                        return true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to update profile: {ex.Message}");
        }
        return false;
    }

    public static void ReloadCurrentUser()
    {
        if (CurrentUser == null) return;

        using (MySqlConnection connection = GetConnection())
        {
            connection.Open();
            string query = "SELECT fullname, email, role FROM users WHERE id = @userId";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@userId", CurrentUser.id);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        CurrentUser.fullname = reader["fullname"].ToString();
                        CurrentUser.email = reader["email"].ToString();
                    }
                }
            }
        }
    }

    public static (bool success, User? user, string message) AuthenticateUser(string email, string password)
    {
        try
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();

                string query = "SELECT id, fullname, email, password, role FROM users WHERE email = @email AND isActive = 1";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@email", email);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedPassword = reader["password"].ToString();
                            if (BCrypt.Net.BCrypt.Verify(password, storedPassword))
                            {
                                string fullname = reader["fullname"].ToString();
                                string role = reader["role"].ToString();
                                int id = Convert.ToInt32(reader["id"]);
                            
                                var user = CreateUser(id, fullname, email, role);
                                return (true, user, "Welcome, " + fullname + "!");
                            }
                            return (false, null, "Invalid email or password.");
                        }
                        return (false, null, "Invalid email or password.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            return (false, null, "Error: " + ex.Message);
        }
    }

    public static bool EmailExists(string email)
    {
        using (MySqlConnection connection = GetConnection())
        {
            connection.Open();
            string query = "SELECT COUNT(*) FROM users WHERE email = @email";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@email", email);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }
    }

    public static (bool success, string message) RegisterUser(string name, string email, string password, string role)
    {
        try
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                
                string query = "INSERT INTO users (fullname, email, password, role) VALUES (@name, @email, @password, @role)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", hashedPassword);
                    command.Parameters.AddWithValue("@role", role);
                    
                    int result = command.ExecuteNonQuery();
                    return result > 0 ? (true, "Registration successful!") : (false, "Registration failed. Please try again.");
                }
            }
        }
        catch (Exception ex)
        {
            return (false, "Error: " + ex.Message);
        }
    }

    public static List<Venue> GetAvailableVenues()
    {
        var venues = new List<Venue>();
        using (MySqlConnection connection = GetConnection())
        {
            connection.Open();
            string query = "SELECT venueId, name, capacity FROM venues WHERE isAvailable = 1 ORDER BY name ASC";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    venues.Add(new Venue
                    {
                        venueId  = Convert.ToInt32(reader["venueId"]),
                        name     = reader["name"].ToString()!,
                        capacity = Convert.ToInt32(reader["capacity"])
                    });
                }
            }
        }
        return venues;
    }

    public static List<Venue> GetAllVenues()
    {
        var venues = new List<Venue>();
        using (MySqlConnection connection = GetConnection())
        {
            connection.Open();
            string query = "SELECT venueId, name, capacity FROM venues ORDER BY name ASC";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    venues.Add(new Venue
                    {
                        venueId = Convert.ToInt32(reader["venueId"]),
                        name    = reader["name"].ToString()!,
                        capacity = Convert.ToInt32(reader["capacity"])
                    });
                }
            }
        }
        return venues;
    }
}
