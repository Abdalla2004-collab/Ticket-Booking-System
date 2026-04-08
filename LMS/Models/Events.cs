namespace LMS.Models;

public class Events
{
    public int      eventId          { get; set; }
    public string   title            { get; set; } = "";
    public string   category         { get; set; } = "";
    public DateTime eventDate        { get; set; }
    public TimeSpan eventTime        { get; set; }
    public int      totalTickets     { get; set; }
    public decimal  price            { get; set; }
    public string   status           { get; set; } = "Pending";
    public int      venueId          { get; set; }
    public string   venueName        { get; set; } = "";
    public int      organiserId      { get; set; }
    public int      availableTickets { get; set; }
}