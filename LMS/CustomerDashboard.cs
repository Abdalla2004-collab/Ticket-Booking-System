namespace LMS;
using LMS.Models;

public partial class CustomerDashboard : Form
{
    public CustomerDashboard()
    {
        InitializeComponent();
    }

    private void CustomerDashboard_Load(object sender, EventArgs e)
    {
        comboBox1.Items.Add("");
        comboBox1.Items.AddRange(new string[]
        {
            "Music", "Sports", "Comedy", "Theatre", "Conference", "Festival", "Other"
        });
        comboBox1.SelectedIndex  = 0;
        comboBox1.DropDownStyle  = ComboBoxStyle.DropDownList;
    }

    private void loadEvents()
    {
        string searchtTitle = textBox1.Text.Trim();
        string filterCategory = comboBox1.SelectedItem?.ToString() ?? "";

        var customer = (Customer)GlobalManager.CurrentUser;
        var events = customer.getApprovedEvents(searchtTitle, filterCategory);

        if (dataGridView1.Columns.Count == 0) return;
        
        dataGridView1.Columns["eventId"].Visible = false;
        dataGridView1.Columns["venueId"].Visible = false;
        dataGridView1.Columns["organiserId"].Visible = false;
        dataGridView1.Columns["status"].Visible = false;
        dataGridView1.Columns["totalTickets"].Visible = false;

        dataGridView1.Columns["title"].HeaderText = "Event";
        dataGridView1.Columns["category"].HeaderText = "Category";
        dataGridView1.Columns["eventDate"].HeaderText = "Date";
        dataGridView1.Columns["eventTime"].HeaderText = "Time";
        dataGridView1.Columns["price"].HeaderText = "Price (£)";
        dataGridView1.Columns["venueName"].HeaderText = "Venue";
        dataGridView1.Columns["availableTickets"].HeaderText = "Tickets Left";
    }

    private void label2_Click(object sender, EventArgs e)
    {
        
    }

    private void button4_Click(object sender, EventArgs e)
    {   
        GlobalManager.clearCurrentUser();
        this.Hide();
        new LoginForm().Show();
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        
    }

    private void button1_Click(object sender, EventArgs e)
    {
        loadEvents();
    }

    private void button3_Click(object sender, EventArgs e)
    {
        var myBookings = new MyBookings();
        myBookings.ShowDialog();
    }

    //booking events
    private void button2_Click(object sender, EventArgs e)
    {
        if (dataGridView1.SelectedRows.Count == 0)
        {
            MessageBox.Show("Please select an event to book.");
            return;
        }
        
        int eventId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["eventId"].Value);
        int available = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["availableTickets"].Value);
        decimal price = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells["price"].Value);
        string title = dataGridView1.SelectedRows[0].Cells["title"].Value.ToString();

        if (available < 0)
        {
            MessageBox.Show("Sorry, this event is sold out.");
            return;
        }
        
        var bookForm = new BookEvent(eventId, title, price, available);
        bookForm.ShowDialog();
        
        loadEvents();


    }
}