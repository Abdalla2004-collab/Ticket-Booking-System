namespace LMS;
using MySql.Data.MySqlClient;
using System;

public partial class ManageVenues : Form
{
    public ManageVenues()
    {
        InitializeComponent();
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

    private void button2_Click_1(object sender, EventArgs e)
    {
        AdminDashboard adminDashboard = new AdminDashboard();
        adminDashboard.Show();
        this.Hide();
    }
}