using Org.BouncyCastle.Pqc.Crypto.Lms;

namespace LMS;
using LMS.Models;

public partial class MyBookings : Form
{
    public event Action? BookingsUpdated;

    public MyBookings()
    {
        InitializeComponent();
        ThemeManager.ApplyTheme(this);
        this.Load += MyBookings_Load;

    }

    private void MyBookings_Load(object sender, EventArgs e)
    {
        loadBookings();
    }

    private void loadBookings()
    {
        var customer = (Customer)GlobalManager.CurrentUser;
        var bookings = customer.getMyBookings();
        
        dataGridView1.DataSource = bookings;
        
        dataGridView1.Columns["bookingId"].Visible = false;
        dataGridView1.Columns["customerId"].Visible = false;
        dataGridView1.Columns["eventId"].Visible = false;

        dataGridView1.Columns["eventTitle"].HeaderText = "Event";
        dataGridView1.Columns["venueName"].HeaderText = "Venue";
        dataGridView1.Columns["eventDate"].HeaderText = "Date";
        dataGridView1.Columns["eventTime"].HeaderText = "Time";
        dataGridView1.Columns["quantity"].HeaderText = "Tickets";
        dataGridView1.Columns["totalPrice"].HeaderText = "Total Paid (£)";
        dataGridView1.Columns["bookingDate"].HeaderText = "Booked On";
        dataGridView1.Columns["status"].HeaderText = "Status";
    }

    private void button1_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        if (dataGridView1.SelectedRows.Count == 0)
        {
            MessageBox.Show("Please select a booking to cancel.");
            return;
        }

        string currentStatus = dataGridView1.SelectedRows[0].Cells["status"].Value.ToString();
        DateTime eventDate = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells["eventDate"].Value);
        int bookingId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["bookingId"].Value);
        
        if (currentStatus == "Cancelled")
        {
            MessageBox.Show("This booking is already cancelled.");
            return;
        }

        if (eventDate < DateTime.Today)
        {
            MessageBox.Show("You cannot cancel a booking for an event that has already taken place.");
        }
        
        DialogResult confirm = MessageBox.Show("Are you sure you want to cancel this booking?",
                                                    "Confirm Cancellation", 
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        
        if (confirm != DialogResult.Yes) return;
        
        var customer = (Customer)GlobalManager.CurrentUser;
        var result = customer.cancelBooking(bookingId);

        if (result)
        {
            string eventTitle = dataGridView1.SelectedRows[0].Cells["eventTitle"].Value.ToString();
            
            GlobalManager.sendNotification(GlobalManager.UserId, 
                $"Your booking for '{eventTitle}' has been cancelled.");
            
            MessageBox.Show("Booking cancelled.");
            loadBookings();
            BookingsUpdated?.Invoke();
        }
        else
        {
            MessageBox.Show("Failed to cancel booking. Please try again.");
        }
    }
}