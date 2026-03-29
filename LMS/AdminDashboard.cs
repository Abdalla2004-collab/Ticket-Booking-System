using LMS.Models;
namespace LMS;
using MySql.Data.MySqlClient;


public partial class AdminDashboard : Form
{
    public AdminDashboard()
    {
        InitializeComponent();
        this.Load += AdminDashboard_Load;
    }

    public void AdminDashboard_Load(object sender, EventArgs e)
    {
        getEvents();
        loadAllUsers();
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
        dataGridView1.Columns["totalTickets"].HeaderText = "Total Tickets";
        dataGridView1.Columns["price"].HeaderText = "Price";
        dataGridView1.Columns["status"].HeaderText = "Status";
        dataGridView1.Columns["venueName"].HeaderText = "Venue Name";
        
    }
    

    private void button2_Click_1(object sender, EventArgs e)
    {
        GlobalManager.clearCurrentUser();
        LoginForm loginForm = new LoginForm();
        loginForm.Show();
        this.Hide();
    }
    

    private void button3_Click(object sender, EventArgs e)
    {
        GlobalManager.clearCurrentUser();
        LoginForm loginForm = new LoginForm();
        loginForm.Show();
        this.Hide();
    }

    private void button5_Click(object sender, EventArgs e)
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

    //reject event
    private void button7_Click(object sender, EventArgs e)
    {
        if (dataGridView1.SelectedCells.Count == 0)
        {
            MessageBox.Show("Please select an event first");
            return;
        }
        var admin = (Admin)GlobalManager.CurrentUser;
        int eventId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["eventId"].Value);
        
        admin.updateEventStatus(eventId, "Rejected");
        getEvents();
    }
    //delete user
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
    
    //approve event
    private void button6_Click(object sender, EventArgs e)
    {
        if (dataGridView1.SelectedCells.Count == 0)
        {
            MessageBox.Show("Please select an event first");
            return;
        }
        var admin = (Admin)GlobalManager.CurrentUser;
        int eventId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["eventId"].Value);
        
        admin.updateEventStatus(eventId, "Approved");
        getEvents();
    }
}