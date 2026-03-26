using MySql.Data.MySqlClient;
using LMS.Models;

namespace LMS;

public partial class AddEvents : Form
{
    public AddEvents()
    {
        InitializeComponent();
        this.Load += AddEvents_Load;
    }

    private void AddEvents_Load(object sender, EventArgs e)
    {
        labelOrganiser.Text = "Organiser: " + GlobalManager.UserName;
        loadVenues();
        loadCategories();
    }

    private void loadVenues()
    {
        using (MySqlConnection connection = GlobalManager.GetConnection())
        {
            connection.Open();
            string query = "SELECT venueId, name FROM venues ORDER BY name ASC";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                var venues = new List<Venue>();
                while (reader.Read())
                {
                    venues.Add(new Venue
                    {
                        venueId = Convert.ToInt32(reader["venueId"]),
                        name    = reader["name"].ToString()!
                    });
                }
                comboBoxVenue.DisplayMember = "name";
                comboBoxVenue.ValueMember   = "venueId";
                comboBoxVenue.DataSource    = venues;
            }
        }
    }

    private void loadCategories()
    {
        comboBoxCategory.Items.AddRange(new string[]
        {
            "Music", "Sports", "Comedy", "Theatre", "Conference", "Festival", "Other"
        });
        comboBoxCategory.SelectedIndex = 0;
        comboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
    }

    private void buttonAdd_Click(object sender, EventArgs e)
    {
        
    }

    

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        
    }

    private void label1_Click(object sender, EventArgs e)
    {
        
    }

    private void button2_Click(object sender, EventArgs e)
    {
        string title = textBoxTitle.Text.Trim();
        string category = comboBoxCategory.SelectedItem?.ToString() ?? "";
        string date = dateTimePicker2.Value.ToString("yyyy-MM-dd");
        string time = dateTimePicker1.Value.ToString("HH:mm:ss");
        string tickets = textBoxTickets.Text.Trim();
        string price = textBoxPrice.Text.Trim();

        if (title.Length == 0 || tickets.Length == 0 || price.Length == 0)
        {
            MessageBox.Show("Please fill in all fields.");
            return;
        }

        if (!int.TryParse(tickets, out int totalTickets) || totalTickets <= 0)
        {
            MessageBox.Show("Tickets must be a positive whole number.");
            return;
        }

        if (!decimal.TryParse(price, out decimal ticketPrice) || ticketPrice < 0)
        {
            MessageBox.Show("Price must be a valid positive number.");
            return;
        }

        if (comboBoxVenue.SelectedItem == null)
        {
            MessageBox.Show("Please select a venue.");
            return;
        }

        int venueId = (int)comboBoxVenue.SelectedValue!;

        try
        {
            using (MySqlConnection connection = GlobalManager.GetConnection())
            {
                connection.Open();
                string query = @"INSERT INTO events
                    (title, category, eventDate, eventTime, totalTickets, price, venueId, organiserId)
                    VALUES (@title, @category, @date, @time, @tickets, @price, @venueId, @organiserId)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@category", category);
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@time", time);
                    command.Parameters.AddWithValue("@tickets", totalTickets);
                    command.Parameters.AddWithValue("@price", ticketPrice);
                    command.Parameters.AddWithValue("@venueId", venueId);
                    command.Parameters.AddWithValue("@organiserId", GlobalManager.UserId);

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Event added! Awaiting admin approval.");
                        this.Hide();
                        new OrganiserDashboard().Show();
                    }
                    else
                        MessageBox.Show("Failed to add event.");
                }
            }
        }
        catch (MySqlException ex) when (ex.Number == 1062)
        {
            MessageBox.Show("This venue already has an event at that date and time.");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
    }

    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
    {
        
    }

    private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
    {
        
    }

    private void label5_Click(object sender, EventArgs e)
    {
        
    }

    private void buttonBack_Click_1(object sender, EventArgs e)
    {
        this.Hide();
        new OrganiserDashboard().Show();
    }
}