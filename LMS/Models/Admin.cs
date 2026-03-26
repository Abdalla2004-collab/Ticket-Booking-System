namespace LMS.Models;

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
}