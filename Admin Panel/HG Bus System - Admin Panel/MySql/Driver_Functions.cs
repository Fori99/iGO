using HG_Bus_System___Admin_Panel.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HG_Bus_System___Admin_Panel.MySql
{
    internal class Driver_Functions
    {
        public static string connestion_string = MySql_Connection_String.ConnectionString;
        public static MySqlConnection conn = new MySqlConnection(connestion_string);

        public static List<Drivers> get_drivers()
        {
            try
            {
                List<Drivers> list_drivers = new List<Drivers>();

                string querry = "SELECT * FROM bus_drivers";

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(querry, conn);
                cmd.Connection = conn;

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Drivers d = new Drivers();
                        d.ID = int.Parse(dr[0].ToString());
                        d.Name = dr[1].ToString();
                        d.Lastname = dr[2].ToString();
                        d.Birthday = DateTime.Parse(dr[3].ToString());
                        d.Email = dr[4].ToString();
                        list_drivers.Add(d);
                    }
                    conn.Close();
                    //MessageBox.Show("done");
                    return list_drivers;
                }
                else
                {
                    MessageBox.Show("There are no drivers in database.");
                    conn.Close();
                    return list_drivers;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                List<Drivers> list_drivers = null;
                return list_drivers;
            }
        }

        public void add_driver(string name, string lastname, string birthday, string email, string password)
        {
            try
            {
                string querry = "INSERT INTO bus_drivers (Name, Lastname, Birthday, Email, Pass) VALUES('"+name+"', '"+lastname+"', '"+birthday+"', '"+email+"', '"+password+"')";

                conn.Open();

                MySqlCommand cmd = new MySqlCommand(querry, conn);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Driver has been added!");

                conn.Close();
            }
            catch (MySqlException ex)
            {
                if ((ex.Source == "MySql.Data") && (ex.Number == 1062))
                {
                    MessageBox.Show("This driver alwready exists.");
                }
                else
                {
                    MessageBox.Show(ex.ToString());
                }
                conn.Close();
            }
        }

        public void update_driver(string id, string name, string lastname, string birthday, string email)
        {
            try
            {
                string querry = "UPDATE bus_drivers SET Name = '" + name + "', Lastname = '" + lastname + "', Birthday = '" + birthday + "', Email = '" + email + "' WHERE ID = " + id + ";";

                conn.Open();

                MySqlCommand cmd = new MySqlCommand(querry, conn);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Driver has been updated!");

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                conn.Close();
            }
        }

        public void update_driver_password(string id, string pass)
        {
            try
            {
                string querry = "UPDATE bus_drivers SET Pass = '" + pass + "' WHERE ID = " + id + ";";

                conn.Open();

                MySqlCommand cmd = new MySqlCommand(querry, conn);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Password changed succesfuly!");

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                conn.Close();
            }
        }

        public void delete_driver(string id)
        {
            try
            {
                string querry = "DELETE FROM bus_drivers WHERE ID = " + id + ";";

                conn.Open();

                MySqlCommand cmd = new MySqlCommand(querry, conn);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Driver has been deleted!");

                conn.Close();
            }
            catch (MySqlException ex)
            {
                if ((ex.Source == "MySql.Data") && (ex.Number == 1451))
                {
                    MessageBox.Show("This driver can't be deleted!");
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
