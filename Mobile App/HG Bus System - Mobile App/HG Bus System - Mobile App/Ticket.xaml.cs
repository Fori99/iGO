using HG_Bus_System___Mobile_App.Models;
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
    public partial class Ticket : ContentPage
    {
        public Ticket()
        {
            InitializeComponent();

            Label route_label = (Label)FindByName("route_label");
            route_label.Text = Travel_Instance.Route;

            Label time_label = (Label)FindByName("time_label");
            time_label.Text = Travel_Instance.Time;

            Label date_label = (Label)FindByName("date_label");
            date_label.Text = Travel_Instance.Date;

            Label name_label = (Label)FindByName("name_label");
            name_label.Text = Client_User.Name + " " + Client_User.Lastmane;

            string seats = "";
            foreach (int seatNum in Booking_Page.selectedSeatNumbers)
            {
                if (seats == "")
                {
                    seats = seatNum.ToString();
                }
                else
                {
                    seats = seats + ", " + seatNum.ToString();
                }
            }
            Label seats_label = (Label)FindByName("seats_label");
            seats_label.Text = seats;

            int price = Travel_Instance.Price * Booking_Page.selectedSeatNumbers.Count;
            Label price_label = (Label)FindByName("price_label");
            price_label.Text = Travel_Instance.Price.ToString() + "ALL x " + Booking_Page.selectedSeatNumbers.Count.ToString() + " = " + price.ToString() + "ALL" ;
        }
    }
}