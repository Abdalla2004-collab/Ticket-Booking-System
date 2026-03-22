namespace LMS;

public partial class ViewEvents : Form
{
    public ViewEvents()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        this.Hide();
        Homepage homepage = new Homepage();
        homepage.Show();
    }
}