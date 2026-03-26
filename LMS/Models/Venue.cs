namespace LMS.Models;

public class Venue
{
    public int venueId { get; set; }
    public string name { get; set; } = "";
    public string address { get; set; } = "";
    public int capacity { get; set; }
}