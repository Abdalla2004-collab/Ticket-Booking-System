using MySql.Data.MySqlClient;

namespace LMS.Models;

public class Organiser : User
{
    public Organiser()
    {
        role = "Organiser";
    }

    public override Form getDashboard()
    {
        return new OrganiserDashboard();
    }

    public List<Events> getEvents()
    {
        var events = new List<Events>();

        using (MySqlConnection connection = GlobalManager.GetConnection())
        {
            connection.Open();

            string query = @"SELECT e.eventId, e.title, e.category, e.eventDate,
                                    e.eventTime, e.totalTickets, e.price, e.status,
                                    v.name AS venueName
                             FROM events e
                             JOIN venues v ON e.venueId = v.venueId
                             WHERE e.organiserId = @organiserId
                             ORDER BY e.eventDate ASC";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@organiserId", id);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        events.Add(new Events
                        {
                            eventId      = Convert.ToInt32(reader["eventId"]),
                            title        = reader["title"].ToString()!,
                            category     = reader["category"].ToString()!,
                            eventDate    = Convert.ToDateTime(reader["eventDate"]),
                            eventTime    = TimeSpan.Parse(reader["eventTime"].ToString()!),
                            totalTickets = Convert.ToInt32(reader["totalTickets"]),
                            price        = Convert.ToDecimal(reader["price"]),
                            status       = reader["status"].ToString()!,
                            venueName    = reader["venueName"].ToString()!
                        });
                    }
                }
            }
        }

        return events;
    }
}