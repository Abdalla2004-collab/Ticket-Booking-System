namespace LMS.Models;

public class Booking
{
    public int bookingId { get; set; }
    public int customerId { get; set; }
    public int eventId { get; set; }
    public int quantity { get; set; }
    public decimal totalPrice { get; set; }
    public DateTime bookingDate { get; set; }
    public string status { get; set; } = "Confirmed";
    public string   eventTitle  { get; set; } = "";
    public string   venueName   { get; set; } = "";
    public DateTime eventDate   { get; set; }
    public TimeSpan eventTime   { get; set; }
}