namespace LMS.Models;

public class Notification
{
    public int      notificationId { get; set; }
    public int      userId         { get; set; }
    public string   message        { get; set; } = "";
    public bool     isRead         { get; set; }
    public DateTime createdAt      { get; set; }
}
