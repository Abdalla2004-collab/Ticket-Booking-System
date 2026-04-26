using MySql.Data.MySqlClient;
using LMS.Models;

namespace LMS;

public partial class AddEvents : Form
{
    public AddEvents()
    {
        InitializeComponent();
        ThemeManager.ApplyLargeTheme(this);
        this.Load += AddEvents_Load;
    }

    private void AddEvents_Load(object sender, EventArgs e)
    {
        labelOrganiser.Text = "Organiser: " + GlobalManager.UserName;
        loadVenues();
        loadCategories();

        if(comboBoxDuration.Items.Count == 0)
        {
            comboBoxDuration.Items.AddRange(new object[] { 30, 60, 90, 120, 150, 180, 240 });
            comboBoxDuration.SelectedIndex = 1;
        }

        comboBoxVenue.SelectedIndexChanged += refreshAvailableTimes;
        dateTimePicker2.ValueChanged += refreshAvailableTimes;
        comboBoxDuration.SelectedIndexChanged += refreshAvailableTimes;


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
            string query = "SELECT eventTime, durationMinutes FROM events WHERE venueId = @venueId AND eventDate = @date AND status != 'Rejected'";
            using (var cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@venueId", venueId);
                cmd.Parameters.AddWithValue("@date", dateStr);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        existingEvents.Add((TimeSpan.Parse(reader["eventTime"].ToString()), Convert.ToInt32(reader["durationMinutes"])));
                    }
                }
            }
        }

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

    private void loadVenues()
    {
        using (MySqlConnection connection = GlobalManager.GetConnection())
        {
            connection.Open();
            string query = "SELECT venueId, name, capacity FROM venues WHERE isAvailable = 1 ORDER BY name ASC";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                var venues = new List<Venue>();
                while (reader.Read())
                {
                    venues.Add(new Venue
                    {
                        venueId  = Convert.ToInt32(reader["venueId"]),
                        name     = reader["name"].ToString()!,
                        capacity = Convert.ToInt32(reader["capacity"])
                    });
                }
                comboBoxVenue.DisplayMember = "name";
                comboBoxVenue.ValueMember   = "venueId";
                comboBoxVenue.DataSource    = venues;
                comboBoxVenue.SelectedIndexChanged -= comboBoxVenue_SelectedIndexChanged;
                comboBoxVenue.SelectedIndexChanged += comboBoxVenue_SelectedIndexChanged;
                
                if (comboBoxVenue.Items.Count > 0)
                    comboBoxVenue_SelectedIndexChanged(null, EventArgs.Empty);
            }
        }
    }

    private void comboBoxVenue_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (comboBoxVenue.SelectedItem is Venue v)
        {
            textBoxTickets.Text = v.capacity.ToString();
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



    private void button2_Click(object sender, EventArgs e)
    {
        string title = textBoxTitle.Text.Trim();
        string category = comboBoxCategory.SelectedItem?.ToString() ?? "";
        string date = dateTimePicker2.Value.ToString("yyyy-MM-dd");
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

                string query = @"INSERT INTO events
                    (title, category, eventDate, eventTime, durationMinutes, totalTickets, price, venueId, organiserId)
                    VALUES (@title, @category, @date, @time, @durationMinutes, @tickets, @price, @venueId, @organiserId)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@category", category);
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@time", time);
                    command.Parameters.AddWithValue("@durationMinutes", duration);
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



    private void buttonBack_Click_1(object sender, EventArgs e)
    {
        this.Hide();
        new OrganiserDashboard().Show();
    }
}