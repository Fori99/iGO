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
    public partial class Reservations : ContentPage
    {
        public Reservations()
        {
            InitializeComponent();
            search_travels();
        }

        private void search_travels()
        {
            try
            {
                var travels = new List<Show_Booked> { };

                string querry = "SELECT c.Name, r.Seat_Nr " +
                    "FROM reservations r " +
                    "INNER JOIN client_users c on r.Client_ID = c.ID " +
                    "WHERE r.Travel_ID = "+Travel_Instance.id+"";

                MySqlConnection conn = new MySqlConnection(MySql.connection_string);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(querry, conn);
                cmd.Connection = conn;

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Show_Booked t = new Show_Booked();
                        t.Name = dr[0].ToString();
                        t.Seat = int.Parse(dr[1].ToString());
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
    }
}