namespace LMS.Models;

public class Customer : User
{
    public Customer()
    {
        role = "Customer";
        CreatedAt = DateTime.Now;
    }
    
    public override Form getDashboard()
    {
        return new CustomerDashboard();
    }
}