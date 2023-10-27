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
    class Route_Functions
    {
        public static string connestion_string = MySql_Connection_String.ConnectionString;
        public static MySqlConnection conn = new MySqlConnection(connestion_string);

        public void add_route(int start_city_id, int destination_city_id, int price)
        {
            try
            {
                string querry = "INSERT INTO routes (Start_City_ID, Destination_City_ID, Price)" +
                    "VALUES("+start_city_id+", "+destination_city_id+", "+price+")";

                conn.Open();

                MySqlCommand cmd = new MySqlCommand(querry, conn);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Route has been added!");

                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
                conn.Close();
            }
        }

        public static List<Routes> get_routes()
        {
            try
            {
                List<Routes> list_routes = new List<Routes>();

                string querry = "SELECT r.ID, c1.Name, c2.Name, r.Price FROM routes r INNER JOIN cities c1 on r.Start_City_ID = c1.ID INNER JOIN cities c2 on r.Destination_City_ID = c2.ID";

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(querry, conn);
                cmd.Connection = conn;

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Routes r = new Routes();
                        r.ID = int.Parse(dr[0].ToString());
                        r.Start_City_Name = dr[1].ToString();
                        r.Destination_City_Name = dr[2].ToString();
                        r.Price = int.Parse(dr[3].ToString());
                        list_routes.Add(r);
                    }
                    conn.Close();
                    //MessageBox.Show("done");
                    return list_routes;
                }
                else
                {
                    MessageBox.Show("There are no routes in database.");
                    conn.Close();
                    return list_routes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                List<Routes> list_routes = null;
                return list_routes;
            }
        }

        public void update_route(int id, int start_city_id, int destination_city_id, int price)
        {
            try
            {
                string querry = "UPDATE routes SET Start_City_ID = "+start_city_id+", " +
                    "Destination_City_ID = "+destination_city_id+", " +
                    "Price = "+price+" " +
                    "WHERE ID = "+id+"";

                conn.Open();

                MySqlCommand cmd = new MySqlCommand(querry, conn);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Route has been updated!");

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                conn.Close();
            }
        }

        public void delete_route(int id)
        {
            try
            {
                string querry = "DELETE FROM routes WHERE ID = " + id + ";";

                conn.Open();

                MySqlCommand cmd = new MySqlCommand(querry, conn);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Route has been deleted!");

                conn.Close();
            }
            catch (MySqlException ex)
            {
                if ((ex.Source == "MySql.Data") && (ex.Number == 1451))
                {
                    MessageBox.Show("This route can't be deleted!");
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
