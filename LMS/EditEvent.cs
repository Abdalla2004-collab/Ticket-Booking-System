namespace LMS;
using MySql.Data.MySqlClient;
using LMS.Models;
public partial class EditEvent : Form
{
    private readonly int _eventId;
    public EditEvent(int eventId)
    {
        InitializeComponent();
        ThemeManager.ApplyLargeTheme(this);
        _eventId = eventId;
        this.Load += EditEvent_Load;
    }


    // Initializes the Edit Event form and loads necessary data for the event
    private void EditEvent_Load(object sender, EventArgs e)
    {
        dateTimePicker2.MinDate = DateTime.Today;
        loadVenues();
        loadCategories();

        comboBoxDuration.Items.AddRange(new object[] { 30, 60, 90, 120, 150, 180, 240, 300 });

        comboBoxVenue.SelectedIndexChanged += refreshAvailableTimes;
        dateTimePicker2.ValueChanged += refreshAvailableTimes;
        comboBoxDuration.SelectedIndexChanged += refreshAvailableTimes;



        loadEventDetails();

    }

    // Refreshes the available time slots based on venue, date, and duration selections
    private void refreshAvailableTimes(object? sender, EventArgs e)
    {
        if (comboBoxVenue.SelectedValue == null || comboBoxDuration.SelectedItem == null) return;
        
        int venueId = (int)comboBoxVenue.SelectedValue;
        string dateStr = dateTimePicker2.Value.ToString("yyyy-MM-dd");
        int duration = (int)comboBoxDuration.SelectedItem;

        var organiser = (Organiser)GlobalManager.CurrentUser!;
        var existingEvents = organiser.getExistingEventsForVenue(venueId, dateStr, _eventId);

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
    // Loads all venues into the combo box for selection
    private void loadVenues()
    {
        var venues = GlobalManager.GetAllVenues();
        comboBoxVenue.DisplayMember = "name";
        comboBoxVenue.ValueMember = "venueId";
        comboBoxVenue.DataSource = venues;
    }

    // Fetches the existing details of the event and populates the form fields
    private void loadEventDetails()
    {
        var organiser = (Organiser)GlobalManager.CurrentUser!;
        var eventObj = organiser.getEventDetails(_eventId);
        
        if (eventObj != null)
        {
            textBoxTitle.Text = eventObj.title;
            textBoxTickets.Text = eventObj.totalTickets.ToString();
            textBoxPrice.Text = eventObj.price.ToString();
            
            comboBoxCategory.SelectedItem = eventObj.category;
            comboBoxDuration.SelectedItem = eventObj.durationMinutes;
            dateTimePicker2.Value = eventObj.eventDate;
            comboBoxVenue.SelectedValue = eventObj.venueId;

            string loadedTime = eventObj.eventTime.ToString(@"hh\:mm");
            if (!comboBoxTime.Items.Contains(loadedTime))
            {
                comboBoxTime.Items.Add(loadedTime);
            }
            comboBoxTime.SelectedItem = loadedTime;
        }
    }




    // Closes the Edit Event form without saving changes
    private void button2_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    // Validates inputs and submits the updated event details
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

        var organiser = (Organiser)GlobalManager.CurrentUser!;
        var result = organiser.updateEvent(
            _eventId, title, comboBoxCategory.SelectedItem!.ToString()!, totalTickets, ticketPrice,
            venueId, dateTimePicker2.Value.ToString("yyyy-MM-dd"), time, duration, organiser.id
        );

        MessageBox.Show(result.message);
        
        if (result.success)
        {
            this.Close();
        }
    }
}