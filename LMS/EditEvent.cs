namespace LMS;
using MySql.Data.MySqlClient;
using LMS.Models;
public partial class EditEvent : Form
{
    private readonly int _eventId;
    public EditEvent(int eventId)
    {
        InitializeComponent();
        _eventId = eventId;
        this.Load += EditEvent_Load;
    }
    private void EditEvent_Load(object sender, EventArgs e)
    {
        loadVenues();
        loadCategories();
        loadEventDetails();
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
                comboBoxVenue.ValueMember = "venueId";
                comboBoxVenue.DataSource = venues;
            }
        }
    }

    private void loadEventDetails()
    {
        using (MySqlConnection connection = GlobalManager.GetConnection()){
            connection.Open();
            string Query = @"SELECT title, category, eventDate, eventTime, totalTickets, price, 
                            VenueId FROM events WHERE eventId = @eventId";
            using (MySqlCommand command = new MySqlCommand(Query, connection))
            {   
                command.Parameters.AddWithValue("@eventId", _eventId);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        textBoxTitle.Text = reader["title"].ToString();
                        textBoxTickets.Text = reader["totalTickets"].ToString();
                        textBoxPrice.Text = reader["price"].ToString();
                        dateTimePicker2.Value = Convert.ToDateTime(reader["eventDate"]);
                        dateTimePicker1.Value = DateTime.Today.Add(TimeSpan.Parse(reader["eventTime"].ToString()));
                        comboBoxCategory.SelectedItem = reader["category"].ToString();
                        comboBoxVenue.SelectedValue = Convert.ToInt32(reader["venueId"]);

                    }
                }
            }
        }
    }


    private void label1_Click(object sender, EventArgs e)
    {
    }

    private void button2_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void button1_Click(object sender, EventArgs e)
{
    string title = textBoxTitle.Text.Trim();
    string tickets = textBoxTickets.Text.Trim();
    string price = textBoxPrice.Text.Trim();

    if (title.Length == 0 || tickets.Length == 0 || price.Length == 0)
    {
        MessageBox.Show("Please fill in all fields."); return;
    }

    if (!int.TryParse(tickets, out int totalTickets) || totalTickets <= 0)
    {
        MessageBox.Show("Tickets must be a positive whole number."); return;
    }

    if (!decimal.TryParse(price, out decimal ticketPrice) || ticketPrice < 0)
    {
        MessageBox.Show("Price must be a valid positive number."); return;
    }

    try
    {
        using (MySqlConnection connection = GlobalManager.GetConnection())
        {
            connection.Open();
            string query = @"
                UPDATE events 
                SET title = @title, category = @category, totalTickets = @tickets,price = @price, 
                    venueId = @venueId,eventDate = @date,eventTime = @time, status = 'Pending'
                WHERE eventId = @eventId AND organiserId = @organiserId";
            
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@eventId", _eventId);
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@category", comboBoxCategory.SelectedItem);
                command.Parameters.AddWithValue("@tickets", totalTickets);
                command.Parameters.AddWithValue("@price", ticketPrice);
                command.Parameters.AddWithValue("@venueId", (int)comboBoxVenue.SelectedValue);
                command.Parameters.AddWithValue("@date", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@time", dateTimePicker1.Value.ToString("HH:mm:ss"));
                command.Parameters.AddWithValue("@organiserId", GlobalManager.UserId);

                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Event updated and resubmitted for admin approval.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Unable to update event. You may not have permission.");
                }
            }
        }
    }
    catch (MySqlException ex) when (ex.Number == 1062)
    {
        MessageBox.Show("That venue already has an event at that date and time.");
    }
    catch (MySqlException ex)
    {
        MessageBox.Show(ex.Message);
    }
}
}