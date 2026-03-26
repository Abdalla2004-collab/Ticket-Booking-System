namespace LMS.Models;

public abstract class User
{
    public int id { get; set; }
    public string fullname { get; set; } = "";
    public string email { get; set; } = "";
    public string role { get; set; } = "";
    public DateTime CreatedAt { get; set; }

    public abstract Form getDashboard();
}