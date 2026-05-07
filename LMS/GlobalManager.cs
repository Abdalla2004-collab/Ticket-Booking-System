using System.Diagnostics;
using dotenv.net;
using LMS.Models;
using MySql.Data.MySqlClient;
using BCrypt.Net;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
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
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
        {
            MessageBox.Show("Name and Email cannot be empty.");
            return false;
        }
        try
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                
                string checkQuery = "SELECT COUNT(*) FROM users WHERE email = @email AND id != @userId";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@email", email);
                    checkCmd.Parameters.AddWithValue("@userId", UserId);
                    if (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0)
                    {
                        return false;
                    }
                }

                string query = !string.IsNullOrEmpty(password)
                    ? "UPDATE users SET fullname = @name, email = @email, password = @password WHERE id = @userId"
                    : "UPDATE users SET fullname = @name, email = @email WHERE id = @userId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@userId", UserId);
                    if (!string.IsNullOrEmpty(password))
                    {
                        command.Parameters.AddWithValue("@password", BCrypt.Net.BCrypt.HashPassword(password));
                    }

                    command.ExecuteNonQuery();
                    ReloadCurrentUser();
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Profile update failed: " + ex.Message);
        }
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

    public static void PrintTicket(string title, string date, string time, int qty, decimal total, string venue, string location)
    {
        PrintDocument pd = new PrintDocument();
        pd.DocumentName = $"Ticket_{title.Replace(" ", "_")}_{date}";
        
        pd.PrintPage += (sender, e) =>
        {
            Graphics g = e.Graphics!;
            Font titleFont = new Font("Segoe UI", 24, FontStyle.Bold);
            Font bodyFont = new Font("Segoe UI", 14);
            Font smallFont = new Font("Segoe UI", 10);

            float y = 40;
            g.DrawString("EVENT TICKET", titleFont, Brushes.Black, 40, y);
            y += 60;
            g.DrawLine(Pens.Black, 40, y, 500, y);
            y += 20;

            g.DrawString($"Event: {title}", bodyFont, Brushes.Black, 40, y);
            y += 40;
            g.DrawString($"Venue: {venue}", bodyFont, Brushes.Black, 40, y);
            y += 40;
            g.DrawString($"Location: {location}", bodyFont, Brushes.Black, 40, y);
            y += 40;
            g.DrawString($"Date: {date}", bodyFont, Brushes.Black, 40, y);
            y += 40;
            g.DrawString($"Time: {time}", bodyFont, Brushes.Black, 40, y);
            y += 40;
            g.DrawString($"Quantity: {qty} ticket(s)", bodyFont, Brushes.Black, 40, y);
            y += 40;
            g.DrawString($"Total Paid: £{total:F2}", bodyFont, Brushes.Black, 40, y);
            
            // Draw Fake QR Code
            float qrX = 550;
            float qrY = 40;
            float blockSize = 10;
            Random rnd = new Random(title.GetHashCode() + date.GetHashCode());
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    if (rnd.Next(2) == 0)
                        g.FillRectangle(Brushes.Black, qrX + (col * blockSize), qrY + (row * blockSize), blockSize, blockSize);
                }
            }
            g.DrawRectangle(Pens.Black, qrX, qrY, 100, 100);

            y += 60;

            g.DrawLine(Pens.Black, 40, y, 500, y);
            y += 20;
            g.DrawString("Please present this ticket at the venue entrance.", smallFont, Brushes.Gray, 40, y);
            y += 20;
            g.DrawString($"Generated on: {DateTime.Now:f}", smallFont, Brushes.Gray, 40, y);
        };

        PrintDialog pdialog = new PrintDialog();
        pdialog.Document = pd;
        if (pdialog.ShowDialog() == DialogResult.OK)
        {
            pd.Print();
        }
    }
}
