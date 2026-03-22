using System;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace LMS;

public partial class AddEvents : Form
{

    public AddEvents()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        this.Hide();
        Homepage homepage = new Homepage();
        homepage.Show();
    }

    private void label1_Click(object sender, EventArgs e)
    {
    }

    private void label4_Click(object sender, EventArgs e)
    {
        
    }

    private void button2_Click(object sender, EventArgs e)
    {   
        
        string name = textBox1.Text.Trim();
        string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
        string time = dateTimePicker2.Value.ToString("HH:mm:ss");
        
        if(name.Length != 0){
            using (MySqlConnection connection = new MySqlConnection(DatabaseHelper.ConnectionString))
            {
                connection.Open();
                string query = "insert into events(title,date,time,organiser) values(@title,@date,@time,@organiser)";
                try
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@title", name);
                        command.Parameters.AddWithValue("@date", date);
                        command.Parameters.AddWithValue("@time", time);
                        command.Parameters.AddWithValue("@organiser", Session.fullname);
                        int result = command.ExecuteNonQuery();
                        
                        if (result > 0)
                        {
                            MessageBox.Show("Successfully Added Event by " + Session.fullname);
                            this.Hide();
                            Homepage homepage = new Homepage();
                            homepage.Show();
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    }
                }
                catch (MySqlException ex) when (ex.Number == 1062)
                {
                    MessageBox.Show("An event is already scheduled " +
                                    "for that date and time. " +
                                    "Please choose a different slot.");
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        
    }
}