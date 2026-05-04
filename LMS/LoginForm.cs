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

    // Authenticates the user and navigates them to their respective dashboard
    private void button1_Click(object sender, EventArgs e)
    {
        string email = textBox1.Text.Trim();
        string password = textBox2.Text.Trim();

        if (email == "" || password == "")
        {
            MessageBox.Show("Email and password required.");
            return;
        }

        var authResult = GlobalManager.AuthenticateUser(email, password);
        if (authResult.success)
        {
            GlobalManager.setCurrentUser(authResult.user!);
                                
            MessageBox.Show(authResult.message);
            this.Hide();

            Form dashboard = GlobalManager.CurrentUser!.getDashboard();
            dashboard.Show();   
        }
        else
        {
            MessageBox.Show(authResult.message);
        }
    }

    // Navigates to the registration form
    private void button2_Click(object sender, EventArgs e)
    {
        this.Hide();
        Resgistration registration = new Resgistration();
        registration.Show();
    }

}