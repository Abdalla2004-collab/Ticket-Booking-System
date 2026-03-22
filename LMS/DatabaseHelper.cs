using dotenv.net;

namespace LMS;

public static class DatabaseHelper
{
    private static bool _loaded = false;

    public static string ConnectionString
    {
        get
        {
            if (!_loaded)
            {
                DotEnv.Load();
                _loaded = true;
            }

            return $"server={Environment.GetEnvironmentVariable("DB_SERVER")};" +
                   $"database={Environment.GetEnvironmentVariable("DB_NAME")};" +
                   $"uid={Environment.GetEnvironmentVariable("DB_USER")};" +
                   $"pwd={Environment.GetEnvironmentVariable("DB_PASSWORD")}";
        }
    }
}