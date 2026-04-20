namespace LMS;
using LMS.Models;

public partial class BookEvent : Form
{
    private readonly int _eventId;
    private readonly string _eventTitle;
    private readonly decimal _pricePerTicket;
    private int _discountPercentage = 0;
    public BookEvent(int eventId, string title, decimal price, int available)
    {
        InitializeComponent();
        ThemeManager.ApplyTheme(this);
        
        _eventId = eventId;
        _eventTitle = title;
        _pricePerTicket = price;
        
        label1.Text = title;
        label2.Text = $"Tickets available: {available}";
        label3.Text = $"Price per ticket: £{price:F2}";
        numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
        
        numericUpDown1.Minimum = 1;
        numericUpDown1.Maximum = available;
        numericUpDown1.Value = 1;
        
        updateTotal();
    }


    private void updateTotal()
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
    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
    {
        updateTotal();
    }
    
    private void buttonApplyDiscount_Click(object sender, EventArgs e)
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

    private void button1_Click(object sender, EventArgs e)
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
            this.Close();
        }
    }

    private void button3_Click_1(object sender, EventArgs e)
    {
        this.Close();
    }
}