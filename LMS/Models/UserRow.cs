namespace LMS.Models;

public class UserRow
{
    public int    userId   { get; set; }
    public string fullname { get; set; } = "";
    public string email    { get; set; } = "";
    public string role     { get; set; } = "";
}