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

    private void EditEvent_Load(object sender, EventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message);
        }
    }

    private void refreshAvailableTimes(object? sender, EventArgs e)
    {
        try
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

                if (dateTimePicker2.Value.Date == DateTime.Today && currentSlot <= DateTime.Now.TimeOfDay)
                {
                    currentSlot = currentSlot.Add(TimeSpan.FromMinutes(30));
                    continue;
                }

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
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message);
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
        try
        {
            var venues = GlobalManager.GetAllVenues();
            comboBoxVenue.DisplayMember = "name";
            comboBoxVenue.ValueMember = "venueId";
            comboBoxVenue.DataSource = venues;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void loadEventDetails()
    {
        try
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
                
                if (eventObj.eventDate < DateTime.Today)
                    dateTimePicker2.MinDate = eventObj.eventDate;
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
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred loading event details: " + ex.Message);
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            string title = textBoxTitle.Text.Trim();
            string tickets = textBoxTickets.Text.Trim();
            string price = textBoxPrice.Text.Trim();

            if (title.Length == 0 || tickets.Length == 0 || price.Length == 0 || comboBoxCategory.SelectedItem == null || comboBoxDuration.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
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

            TimeSpan selectedTime = TimeSpan.Parse(comboBoxTime.SelectedItem.ToString()!);
            if (selectedTime < TimeSpan.FromHours(8) || selectedTime > TimeSpan.FromHours(22))
            {
                MessageBox.Show("Events must be scheduled between 08:00 and 22:00.");
                return;
            }

            var organiser = (Organiser)GlobalManager.CurrentUser!;
            int duration = (int)comboBoxDuration.SelectedItem;

            var conflicts = organiser.getExistingEventsForVenue(venueId, dateTimePicker2.Value.ToString("yyyy-MM-dd"), _eventId);
            TimeSpan selectedEnd = selectedTime.Add(TimeSpan.FromMinutes(duration));
            foreach (var conflict in conflicts)
            {
                TimeSpan confEnd = conflict.start.Add(TimeSpan.FromMinutes(conflict.dur));
                if (selectedTime < confEnd && selectedEnd > conflict.start)
                {
                    MessageBox.Show("This time slot conflicts with another event.");
                    return;
                }
            }

            if (dateTimePicker2.Value.Date == DateTime.Today)
            {
                if (selectedTime <= DateTime.Now.TimeOfDay)
                {
                    MessageBox.Show("The selected time has already passed today.");
                    return;
                }
            }

            if (dateTimePicker2.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Event date cannot be in the past.");
                return;
            }

            string time = comboBoxTime.SelectedItem.ToString() + ":00";

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
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}