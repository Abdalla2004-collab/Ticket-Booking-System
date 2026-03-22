namespace LMS;

public partial class Homepage : Form
{
    public Homepage()
    {
        InitializeComponent();
    }

    private void button3_Click(object sender, EventArgs e)
    {
        this.Hide();
        LoginForm loginform = new LoginForm();
        loginform.Show();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        this.Hide();
        ViewEvents viewbooks = new ViewEvents();
        viewbooks.Show();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        this.Hide();
        AddEvents addbooks = new AddEvents();
        addbooks.Show();
    }
}