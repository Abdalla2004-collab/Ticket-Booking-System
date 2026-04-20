namespace LMS.Models;

public class Discount
{
    public int      discountId { get; set; }
    public string   code       { get; set; } = "";
    public int      percentage { get; set; }
    public bool     isActive   { get; set; } = true;
    public DateTime createdAt  { get; set; }
}
