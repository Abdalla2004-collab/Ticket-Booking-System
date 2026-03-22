
using MySql.Data.MySqlClient;
namespace LMS;
using BCrypt.Net;

public partial class Resgistration : Form
{   
    public Resgistration()
    {
        InitializeComponent();
    }

    private void Resgistration_Load(object sender, EventArgs e)
    {
        
    }
    private bool EmailExists(string email)
    {
        using (MySqlConnection connection = new MySqlConnection(DatabaseHelper.ConnectionString))
        {
            connection.Open();
            string query = "SELECT COUNT(*) FROM users WHERE email = @email";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@email", email);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        
        // accepting input from user
        
        string name = textBox1.Text.Trim();
        string email = textBox2.Text.Trim();
        string password = textBox3.Text.Trim();
        string confirmPassword = textBox4.Text.Trim();
        
        
        if (name.Length == 0 || email.Length == 0 || password.Length == 0 || confirmPassword.Length == 0)
        {
            MessageBox.Show("Please fill in all fields.");
            return;
        }

        if (!email.Contains("@") || !email.Contains("."))
        {
            MessageBox.Show("Invalid email.");
            return;
        }

        if (password.Length < 8 || password.Length > 100)
        {
            MessageBox.Show("Password must be at least 8 characters long.");
            return;
        }

        if (!password.Equals(confirmPassword))
        {
            MessageBox.Show("Passwords do not match.");
            return;
        }
        
        if (EmailExists(email))
        {
            MessageBox.Show("An account with this email already exists.");
            return;
        }
        try
        {
            using (MySqlConnection connection = new MySqlConnection(DatabaseHelper.ConnectionString))
            {
                connection.Open();
                
                string query = "INSERT INTO users (fullname, email, password) VALUES (@name, @email, @password)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    string hashedPassword = BCrypt.HashPassword(password);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", hashedPassword);
                    
                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Registration successful!");
                        this.Hide();
                        LoginForm loginForm = new LoginForm();
                        loginForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Registration failed. Please try again.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        this.Hide();
        LoginForm loginForm = new LoginForm();
        loginForm.Show();
    }
}