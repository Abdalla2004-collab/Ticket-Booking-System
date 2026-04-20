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
}