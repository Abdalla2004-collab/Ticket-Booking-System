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
        try
        {
            if (DesignMode) return;
            labelWelcome.Text = "Welcome, " + GlobalManager.UserName;
            loadMyevents();
            loadNotifications();
            ThemeManager.ApplyTheme(this);
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message);
        }
    }

    private void loadMyevents()
    {
        try
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
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred loading events: " + ex.Message);
        }
    }
    
    private void loadNotifications()
    {
        try
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
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message);
        }
    }

    private void buttonDismissNotifications_Click(object sender, EventArgs e)
    {
        try
        {
            var organiser = (Organiser)GlobalManager.CurrentUser;
            organiser.markNotificationsRead();
            panelNotifications.Visible = false;
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message);
        }
    }

    private void buttonEditProfile_Click(object sender, EventArgs e)
    {
        try
        {
            EditProfileForm editProfileForm = new EditProfileForm();
            if (editProfileForm.ShowDialog() == DialogResult.OK)
            {
                loadMyevents();
                labelWelcome.Text = $"Welcome, {GlobalManager.UserName}!";
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message);
        }
    }

    private void button3_Click(object sender, EventArgs e)
    {
        try
        {
            GlobalManager.clearCurrentUser();
            this.Hide();
            var loginForm = new LoginForm();
            loginForm.Show();
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message);
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        try
        {
            var addEvents = new AddEvents();
            addEvents.Show();
            this.Hide();
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message);
        }
    }

    private void buttonEditEvent_Click(object sender, EventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message);
        }
    }

    private void BtnStats_Click(object? sender, EventArgs e)
    {
        try
        {
            if (dataGridViewEvents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an event to view stats.");
                return;
            }

            int eventId = Convert.ToInt32(dataGridViewEvents.SelectedRows[0].Cells["eventId"].Value);
            string title = dataGridViewEvents.SelectedRows[0].Cells["title"].Value.ToString()!;
            string status = dataGridViewEvents.SelectedRows[0].Cells["status"].Value.ToString()!;

            var organiser = (Organiser)GlobalManager.CurrentUser!;
            var stats = organiser.getEventStats(eventId);
            
            MessageBox.Show($"Event: {title}\nStatus: {status}\n\nTickets Sold: {stats.ticketsSold}\nTotal Revenue: £{stats.moneyMade:F2}", "Event Analytics", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message);
        }
    }

    private void BtnCancelEvent_Click(object? sender, EventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message);
        }
    }
}