
using MySql.Data.MySqlClient;
namespace LMS;
using BCrypt.Net;

public partial class Resgistration : Form
{   
    public Resgistration()
    {
        InitializeComponent();
        ThemeManager.ApplyLargeTheme(this);
    }



    // Registers a new user and navigates to the login form
    private void button1_Click(object sender, EventArgs e)
    {
        
        // accepting input from user
        
        string name = textBox1.Text.Trim();
        string email = textBox2.Text.Trim();
        string password = textBox3.Text.Trim();
        string confirmPassword = textBox4.Text.Trim();
        string role = comboBoxRole.SelectedItem?.ToString() ?? "Customer";

        
        
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
        
        if (GlobalManager.EmailExists(email))
        {
            MessageBox.Show("An account with this email already exists.");
            return;
        }
        try
        {
            var regResult = GlobalManager.RegisterUser(name, email, password, role);
            if (regResult.success)
            {
                MessageBox.Show(regResult.message);
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
            else
            {
                MessageBox.Show(regResult.message);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
    }

    // Navigates back to the login form
    private void button2_Click(object sender, EventArgs e)
    {
        this.Hide();
        LoginForm loginForm = new LoginForm();
        loginForm.Show();
    }
}