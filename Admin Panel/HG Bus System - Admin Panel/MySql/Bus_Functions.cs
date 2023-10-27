using HG_Bus_System___Admin_Panel.Models;
using HG_Bus_System___Admin_Panel.Views.Bus_Views;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HG_Bus_System___Admin_Panel.MySql
{
    class Bus_Functions
    {
        public static string connestion_string = MySql_Connection_String.ConnectionString;
        public static MySqlConnection conn = new MySqlConnection(connestion_string);

        public static List<Busses> get_busses()
        {
            try
            {
                List<Busses> list_busses = new List<Busses>();

                string querry = "SELECT ID, Manufacturer, Model, Nr_of_Seats FROM busses";

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(querry, conn);
                cmd.Connection = conn;

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Busses b = new Busses();
                        b.ID = int.Parse(dr[0].ToString());
                        b.Manufacturer = dr[1].ToString();
                        b.Model = dr[2].ToString();
                        b.Seats_Nr = int.Parse(dr[3].ToString());
                        list_busses.Add(b);
                    }
                    conn.Close();
                    //MessageBox.Show("done");
                    return list_busses;
                }
                else
                {
                    MessageBox.Show("There are no busses in database.");
                    conn.Close();
                    return list_busses;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                List<Busses> list_busses = null;
                return list_busses;
            }
        }

        public static Image get_bus_image(string id)
        {
            try
            {
                Image image = null;
                string querry = "SELECT Image FROM busses WHERE ID = "+id;

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(querry, conn);
                cmd.Connection = conn;

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        byte[] imageData = (byte[])dr[0];
                        MemoryStream memoryStream = new MemoryStream(imageData);
                        image = Image.FromStream(memoryStream);                        
                    }
                    conn.Close();
                    return image;
                }
                else
                {                   
                    conn.Close();
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                conn.Close();
                return null;
            }
        }

        public void add_bus(string manufacturer, string model, string seats, byte[] imageBytes)
        {
            try
            {
                string query = "INSERT INTO busses (Manufacturer, Model, Nr_of_Seats, Image) VALUES (@Manufacturer, @Model, @Seats, @Image)";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Manufacturer", manufacturer);
                cmd.Parameters.AddWithValue("@Model", model);
                cmd.Parameters.AddWithValue("@Seats", seats);
                cmd.Parameters.AddWithValue("@Image", imageBytes);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Bus has been added!");

                conn.Close();
            }
            catch (MySqlException ex)
            {
                if ((ex.Source == "MySql.Data") && (ex.Number == 1062))
                {
                    MessageBox.Show("This bus alwready exists.");
                }
                else
                {
                    MessageBox.Show(ex.ToString());
                }
                conn.Close();
            }
        }

        public void update_bus(string id, string manufacturer, string model, string seats, byte[] imageBytes)
        {
            try
            {
                string query = "UPDATE busses SET Manufacturer = @Manufacturer, Model = @Model, Nr_of_Seats = @Seats, Image = @Image WHERE ID = @ID";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Manufacturer", manufacturer);
                cmd.Parameters.AddWithValue("@Model", model);
                cmd.Parameters.AddWithValue("@Seats", seats);
                cmd.Parameters.AddWithValue("@Image", imageBytes);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Bus has been updated!");

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                conn.Close();
            }
        }

        public void delete_bus(string id)
        {
            try
            {
                string querry = "DELETE FROM busses WHERE ID = " + id + ";";

                conn.Open();

                MySqlCommand cmd = new MySqlCommand(querry, conn);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Bus has been deleted!");

                conn.Close();
            }
            catch (MySqlException ex)
            {
                if ((ex.Source == "MySql.Data") && (ex.Number == 1451))
                {
                    MessageBox.Show("This bus can't be deleted!");
                }
                else
                {
                    MessageBox.Show(ex.ToString());
                }
                conn.Close();
            }
        }
    }
}
