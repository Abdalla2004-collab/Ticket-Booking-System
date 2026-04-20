using System.Diagnostics;
using dotenv.net;
using LMS.Models;
using MySql.Data.MySqlClient;
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
            System.Diagnostics.Debug.WriteLine($"Failed to send notification: {ex.Message}");
        }
    }
    
}
