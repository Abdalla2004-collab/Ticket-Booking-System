namespace LMS;
using LMS.Models;

public partial class CustomerDashboard : Form
{
    public CustomerDashboard()
    {
        InitializeComponent();
        ThemeManager.ApplyTheme(this);
        this.Load += CustomerDashboard_Load;
        
    }

    private void CustomerDashboard_Load(object sender, EventArgs e)
    {
        label1.Text = "Welcome, " + GlobalManager.UserName;
        loadCategories();
        loadEvents();
        loadNotifications();
    }
    private void loadCategories()
    {
        comboBox1.Items.Add("");
        comboBox1.Items.AddRange(new string[]
        {
            "Music", "Sports", "Comedy", "Theatre", "Conference", "Festival", "Other"
        });
        comboBox1.SelectedIndex  = 0;
        comboBox1.DropDownStyle  = ComboBoxStyle.DropDownList;
    }

    private void loadEvents()
    {
        string searchTitle = textBox1.Text.Trim();
        string filterCategory = comboBox1.SelectedItem?.ToString() ?? "";

        var customer = (Customer)GlobalManager.CurrentUser;
        var events = customer.getApprovedEvents(searchTitle, filterCategory);

        dataGridView1.DataSource = events;

        if (dataGridView1.Columns.Contains("eventId"))
            dataGridView1.Columns["eventId"].Visible = false;

        if (dataGridView1.Columns.Contains("venueId"))
            dataGridView1.Columns["venueId"].Visible = false;

        if (dataGridView1.Columns.Contains("organiserId"))
            dataGridView1.Columns["organiserId"].Visible = false;

        if (dataGridView1.Columns.Contains("status"))
            dataGridView1.Columns["status"].Visible = false;

        if (dataGridView1.Columns.Contains("totalTickets"))
            dataGridView1.Columns["totalTickets"].Visible = false;

        dataGridView1.Columns["title"].HeaderText = "Event";
        dataGridView1.Columns["category"].HeaderText = "Category";
        dataGridView1.Columns["eventDate"].HeaderText = "Date";
        dataGridView1.Columns["eventTime"].HeaderText = "Time";
        dataGridView1.Columns["price"].HeaderText = "Price (£)";
        dataGridView1.Columns["venueName"].HeaderText = "Venue";
        dataGridView1.Columns["availableTickets"].HeaderText = "Tickets Left";
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
        var customer = (Customer)GlobalManager.CurrentUser;
        customer.markNotificationsRead();
        panelNotifications.Visible = false;
    }

    private void label2_Click(object sender, EventArgs e)
    {
        
    }

    private void button4_Click(object sender, EventArgs e)
    {   
        
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        
    }

    private void button1_Click(object sender, EventArgs e)
    {
        loadEvents();
    }

    private void button3_Click(object sender, EventArgs e)
    {
        var myBookings = new MyBookings();
        myBookings.BookingsUpdated += () => loadEvents();
        myBookings.BookingsUpdated += () => loadNotifications();
        myBookings.ShowDialog();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        if (dataGridView1.SelectedRows.Count == 0)
        {
            MessageBox.Show("Please select an event to book.");
            return;
        }
        
        int eventId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["eventId"].Value);
        int available = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["availableTickets"].Value);
        decimal price = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells["price"].Value);
        string title = dataGridView1.SelectedRows[0].Cells["title"].Value.ToString() ?? "";

        if (available <= 0)
        {
            MessageBox.Show("Sorry, this event is sold out.");
            return;
        }
        
        var bookForm = new BookEvent(eventId, title, price, available);
        bookForm.ShowDialog();
        
        loadEvents();
        loadNotifications();
    }

    private void button4_Click_1(object sender, EventArgs e)
    {
        GlobalManager.clearCurrentUser();
        this.Hide();
        new LoginForm().Show();
    }
}