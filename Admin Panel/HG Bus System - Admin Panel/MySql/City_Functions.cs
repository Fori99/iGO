using HG_Bus_System___Admin_Panel.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HG_Bus_System___Admin_Panel.MySql
{
    class City_Functions
    {
        public static string connestion_string = MySql_Connection_String.ConnectionString;
        public static MySqlConnection conn = new MySqlConnection(connestion_string);

        public static List<Cities> get_cities()
        {
            try
            {
                List<Cities> list_cities = new List<Cities>();

                string querry = "SELECT * FROM cities";

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(querry, conn);
                cmd.Connection = conn;

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Cities c = new Cities();                        
                        c.ID = int.Parse(dr[0].ToString());
                        c.Name = dr[1].ToString();
                        list_cities.Add(c);
                    }
                    conn.Close();
                    //MessageBox.Show("done");
                    return list_cities;
                }
                else
                {
                    MessageBox.Show("There are no cities in database.");
                    conn.Close();
                    return list_cities;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                List<Cities> list_cities = null;
                return list_cities;
            }
        }

        public void update_city(int id, string name)
        {
            try
            {
                string querry = "UPDATE cities SET Name = '" + name + "' WHERE ID = " + id + ";";

                conn.Open();

                MySqlCommand cmd = new MySqlCommand(querry, conn);

                cmd.ExecuteNonQuery();

                MessageBox.Show("City has been updated!");

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                conn.Close();
            }
        }

        public void delete_city(int id)
        {
            try
            {
                string querry = "DELETE FROM cities WHERE ID = " + id + ";";

                conn.Open();

                MySqlCommand cmd = new MySqlCommand(querry, conn);

                cmd.ExecuteNonQuery();

                MessageBox.Show("City has been deleted!");

                conn.Close();
            }
            catch (MySqlException ex)
            {
                if ((ex.Source == "MySql.Data") && (ex.Number == 1451))
                {
                    MessageBox.Show("This city can't be deleted!");
                }
                else
                {
                    MessageBox.Show(ex.ToString());
                }
                conn.Close();
            }
        }

        public void add_city(string name)
        {
            try
            {
                string querry = "INSERT INTO cities(Name) VALUES('" + name + "');";

                conn.Open();

                MySqlCommand cmd = new MySqlCommand(querry, conn);

                cmd.ExecuteNonQuery();

                MessageBox.Show("City has been added!");

                conn.Close();
            }
            catch (MySqlException ex)
            {
                if ((ex.Source == "MySql.Data") && (ex.Number == 1062))
                {
                    MessageBox.Show("This city alwready exists.");
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
