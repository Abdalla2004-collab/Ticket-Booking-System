using LMS.Models;
namespace LMS;
using MySql.Data.MySqlClient;
using BCrypt.Net;
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
        try
        {
            getEvents();
            loadAllUsers();
            loadDiscounts();
            loadAnalyticsTab();
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message);
        }
    }

    private void loadAnalyticsTab()
    {
        try
        {
            var admin = (Admin)GlobalManager.CurrentUser!;
            var stats = admin.getAnalyticsStats();

            string analyticsText = $"Overall Business Performance\n\n" +
                                   $"Total Users: {stats.totalUsers}\n" +
                                   $"Approved Events: {stats.activeEvents}\n" +
                                   $"Total Tickets Sold: {stats.totalTicketsSold}\n" +
                                   $"Total Net Revenue: £{stats.totalRevenue:F2}";

            lblAnalytics.Text = analyticsText;
            
            ThemeManager.ApplyTheme(this);
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred loading analytics: " + ex.Message);
        }
    }

    public void loadAllUsers()
    {
        try
        {
            var admin = (Admin)GlobalManager.CurrentUser;
            var users = admin.getAllUsers();
            
            dataGridView2.DataSource = users;
            
            dataGridView2.Columns["userId"].Visible = false;
            dataGridView2.Columns["fullname"].HeaderText = "Full Name";
            dataGridView2.Columns["email"].HeaderText = "Email";
            dataGridView2.Columns["role"].HeaderText = "Role";
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred loading users: " + ex.Message);
        }
    }

    public void getEvents()
    {
        try
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
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred loading events: " + ex.Message);
        }
    }

    private void buttonLogoutShared_Click(object sender, EventArgs e)
    {
        try
        {
            GlobalManager.clearCurrentUser();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
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
                loadAllUsers();
                getEvents();
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
            string name = textBox1.Text.Trim();
            string address = textBox2.Text.Trim();
            string capacity = textBox3.Text.Trim();

            if (name == "" || address == "" || capacity == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }
            if (!int.TryParse(capacity, out int capacityValue) || capacityValue <= 0)
            {
                MessageBox.Show("Capacity must be a positive whole number.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to add this new venue?", "Confirm Venue Addition", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            var admin = (Admin)GlobalManager.CurrentUser!;
            var result = admin.addVenue(name, address, capacityValue);
            
            MessageBox.Show(result.message);
            
            if (result.success)
            {
                AdminDashboard adminDashboard = new AdminDashboard();
                adminDashboard.Show();
                this.Hide();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message);
        }
    }

    private void button7_Click(object sender, EventArgs e)
    {
        try
        {
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select an event first");
                return;
            }

            string currentStatus = dataGridView1.SelectedRows[0].Cells["status"].Value.ToString()!;
            int eventId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["eventId"].Value);
            int organiserId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["organiserId"].Value);
            string title = dataGridView1.SelectedRows[0].Cells["title"].Value?.ToString() ?? "";

            if (currentStatus == "Rejected")
            {
                MessageBox.Show("The event has already been rejected");
                return;
            }
            
            var admin = (Admin)GlobalManager.CurrentUser!;
            
            if (currentStatus == "Approved")
            {
                if (MessageBox.Show("This event is already approved. Rejecting it will forcefully cancel it and send refund notifications to all buyers. Proceed?", "Confirm Rejection", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
                admin.rejectEventAndCancelBookings(eventId, title);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to reject this event?", "Confirm Rejection", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
                admin.updateEventStatus(eventId, "Rejected");
            }
            
            GlobalManager.sendNotification(organiserId, $"Your event '{title}' has been rejected.");
            
            loadAnalyticsTab();
            getEvents();
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message);
        }
    }

    private void button4_Click(object sender, EventArgs e)
    {
        try
        {
            if (dataGridView2.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select a user first");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this user? This action cannot be undone.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }
            
            var admin = (Admin)GlobalManager.CurrentUser;
            int userId = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["userId"].Value);
            admin.DeleteUser(userId);
            loadAllUsers();
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message);
        }
    }
    
    private void button6_Click(object sender, EventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message);
        }
    }
    
    private void loadDiscounts()
    {
        try
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
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred loading discounts: " + ex.Message);
        }
    }

    private void buttonCreateDiscount_Click(object sender, EventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message);
        }
    }

    private void buttonToggleDiscount_Click(object sender, EventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message);
        }
    }

    private void buttonAddAdmin_Click(object sender, EventArgs e)
    {
        try
        {
            string name = textBoxAdminName.Text.Trim();
            string email = textBoxAdminEmail.Text.Trim();
            string password = textBoxAdminPassword.Text.Trim();
            string confirmPassword = textBoxAdminConfirmPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Invalid email.");
                return;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to add a new admin?", "Confirm Admin Creation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            var admin = (Admin)GlobalManager.CurrentUser;
            var result = admin.createAdmin(name, email, password);

            MessageBox.Show(result.message);

            if (result.success)
            {
                textBoxAdminName.Text = "";
                textBoxAdminEmail.Text = "";
                textBoxAdminPassword.Text = "";
                textBoxAdminConfirmPassword.Text = "";
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message);
        }
    }
}