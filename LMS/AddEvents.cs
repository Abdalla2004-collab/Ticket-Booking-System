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

    // Initializes the Add Events form and loads necessary data
    private void AddEvents_Load(object sender, EventArgs e)
    {
        dateTimePicker2.MinDate = DateTime.Today;
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

    // Refreshes the available time slots based on venue and duration selections
    private void refreshAvailableTimes(object? sender, EventArgs e)
    {
        if (comboBoxVenue.SelectedValue == null || comboBoxDuration.SelectedItem == null) return;
        
        int venueId = (int)comboBoxVenue.SelectedValue;
        string dateStr = dateTimePicker2.Value.ToString("yyyy-MM-dd");
        int duration = (int)comboBoxDuration.SelectedItem;

        var organiser = (Organiser)GlobalManager.CurrentUser!;
        var existingEvents = organiser.getExistingEventsForVenue(venueId, dateStr);

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

            // Ensure we cannot book a slot in the past (if today)
            if (dateTimePicker2.Value.Date == DateTime.Today && currentSlot <= DateTime.Now.TimeOfDay)
            {
                currentSlot = currentSlot.Add(TimeSpan.FromMinutes(30));
                continue;
            }

            // Ensure we cannot book a slot on a past date
            if (dateTimePicker2.Value.Date < DateTime.Today)
            {
                break;
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

    // Loads the available venues into the combo box
    private void loadVenues()
    {
        var venues = GlobalManager.GetAvailableVenues();
        comboBoxVenue.DisplayMember = "name";
        comboBoxVenue.ValueMember   = "venueId";
        comboBoxVenue.DataSource    = venues;
        comboBoxVenue.SelectedIndexChanged -= comboBoxVenue_SelectedIndexChanged;
        comboBoxVenue.SelectedIndexChanged += comboBoxVenue_SelectedIndexChanged;
        
        if (comboBoxVenue.Items.Count > 0)
            comboBoxVenue_SelectedIndexChanged(null, EventArgs.Empty);
    }

    // Updates the tickets text box to the maximum capacity of the selected venue
    private void comboBoxVenue_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (comboBoxVenue.SelectedItem is Venue v)
        {
            textBoxTickets.Text = v.capacity.ToString();
        }
    }

    // Loads predefined categories into the combo box
    private void loadCategories()
    {
        comboBoxCategory.Items.AddRange(new string[]
        {
            "Music", "Sports", "Comedy", "Theatre", "Conference", "Festival", "Other"
        });
        comboBoxCategory.SelectedIndex = 0;
        comboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
    }



    // Validates inputs and creates a new event request
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

        var organiser = (Organiser)GlobalManager.CurrentUser!;
        var result = organiser.addEvent(title, category, date, time, duration, totalTickets, ticketPrice, venueId, organiser.id);

        MessageBox.Show(result.message);
        
        if (result.success)
        {
            this.Hide();
            new OrganiserDashboard().Show();
        }
    }



    // Navigates back to the Organiser Dashboard
    private void buttonBack_Click_1(object sender, EventArgs e)
    {
        this.Hide();
        new OrganiserDashboard().Show();
    }
}