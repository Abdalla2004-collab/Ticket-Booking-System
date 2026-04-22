using LMS.Models;

namespace LMS;

public partial class OrganiserDashboard : Form
{
    public OrganiserDashboard()
    {
        InitializeComponent();
        ThemeManager.ApplyTheme(this);
        this.Load += OrganiserDashboard_Load;
    }



    private void OrganiserDashboard_Load(object sender, EventArgs e)
    {
        if (DesignMode) return;
        labelWelcome.Text = "Welcome, " + GlobalManager.UserName;
        loadMyevents();
        loadNotifications();
        

        ThemeManager.ApplyTheme(this);
    }

    private void loadMyevents()
    {
        var organiser = (Organiser)GlobalManager.CurrentUser;
        var events = organiser.getEvents();

        dataGridViewEvents.DataSource = events;

        dataGridViewEvents.Columns["eventId"].Visible = false;
        dataGridViewEvents.Columns["venueId"].Visible = false;
        dataGridViewEvents.Columns["organiserId"].Visible = false;

        dataGridViewEvents.Columns["title"].HeaderText = "Event Name";
        dataGridViewEvents.Columns["category"].HeaderText = "Category";
        dataGridViewEvents.Columns["eventDate"].HeaderText = "Date";
        dataGridViewEvents.Columns["eventTime"].HeaderText = "Time";
        dataGridViewEvents.Columns["totalTickets"].HeaderText = "Tickets";
        dataGridViewEvents.Columns["price"].HeaderText = "Price";
        dataGridViewEvents.Columns["status"].HeaderText = "Status";
        dataGridViewEvents.Columns["venueName"].HeaderText = "Venue";
        dataGridViewEvents.Columns["availableTickets"].HeaderText = "Available";

    }
    
    private void loadNotifications()
    {
        var notifications = GlobalManager.getUnreadNotifications();

        if (notifications.Count > 0)
        {
            string combined = string.Join("\n", 
                notifications.ConvertAll(n => $"• {n.message}"));
            labelNotificationText.Text = combined;
            panelNotifications.Visible = true;
        }
        else
        {
            panelNotifications.Visible = false;
        }
    }

    private void buttonDismissNotifications_Click(object sender, EventArgs e)
    {
        var organiser = (Organiser)GlobalManager.CurrentUser;
        organiser.markNotificationsRead();
        panelNotifications.Visible = false;
    }

    private void button3_Click(object sender, EventArgs e)
    {
        GlobalManager.clearCurrentUser();
        this.Hide();
        var loginForm = new LoginForm();
        loginForm.Show();

    }

    private void button2_Click(object sender, EventArgs e)
    {

        var addEvents = new AddEvents();
        addEvents.Show();
        this.Hide();

    }
    

    private void buttonEditEvent_Click(object sender, EventArgs e)
    {
        if (dataGridViewEvents.SelectedRows.Count == 0)
        {
            MessageBox.Show("Please select an event to edit.");
            return;
        }

        int eventId = Convert.ToInt32(
            dataGridViewEvents.SelectedRows[0].Cells["eventId"].Value);

        var editForm = new EditEvent(eventId);
        editForm.ShowDialog();
        loadMyevents();

    }

    private void BtnStats_Click(object? sender, EventArgs e)
    {
        if (dataGridViewEvents.SelectedRows.Count == 0)
        {
            MessageBox.Show("Please select an event to view stats.");
            return;
        }

        int eventId = Convert.ToInt32(dataGridViewEvents.SelectedRows[0].Cells["eventId"].Value);
        string title = dataGridViewEvents.SelectedRows[0].Cells["title"].Value.ToString();
        string status = dataGridViewEvents.SelectedRows[0].Cells["status"].Value.ToString();

        int ticketsSold = 0;
        decimal moneyMade = 0m;

        using (var connection = GlobalManager.GetConnection())
        {
            connection.Open();
            string query = "SELECT SUM(quantity) as t, SUM(totalPrice) as m FROM bookings WHERE eventId = @eventId AND status = 'Confirmed'";
            using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@eventId", eventId);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ticketsSold = reader["t"] != DBNull.Value ? Convert.ToInt32(reader["t"]) : 0;
                        moneyMade = reader["m"] != DBNull.Value ? Convert.ToDecimal(reader["m"]) : 0m;
                    }
                }
            }
        }
        
        MessageBox.Show($"Event: {title}\nStatus: {status}\n\nTickets Sold: {ticketsSold}\nTotal Revenue: £{moneyMade:F2}", "Event Analytics", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void BtnCancelEvent_Click(object? sender, EventArgs e)
    {
        if (dataGridViewEvents.SelectedRows.Count == 0)
        {
            MessageBox.Show("Please select an event to cancel.");
            return;
        }

        int eventId = Convert.ToInt32(dataGridViewEvents.SelectedRows[0].Cells["eventId"].Value);
        string status = dataGridViewEvents.SelectedRows[0].Cells["status"].Value.ToString();

        if (status == "Rejected")
        {
            MessageBox.Show("This event is already cancelled.");
            return;
        }

        if (MessageBox.Show("Are you sure you want to cancel this event? All buyers will be notified.", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        {
            var org = (Organiser)GlobalManager.CurrentUser;
            org.cancelEvent(eventId);
            loadMyevents();
        }
    }
}