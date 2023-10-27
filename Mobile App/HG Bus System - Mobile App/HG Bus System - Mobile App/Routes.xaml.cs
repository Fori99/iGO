using HG_Bus_System___Mobile_App.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HG_Bus_System___Mobile_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Routes : ContentPage
    {
        public Routes()
        {
            InitializeComponent();
            search_travels();
        }

        private void search_travels()
        {
            try
            {
                var travels = new List<Route_Model> { };

                string querry = "SELECT t.ID, t.Start_Date, t.Start_Time, CONCAT(b.Manufacturer, \" \", b.Model) AS Bus, CONCAT(c1.Name, \" - \", c2.Name) " +
                    "FROM travels t " +
                    "INNER JOIN busses b on t.Bus_ID = b.ID " +
                    "INNER JOIN routes r on t.Route_ID = r.ID " +
                    "INNER JOIN cities c1 on r.Start_City_ID = c1.ID " +
                    "INNER JOIN cities c2 on r.Destination_City_ID = c2.ID " +
                    "WHERE t.Bus_Driver_ID = " + Driver_User.Id + "";

                MySqlConnection conn = new MySqlConnection(MySql.connection_string);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(querry, conn);
                cmd.Connection = conn;

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Route_Model t = new Route_Model();
                        t.ID = int.Parse(dr[0].ToString());
                        DateTime date = DateTime.Parse(dr[1].ToString());
                        t.Start_Date = date.ToString("dd-MM-yyyy");
                        DateTime time = DateTime.Parse(dr[2].ToString());
                        t.Start_Time = time.ToString("HH:mm");
                        t.Bus = dr[3].ToString();
                        t.Route = dr[4].ToString();
                        travels.Add(t);
                    }
                    travelsListView.BindingContext = travels;
                    travelsListView.ItemsSource = travels;

                }
                conn.Close();
            }
            catch (Exception ex)
            {
                //DisplayAlert("Unexpected Error", ex.ToString(), "Try Again!");
                //conn.Close();              
            }
        }

        private async void OnTravelSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            var selectedTravel = (Route_Model)e.SelectedItem;
            Travel_Instance.id = selectedTravel.ID;


            var nextPage = new Reservations();
            await Navigation.PushAsync(nextPage);

            ((ListView)sender).SelectedItem = null;
        }
    }
}