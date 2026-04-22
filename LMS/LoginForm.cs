using System;
using MySql.Data.MySqlClient;
using BCrypt.Net;
namespace LMS;

public partial class LoginForm : Form
{
    

    public LoginForm()
    {
        InitializeComponent();
        ThemeManager.ApplyLargeTheme(this);
    }

    private void button1_Click(object sender, EventArgs e)
    {
        string email = textBox1.Text.Trim();
        string password = textBox2.Text.Trim();

        if (email == "" || password == "")
        {
            MessageBox.Show("Email and password required.");
            return;
        }

        try
        {
            using (MySqlConnection connection = GlobalManager.GetConnection())
            {
                connection.Open();

                string query = "SELECT id, fullname, email, password, role FROM users WHERE email = @email";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@email", email);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedPassword = reader["password"].ToString();
                            string fullname = reader["fullname"].ToString();
                            string role = reader["role"].ToString();
                            int id = Convert.ToInt32(reader["id"]);
                        
                            if (BCrypt.Net.BCrypt.Verify(password, storedPassword))
                            {
                                var user = GlobalManager.CreateUser(id, fullname, email, role);
                                GlobalManager.setCurrentUser(user);
                                
                                MessageBox.Show("Welcome, " + fullname + "!");
                                this.Hide();

                                Form dashboard = GlobalManager.CurrentUser.getDashboard();
                                dashboard.Show();   

                            }
                            else
                            {
                                MessageBox.Show("Invalid email or password.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid email or password.");
                        }
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
        Resgistration registration = new Resgistration();
        registration.Show();
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
    }

    private void label3_Click(object sender, EventArgs e)
    {
    }

    private void label3_Click_1(object sender, EventArgs e)
    {
    }

    private void label1_Click(object sender, EventArgs e)
    {
    }

    private void label2_Click(object sender, EventArgs e)
    {
    }

    private void LoginForm_Load(object sender, EventArgs e)
    {
    }
}