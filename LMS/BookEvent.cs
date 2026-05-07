namespace LMS;
using LMS.Models;

public partial class BookEvent : Form
{
    private readonly int _eventId;
    private readonly string _eventTitle;
    private readonly decimal _pricePerTicket;
    private readonly string _eventDate;
    private readonly string _eventTime;
    private readonly string _venueName;
    private readonly string _venueLocation;
    private int _discountPercentage = 0;

    public BookEvent(int eventId, string title, decimal price, int available, string date, string time, string venue, string location)
    {
        InitializeComponent();
        ThemeManager.ApplyLargeTheme(this);
        
        _eventId = eventId;
        _eventTitle = title;
        _pricePerTicket = price;
        _eventDate = date;
        _eventTime = time;
        _venueName = venue;
        _venueLocation = location;
        
        label1.Text = title;
        label2.Text = $"Venue: {venue}";
        label3.Text = $"Date: {date} @ {time}";
        label4.Text = $"Price: £{price:F2}";
        numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
        
        numericUpDown1.Minimum = 1;
        numericUpDown1.Maximum = available;
        numericUpDown1.Value = 1;
        
        updateTotal();
    }


    private void updateTotal()
    {
        try
        {
            int qty = (int)numericUpDown1.Value;
            decimal subtotal = qty * _pricePerTicket;
            decimal discount = subtotal * (_discountPercentage / 100m);
            decimal total = subtotal - discount;
            
            if (_discountPercentage > 0)
            {
                labelSubtotal.Text = $"Subtotal: £{subtotal:F2}";
                labelDiscountAmount.Text = $"Discount (-{_discountPercentage}%): -£{discount:F2}";
                label4.Text = $"Total: £{total:F2}";
            }
            else
            {
                labelSubtotal.Text = "";
                labelDiscountAmount.Text = "";
                label4.Text = $"Total: £{total:F2}";
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message);
        }
    }
    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
    {
        updateTotal();
    }
    
    private void buttonApplyDiscount_Click(object sender, EventArgs e)
    {
        try
        {
            string code = textBoxDiscountCode.Text.Trim();
            
            if (string.IsNullOrWhiteSpace(code))
            {
                labelDiscountStatus.ForeColor = System.Drawing.Color.Red;
                labelDiscountStatus.Text = "Please enter a discount code.";
                return;
            }

            var customer = (Customer)GlobalManager.CurrentUser;
            var result = customer.validateDiscount(code);

            if (result.valid)
            {
                _discountPercentage = result.percentage;
                labelDiscountStatus.ForeColor = System.Drawing.Color.Green;
                labelDiscountStatus.Text = $"{result.percentage}% discount applied!";
                textBoxDiscountCode.Enabled = false;
                buttonApplyDiscount.Enabled = false;
                updateTotal();
            }
            else
            {
                _discountPercentage = 0;
                labelDiscountStatus.ForeColor = System.Drawing.Color.Red;
                labelDiscountStatus.Text = "Invalid or expired discount code.";
                updateTotal();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message);
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            int quantity = (int)numericUpDown1.Value;

            var customer = (Customer)GlobalManager.CurrentUser;
            var result = customer.bookEvent(_eventId, quantity, _pricePerTicket, _discountPercentage);

            MessageBox.Show(result.message);

            if (result.success)
            {
                GlobalManager.sendNotification(GlobalManager.UserId, 
                    $"Booking confirmed for '{_eventTitle}'.");
                customer.useDiscount(textBoxDiscountCode.Text.Trim());

                int qty = (int)numericUpDown1.Value;
                decimal subtotal = qty * _pricePerTicket;
                decimal total = subtotal * (1 - _discountPercentage / 100m);

                string msg = "Booking successful! A digital ticket has been sent to your email.\n\nWould you like to print a copy for your records?";
                if (MessageBox.Show(msg, "Print Ticket", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    GlobalManager.PrintTicket(_eventTitle, _eventDate, _eventTime, qty, total, _venueName, _venueLocation);
                }

                this.Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message);
        }
    }

    private void button3_Click_1(object sender, EventArgs e)
    {
        this.Close();
    }
}