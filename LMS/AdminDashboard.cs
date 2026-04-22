using LMS.Models;
namespace LMS;
using MySql.Data.MySqlClient;


public partial class AdminDashboard : Form
{
    public AdminDashboard()
    {
        InitializeComponent();
        ThemeManager.ApplyTheme(this);
        this.Load += AdminDashboard_Load;
        
    }

    public void AdminDashboard_Load(object sender, EventArgs e)
    {
        getEvents();
        loadAllUsers();
        loadDiscounts();
        loadAnalyticsTab();
    }

    private void loadAnalyticsTab()
    {
        int totalUsers = 0;
        int activeEvents = 0;
        decimal totalRevenue = 0m;
        int totalTicketsSold = 0;
        
        using (var connection = GlobalManager.GetConnection())
        {
            connection.Open();
            string statsQuery = @"
                SELECT 
                    (SELECT COUNT(*) FROM users) as UsersCount,
                    (SELECT COUNT(*) FROM events WHERE status = 'Approved') as EventsCount,
                    (SELECT COALESCE(SUM(totalPrice), 0) FROM bookings WHERE status = 'Confirmed') as Revenue,
                    (SELECT COALESCE(SUM(quantity), 0) FROM bookings WHERE status = 'Confirmed') as TicketsSold;
            ";
            
            using (var cmd = new MySqlCommand(statsQuery, connection))
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    totalUsers = Convert.ToInt32(reader["UsersCount"]);
                    activeEvents = Convert.ToInt32(reader["EventsCount"]);
                    totalRevenue = Convert.ToDecimal(reader["Revenue"]);
                    totalTicketsSold = Convert.ToInt32(reader["TicketsSold"]);
                }
            }
        }

        string analyticsText = $"Overall Business Performance\n\n" +
                               $"Total Users: {totalUsers}\n" +
                               $"Approved Events: {activeEvents}\n" +
                               $"Total Tickets Sold: {totalTicketsSold}\n" +
                               $"Total Net Revenue: £{totalRevenue:F2}";

        lblAnalytics.Text = analyticsText;
        
        ThemeManager.ApplyTheme(this);
    }

    public void loadAllUsers()
    {
        var admin = (Admin)GlobalManager.CurrentUser;
        var users = admin.getAllUsers();
        
        dataGridView2.DataSource = users;
        
        dataGridView2.Columns["userId"].Visible = false;
        dataGridView2.Columns["fullname"].HeaderText = "Full Name";
        dataGridView2.Columns["email"].HeaderText = "Email";
        dataGridView2.Columns["role"].HeaderText = "Role";
        
    }

    public void getEvents()
    {
        var admin = (Admin)GlobalManager.CurrentUser;
        var events = admin.getEvents();
        
        dataGridView1.DataSource = events;
        
        dataGridView1.Columns["eventId"].Visible = false;
        dataGridView1.Columns["organiserId"].Visible = false;
        dataGridView1.Columns["venueId"].Visible = false;
        
        dataGridView1.Columns["title"].HeaderText = "Title";
        dataGridView1.Columns["category"].HeaderText = "Category";
        dataGridView1.Columns["eventDate"].HeaderText = "Date";
        dataGridView1.Columns["eventTime"].HeaderText = "Time";
        dataGridView1.Columns["availableTickets"].HeaderText = "Available Tickets";
        dataGridView1.Columns["price"].HeaderText = "Price";
        dataGridView1.Columns["status"].HeaderText = "Status";
        dataGridView1.Columns["venueName"].HeaderText = "Venue Name";
        
    }
    

    private void buttonLogoutShared_Click(object sender, EventArgs e)
    {
        GlobalManager.clearCurrentUser();
        LoginForm loginForm = new LoginForm();
        loginForm.Show();
        this.Hide();
    }
    



    private void button1_Click(object sender, EventArgs e)
    {
        string name = textBox1.Text.Trim();
        string address = textBox2.Text.Trim();
        string capacity = textBox3.Text.Trim();

        if (name == "" || address == "" || capacity == "")
        {
            MessageBox.Show("Please fill all fields");
            return;
        }
        if (!int.TryParse(capacity, out int Capacity) || Capacity <= 0)
        {
            MessageBox.Show("Capacity must be a positive whole number.");
            return;
        }
        try
        {
            using (MySqlConnection connection = GlobalManager.GetConnection())
            {
                connection.Open();
                string query = @"INSERT INTO Venues (name, address, capacity) values (@name, @address, @capacity)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@capacity", Capacity);
                    
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Successfully added Venues");
                        AdminDashboard adminDashboard = new AdminDashboard();
                        adminDashboard.Show();
                        this.Hide();
                    }
                }

            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void button7_Click(object sender, EventArgs e)
    {
        if (dataGridView1.SelectedCells.Count == 0)
        {
            MessageBox.Show("Please select an event first");
            return;
        }

        string currentStatus = dataGridView1.SelectedRows[0].Cells["status"].Value.ToString();
        int eventId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["eventId"].Value);
        int organiserId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["organiserId"].Value);
        string title = dataGridView1.SelectedRows[0].Cells["title"].Value?.ToString() ?? "";


        if (currentStatus == "Rejected")
        {
            MessageBox.Show("The event has already been rejected");
            return;
        }
        if (currentStatus == "Approved")
        {
            if (MessageBox.Show("This event is already approved. Rejecting it will forcefully cancel it and send refund notifications to all buyers. Proceed?", "Confirm Rejection", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            
            using (var connection = GlobalManager.GetConnection())
            {
                connection.Open();
                
                string getCustomersQuery = "SELECT DISTINCT customerId FROM bookings WHERE eventId = @eventId AND status = 'Confirmed'";
                var customersToNotify = new List<int>();
                using (var cmd = new MySqlCommand(getCustomersQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@eventId", eventId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customersToNotify.Add(Convert.ToInt32(reader["customerId"]));
                        }
                    }
                }

                foreach (var cid in customersToNotify)
                {
                    GlobalManager.sendNotification(cid, $"The event '{title}' has been cancelled by an administrator. A refund is processing.");
                }

                string updateBookings = "UPDATE bookings SET status = 'Cancelled' WHERE eventId = @eventId";
                using (var cmd = new MySqlCommand(updateBookings, connection))
                {
                    cmd.Parameters.AddWithValue("@eventId", eventId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        else
        {
            if (MessageBox.Show("Are you sure you want to reject this event?", "Confirm Rejection", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
        }

        var admin = (Admin)GlobalManager.CurrentUser;
        
        admin.updateEventStatus(eventId, "Rejected");
        
        GlobalManager.sendNotification(organiserId, $"Your event '{title}' has been rejected.");
        
        loadAnalyticsTab();
        getEvents();
    }
    private void button4_Click(object sender, EventArgs e)
    {
        if (dataGridView2.SelectedCells.Count == 0)
        {
            MessageBox.Show("Please select a user first");
            return;
        }
        
        var admin = (Admin)GlobalManager.CurrentUser;
        int userId = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["userId"].Value);
        admin.DeleteUser(userId);
        loadAllUsers();

    }
    
    private void button6_Click(object sender, EventArgs e)
    {
        if (dataGridView1.SelectedCells.Count == 0)
        {
            MessageBox.Show("Please select an event first");
            return;
        }

        string currentStatus = dataGridView1.SelectedRows[0].Cells["status"].Value.ToString();
        if (currentStatus == "Approved")
        {
            MessageBox.Show("This event is already approved.");
            return;
        }
        if (currentStatus == "Rejected")
        {
            MessageBox.Show("Rejected events cannot be approved unless the organiser updates them.");
            return;
        }

        if (MessageBox.Show("Are you sure you want to approve this event?", "Confirm Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

        var admin = (Admin)GlobalManager.CurrentUser;
        int eventId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["eventId"].Value);
        int organiserId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["organiserId"].Value);
        string title = dataGridView1.SelectedRows[0].Cells["title"].Value.ToString();
        
        admin.updateEventStatus(eventId, "Approved");
        
        GlobalManager.sendNotification(organiserId, $"Your event '{title}' has been approved!");
        
        getEvents();
        loadAnalyticsTab();

    }
    
    private void loadDiscounts()
    {
        var admin = (Admin)GlobalManager.CurrentUser;
        var discounts = admin.getDiscounts();
        
        dataGridView3.DataSource = discounts;
        
        dataGridView3.Columns["discountId"].Visible = false;
        dataGridView3.Columns["code"].HeaderText = "Code";
        dataGridView3.Columns["percentage"].HeaderText = "Discount %";
        dataGridView3.Columns["isActive"].HeaderText = "Active";
        dataGridView3.Columns["createdAt"].HeaderText = "Created";
    }

    private void buttonCreateDiscount_Click(object sender, EventArgs e)
    {
        string code = textBoxDiscountCode.Text.Trim();
        int percentage = (int)numericPercentage.Value;

        var admin = (Admin)GlobalManager.CurrentUser;
        var result = admin.createDiscount(code, percentage);

        MessageBox.Show(result.message);

        if (result.success)
        {
            textBoxDiscountCode.Text = "";
            numericPercentage.Value = 10;
            loadDiscounts();
        }
    }

    private void buttonToggleDiscount_Click(object sender, EventArgs e)
    {
        if (dataGridView3.SelectedRows.Count == 0)
        {
            MessageBox.Show("Please select a discount code first.");
            return;
        }

        int discountId = Convert.ToInt32(dataGridView3.SelectedRows[0].Cells["discountId"].Value);
        
        var admin = (Admin)GlobalManager.CurrentUser;
        admin.toggleDiscount(discountId);
        loadDiscounts();
    }
    
}