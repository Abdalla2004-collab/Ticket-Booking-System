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
        try
        {
            loadBookings();
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message);
        }
    }

    private void loadBookings()
    {
        try
        {
            var customer = (Customer)GlobalManager.CurrentUser;
            var allBookings = customer.getMyBookings();

            var activeBookings = allBookings.Where(b => b.status == "Confirmed" && b.eventDate >= DateTime.Today).ToList();
            var historyBookings = allBookings.Where(b => b.status == "Cancelled" || b.eventDate < DateTime.Today).ToList();
            
            dataGridViewActive.DataSource = activeBookings;
            dataGridViewHistory.DataSource = historyBookings;

            SetupGrid(dataGridViewActive);
            SetupGrid(dataGridViewHistory);
            
            bool isActiveTab = tabControlBookings.SelectedTab == tabPageActive;
            button2.Enabled = isActiveTab;
            buttonPrint.Enabled = isActiveTab;
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred loading bookings: " + ex.Message);
        }
    }

    private void SetupGrid(DataGridView dgv)
    {
        try
        {
            if (dgv.Columns.Count == 0) return;
            
            dgv.Columns["bookingId"].Visible = false;
            dgv.Columns["customerId"].Visible = false;
            dgv.Columns["eventId"].Visible = false;

            dgv.Columns["eventTitle"].HeaderText = "Event";
            dgv.Columns["venueName"].HeaderText = "Venue";
            dgv.Columns["venueAddress"].HeaderText = "Address";
            dgv.Columns["eventDate"].HeaderText = "Date";
            dgv.Columns["eventTime"].HeaderText = "Time";
            dgv.Columns["quantity"].HeaderText = "Tickets";
            dgv.Columns["totalPrice"].HeaderText = "Total Paid (£)";
            dgv.Columns["bookingDate"].HeaderText = "Booked On";
            dgv.Columns["status"].HeaderText = "Status";
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message);
        }
    }

    private void tabControlBookings_SelectedIndexChanged(object sender, EventArgs e)
    {
        bool isActiveTab = tabControlBookings.SelectedTab == tabPageActive;
        button2.Enabled = isActiveTab;
        buttonPrint.Enabled = isActiveTab;
    }

    private void buttonPrint_Click(object sender, EventArgs e)
    {
        try
        {
            if (dataGridViewActive.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an active booking to print.");
                return;
            }

            var booking = (Booking)dataGridViewActive.SelectedRows[0].DataBoundItem;
            GlobalManager.PrintTicket(
                booking.eventTitle, 
                booking.eventDate.ToString("yyyy-MM-dd"), 
                booking.eventTime.ToString(), 
                booking.quantity, 
                booking.totalPrice, 
                booking.venueName, 
                booking.venueAddress
            );
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        try
        {
            DataGridView targetGrid = dataGridViewActive;
            
            if (targetGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a booking to cancel.");
                return;
            }

            string currentStatus = targetGrid.SelectedRows[0].Cells["status"].Value.ToString();
            DateTime eventDate = Convert.ToDateTime(targetGrid.SelectedRows[0].Cells["eventDate"].Value);
            int bookingId = Convert.ToInt32(targetGrid.SelectedRows[0].Cells["bookingId"].Value);
            
            if (currentStatus == "Cancelled")
            {
                MessageBox.Show("This booking is already cancelled.");
                return;
            }

            if (eventDate < DateTime.Today)
            {
                MessageBox.Show("You cannot cancel a booking for an event that has already taken place.");
                return;
            }
            
            DialogResult confirm = MessageBox.Show("Are you sure you want to cancel this booking?",
                                                        "Confirm Cancellation", 
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (confirm != DialogResult.Yes) return;
            
            var customer = (Customer)GlobalManager.CurrentUser;
            var result = customer.cancelBooking(bookingId);

            if (result)
            {
                string eventTitle = targetGrid.SelectedRows[0].Cells["eventTitle"].Value.ToString();
                
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
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message);
        }
    }
}