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
    internal class Travel_Functions
    {
        public static string connestion_string = MySql_Connection_String.ConnectionString;
        public static MySqlConnection conn = new MySqlConnection(connestion_string);

        public static List<Travels> get_travels()
        {
            try
            {
                List<Travels> list_travels = new List<Travels>();

                string querry = "SELECT t.ID, t.Start_Date, t.Start_Time, bd.Name, CONCAT(b.Manufacturer, \" \", b.Model) AS Bus, CONCAT(c1.Name, \" - \", c2.Name) " +
                    "FROM travels t " +
                    "INNER JOIN bus_drivers bd on t.Bus_Driver_ID = bd.ID " +
                    "INNER JOIN busses b on t.Bus_ID = b.ID " +
                    "INNER JOIN routes r on t.Route_ID = r.ID " +
                    "INNER JOIN cities c1 on r.Start_City_ID = c1.ID " +
                    "INNER JOIN cities c2 on r.Destination_City_ID = c2.ID";

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(querry, conn);
                cmd.Connection = conn;

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Travels t = new Travels();
                        t.ID = int.Parse(dr[0].ToString());
                        t.Start_Date = DateTime.Parse(dr[1].ToString());
                        t.Start_Time = DateTime.Parse(dr[2].ToString());
                        t.Bus_Driver = dr[3].ToString();
                        t.Bus = dr[4].ToString();
                        t.Route = dr[5].ToString();
                        list_travels.Add(t);
                    }
                    conn.Close();
                    return list_travels;
                }
                else
                {
                    MessageBox.Show("There are no travels in database.");
                    conn.Close();
                    return list_travels;
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.ToString());
                List<Travels> list_travels = null;
                return list_travels;
            }
        }

        public static List<Travel_Info> get_bus_drivers()
        {
            try
            {
                List<Travel_Info> list = new List<Travel_Info>();

                string querry = "SELECT ID, Name FROM bus_drivers";

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(querry, conn);
                cmd.Connection = conn;

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Travel_Info ti = new Travel_Info();
                        ti.ID = int.Parse(dr[0].ToString());
                        ti.Name = dr[1].ToString();
                       
                        list.Add(ti);
                    }
                    conn.Close();
                    return list;
                }
                else
                {                    
                    conn.Close();
                    return list;
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.ToString());
                List<Travel_Info> list = null;
                return list;
            }
        }

        public static List<Travel_Info> get_busses()
        {
            try
            {
                List<Travel_Info> list = new List<Travel_Info>();

                string querry = "SELECT ID, CONCAT(Manufacturer, \" \", Model) FROM busses";

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(querry, conn);
                cmd.Connection = conn;

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Travel_Info ti = new Travel_Info();
                        ti.ID = int.Parse(dr[0].ToString());
                        ti.Name = dr[1].ToString();

                        list.Add(ti);
                    }
                    conn.Close();
                    return list;
                }
                else
                {
                    conn.Close();
                    return list;
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.ToString());
                List<Travel_Info> list = null;
                return list;
            }
        }

        public static List<Travel_Info> get_routes()
        {
            try
            {
                List<Travel_Info> list = new List<Travel_Info>();

                string querry = "SELECT r.ID, CONCAT(c1.Name, \" - \", c2.Name) " +
                    "FROM routes r " +
                    "INNER JOIN cities c1 on r.Start_City_ID = c1.ID " +
                    "INNER JOIN cities c2 on r.Destination_City_ID = c2.ID";

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(querry, conn);
                cmd.Connection = conn;

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Travel_Info ti = new Travel_Info();
                        ti.ID = int.Parse(dr[0].ToString());
                        ti.Name = dr[1].ToString();

                        list.Add(ti);
                    }
                    conn.Close();
                    return list;
                }
                else
                {
                    conn.Close();
                    return list;
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.ToString());
                List<Travel_Info> list = null;
                return list;
            }
        }

        public void update_traves(string id, string date, string time, string driver_id, string bus_id, string route_id)
        {
            try
            {
                string querry = "UPDATE travels SET Start_Date = '"+date+"', Start_Time = '"+time+"', Bus_Driver_ID = "+driver_id+", Bus_ID = "+bus_id+", Route_ID = "+route_id+" WHERE ID = "+id+";";

                conn.Open();

                MySqlCommand cmd = new MySqlCommand(querry, conn);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Travel has been updated!");

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                conn.Close();
            }
        }

        public void delete_travel(string id)
        {
            try
            {
                string querry = "DELETE FROM travels WHERE ID = " + id + ";";

                conn.Open();

                MySqlCommand cmd = new MySqlCommand(querry, conn);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Travel has been deleted!");

                conn.Close();
            }
            catch (MySqlException ex)
            {
                if ((ex.Source == "MySql.Data") && (ex.Number == 1451))
                {
                    MessageBox.Show("This travel can't be deleted!");
                }
                else
                {
                    MessageBox.Show(ex.ToString());
                }
                conn.Close();
            }
        }

        public void add_travel(string date, string time, string driver_id, string bus_id, string route_id)
        {
            try
            {
                string querry = "INSERT INTO travels (Start_Date, Start_Time, Bus_Driver_ID, Bus_ID, Route_ID) VALUES ('"+date+"', '"+time+"', "+driver_id+", "+bus_id+", "+route_id+");";

                conn.Open();

                MySqlCommand cmd = new MySqlCommand(querry, conn);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Travel has been added!");

                conn.Close();
            }
            catch (MySqlException ex)
            {
                if ((ex.Source == "MySql.Data") && (ex.Number == 1062))
                {
                    MessageBox.Show("This travel alwready exists.");
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
