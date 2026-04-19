namespace LMS;
using LMS.Models;

public partial class BookEvent : Form
{
    private readonly int _eventId;
    private readonly decimal _pricePerTicket;
    public event Action? BookingCompleted;
    public BookEvent(int eventId, string title, decimal price, int available)
    {
        InitializeComponent();
        ThemeManager.ApplyTheme(this);
        
        _eventId = eventId;
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
        decimal total = qty * _pricePerTicket;
        label4.Text = $"Total: £{total:F2}";
    }
    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
    {
        updateTotal();
    }

    //book an event
    private void button1_Click(object sender, EventArgs e)
    {
        int quantity = (int)numericUpDown1.Value;

        var customer = (Customer)GlobalManager.CurrentUser;
        var result = customer.bookEvent(_eventId, quantity, _pricePerTicket);

        MessageBox.Show(result.message);

        if (result.success)
        {
            BookingCompleted?.Invoke();
            this.Close();
        }
    }

    private void button3_Click_1(object sender, EventArgs e)
    {
        this.Close();
    }
}