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
}
