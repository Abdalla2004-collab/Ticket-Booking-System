namespace LMS;

public partial class AdminDashboard : Form
{
    public AdminDashboard()
    {
        InitializeComponent();
    }

    private void button1_Click_1(object sender, EventArgs e)
    {
        var manageVenues = new ManageVenues();
        manageVenues.Show();
        this.Hide();
    }

    private void button2_Click_1(object sender, EventArgs e)
    {
        GlobalManager.clearCurrentUser();
        LoginForm loginForm = new LoginForm();
        loginForm.Show();
        this.Hide();
    }
}