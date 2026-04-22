namespace LMS;
using MySql.Data.MySqlClient;
using LMS.Models;
public partial class EditEvent : Form
{
    private readonly int _eventId;
    public EditEvent(int eventId)
    {
        InitializeComponent();
        ThemeManager.ApplyTheme(this);
        _eventId = eventId;
        this.Load += EditEvent_Load;
    }
    private bool isLoading = true;

    private void EditEvent_Load(object sender, EventArgs e)
    {
        loadVenues();
        loadCategories();

        comboBoxDuration.Items.AddRange(new object[] { 30, 60, 90, 120, 150, 180, 240, 300 });

        comboBoxVenue.SelectedIndexChanged += refreshAvailableTimes;
        dateTimePicker2.ValueChanged += refreshAvailableTimes;
        comboBoxDuration.SelectedIndexChanged += refreshAvailableTimes;

        ThemeManager.ApplyTheme(this);

        loadEventDetails();
        isLoading = false;
    }

    private void refreshAvailableTimes(object? sender, EventArgs e)
    {
        if (comboBoxVenue.SelectedValue == null || comboBoxDuration.SelectedItem == null) return;
        
        int venueId = (int)comboBoxVenue.SelectedValue;
        string dateStr = dateTimePicker2.Value.ToString("yyyy-MM-dd");
        int duration = (int)comboBoxDuration.SelectedItem;

        var existingEvents = new List<(TimeSpan start, int dur)>();

        using (var connection = GlobalManager.GetConnection())
        {
            connection.Open();
            string query = "SELECT eventTime, durationMinutes FROM events WHERE venueId = @vId AND eventDate = @d AND eventId != @eId AND status != 'Rejected'";
            using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@vId", venueId);
                cmd.Parameters.AddWithValue("@d", dateStr);
                cmd.Parameters.AddWithValue("@eId", _eventId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        existingEvents.Add((TimeSpan.Parse(reader["eventTime"].ToString()!), Convert.ToInt32(reader["durationMinutes"])));
                    }
                }
            }
        }

        string previousSelection = comboBoxTime.SelectedItem?.ToString() ?? "";
        comboBoxTime.Items.Clear();
        TimeSpan currentSlot = TimeSpan.FromHours(8);
        TimeSpan endOfDay = TimeSpan.FromHours(22);

        while (currentSlot < endOfDay)
        {
            TimeSpan proposedEnd = currentSlot.Add(TimeSpan.FromMinutes(duration));
            
            if (proposedEnd > endOfDay)
            {
                currentSlot = currentSlot.Add(TimeSpan.FromMinutes(30));
                continue;
            }

            bool overlap = false;
            foreach (var ev in existingEvents)
            {
                TimeSpan evEnd = ev.start.Add(TimeSpan.FromMinutes(ev.dur));
                if (currentSlot < evEnd && proposedEnd > ev.start)
                {
                    overlap = true;
                    break;
                }
            }

            if (!overlap)
            {
                comboBoxTime.Items.Add(currentSlot.ToString(@"hh\:mm"));
            }

            currentSlot = currentSlot.Add(TimeSpan.FromMinutes(30));
        }

        if (comboBoxTime.Items.Count > 0)
        {
            if (comboBoxTime.Items.Contains(previousSelection))
                comboBoxTime.SelectedItem = previousSelection;
            else
                comboBoxTime.SelectedIndex = 0;
            comboBoxTime.Enabled = true;
        }
        else
        {
            comboBoxTime.Items.Add("No slots");
            comboBoxTime.SelectedIndex = 0;
            comboBoxTime.Enabled = false;
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
    private void loadVenues()
    {
        using (MySqlConnection connection = GlobalManager.GetConnection())
        {
            connection.Open();
            string query = "SELECT venueId, name, capacity FROM venues ORDER BY name ASC";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                var venues = new List<Venue>();
                while (reader.Read())
                {
                    venues.Add(new Venue
                    {
                        venueId = Convert.ToInt32(reader["venueId"]),
                        name    = reader["name"].ToString(),
                        capacity = Convert.ToInt32(reader["capacity"])
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
            string Query = @"SELECT title, category, eventDate, eventTime, durationMinutes, totalTickets, price, 
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
                        
                        comboBoxCategory.SelectedItem = reader["category"].ToString();
                        comboBoxDuration.SelectedItem = Convert.ToInt32(reader["durationMinutes"]);
                        dateTimePicker2.Value = Convert.ToDateTime(reader["eventDate"]);
                        comboBoxVenue.SelectedValue = Convert.ToInt32(reader["venueId"]);

                        string loadedTime = TimeSpan.Parse(reader["eventTime"].ToString()).ToString(@"hh\:mm");
                        if (!comboBoxTime.Items.Contains(loadedTime))
                        {
                            comboBoxTime.Items.Add(loadedTime);
                        }
                        comboBoxTime.SelectedItem = loadedTime;
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

    int venueId = (int)comboBoxVenue.SelectedValue!;
    int capacity = ((Venue)comboBoxVenue.SelectedItem).capacity;

    if (totalTickets > capacity)
    {
        MessageBox.Show($"Tickets cannot exceed the venue's capacity of {capacity}.");
        return;
    }

    if (comboBoxTime.SelectedItem == null || !comboBoxTime.Enabled || comboBoxTime.SelectedItem.ToString() == "No slots")
    {
        MessageBox.Show("Please select an available time slot.");
        return;
    }

    string time = comboBoxTime.SelectedItem.ToString() + ":00";
    int duration = (int)comboBoxDuration.SelectedItem;

    try
    {
        using (MySqlConnection connection = GlobalManager.GetConnection())
        {
            connection.Open();

            string query = @"
                UPDATE events 
                SET title = @title, category = @category, totalTickets = @tickets,price = @price, 
                    venueId = @venueId,eventDate = @date,eventTime = @time, durationMinutes = @durationMinutes, status = 'Pending'
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
                command.Parameters.AddWithValue("@time", time);
                command.Parameters.AddWithValue("@durationMinutes", duration);
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