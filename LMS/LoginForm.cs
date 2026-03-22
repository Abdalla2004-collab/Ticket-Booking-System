using System;
using MySql.Data.MySqlClient;
using BCrypt.Net;
namespace LMS;

public partial class LoginForm : Form
{
    

    public LoginForm()
    {
        InitializeComponent();
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
            using (MySqlConnection connection = new MySqlConnection(DatabaseHelper.ConnectionString))
            {
                connection.Open();

                string query = "SELECT fullname, password FROM users WHERE email = @email";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@email", email);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedPassword = reader["password"].ToString();
                            string fullname = reader["fullname"].ToString();
                        
                            if (BCrypt.Net.BCrypt.Verify(password, storedPassword))
                            {
                                Session.fullname = fullname;
                                Session.email = email;
                                
                                MessageBox.Show("Welcome, " + fullname + "!");
                                this.Hide();
                                Homepage homepage = new Homepage();
                                homepage.Show();
                                
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