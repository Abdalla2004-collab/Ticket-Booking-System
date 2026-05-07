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
        try
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
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
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

    private void loadVenues()
    {
        try
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
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred loading venues: " + ex.Message);
        }
    }

    private void comboBoxVenue_SelectedIndexChanged(object? sender, EventArgs e)
    {
        try
        {
            if (comboBoxVenue.SelectedItem is Venue v)
            {
                textBoxTickets.Text = v.capacity.ToString();
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

    private void button2_Click(object sender, EventArgs e)
    {
        try
        {
            string title = textBoxTitle.Text.Trim();
            string category = comboBoxCategory.SelectedItem?.ToString() ?? "";
            string date = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            string tickets = textBoxTickets.Text.Trim();
            string price = textBoxPrice.Text.Trim();

            if (title.Length == 0 || tickets.Length == 0 || price.Length == 0 || comboBoxCategory.SelectedItem == null || comboBoxDuration.SelectedItem == null)
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

            TimeSpan selectedTime = TimeSpan.Parse(comboBoxTime.SelectedItem.ToString()!);
            if (selectedTime < TimeSpan.FromHours(8) || selectedTime > TimeSpan.FromHours(22))
            {
                MessageBox.Show("Events must be scheduled between 08:00 and 22:00.");
                return;
            }

            int duration = (int)comboBoxDuration.SelectedItem;
            var organiser = (Organiser)GlobalManager.CurrentUser!;
            var conflicts = organiser.getExistingEventsForVenue(venueId, date);
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

            string time = comboBoxTime.SelectedItem.ToString() + ":00";
            var result = organiser.addEvent(title, category, date, time, duration, totalTickets, ticketPrice, venueId, organiser.id);

            MessageBox.Show(result.message);
            
            if (result.success)
            {
                this.Hide();
                new OrganiserDashboard().Show();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void buttonBack_Click_1(object sender, EventArgs e)
    {
        try
        {
            this.Hide();
            new OrganiserDashboard().Show();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}