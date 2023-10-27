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
    public partial class Travels : ContentPage
    {
        public Travels()
        {
            InitializeComponent();
            get_all_cities();
        }

        private async void get_all_cities()
        {
            try
            {
                var cities = new List<City> { };

                string querry = "SELECT r.ID, CONCAT(c1.Name, \" - \", c2.Name) " +
                    "FROM routes r " +
                    "INNER JOIN cities c1 on r.Start_City_ID = c1.ID " +
                    "INNER JOIN cities c2 on r.Destination_City_ID = c2.ID";

                MySqlConnection conn = new MySqlConnection(MySql.connection_string);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(querry, conn);
                cmd.Connection = conn;

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        City c = new City();
                        c.Id = int.Parse(dr[0].ToString());
                        c.Name = dr[1].ToString();
                        cities.Add(c);
                    }
                }
                conn.Close();
                BindingContext = cities;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Unexpected Error", ex.ToString(), "Try Again!");
                //conn.Close();
            }
        }

        private async void search_travels(object sender, EventArgs e)
        {
            int startCityId = ((City)startCityPicker.SelectedItem)?.Id ?? 0;
            Travel_Instance.Route = ((City)startCityPicker.SelectedItem)?.Name;

            string date = DatePicker.Date.ToString("yyyy-MM-dd");
            Travel_Instance.Date = date;

            try
            {
                travelsListView.ItemsSource = null;
                var travels = new List<Travels_Model> { };

                string querry = "SELECT t.ID, t.Start_Time, r.Price, b.Nr_of_Seats " +
                    "FROM travels t " +
                    "INNER JOIN routes r on t.Route_ID = r.ID " +
                    "INNER JOIN busses b on t.Bus_ID = b.ID " +
                    "WHERE r.ID = " + startCityId + " AND t.Start_Date = '" + date + "'";

                MySqlConnection conn = new MySqlConnection(MySql.connection_string);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(querry, conn);
                cmd.Connection = conn;

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Travels_Model t = new Travels_Model();
                        t.Id = int.Parse(dr[0].ToString());
                        t.Time = dr[1].ToString();
                        t.Price = dr[2].ToString();
                        t.Seats = dr[3].ToString();
                        travels.Add(t);
                    }                    
                    travelsListView.BindingContext = travels;
                    travelsListView.ItemsSource = travels;
                }
                conn.Close();
                BindingContext = travels;
                get_all_cities();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Unexpected Error", ex.ToString(), "Try Again!");
                //conn.Close();
                get_all_cities();
            }
        }

        private async void OnTravelSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            var selectedTravel = (Travels_Model)e.SelectedItem;
            Travel_Instance.id = selectedTravel.Id;
            Travel_Instance.Seats = int.Parse(selectedTravel.Seats);
            Travel_Instance.Price = int.Parse(selectedTravel.Price);
            Travel_Instance.Time = selectedTravel.Time;

            var nextPage = new Booking_Page();
            await Navigation.PushAsync(nextPage);

            ((ListView)sender).SelectedItem = null;
        }
    }
}