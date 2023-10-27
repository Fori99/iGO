using HG_Bus_System___Mobile_App.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HG_Bus_System___Mobile_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Booking_Page : ContentPage
    {

        private int selectedSeats = 0;
        private List<Booked_Seats> bookings = new List<Booked_Seats> { };
        public static List<int> selectedSeatNumbers = new List<int>();


        public Booking_Page()
        {
            InitializeComponent();
            Get_booked_seats();
            create_seates();

            Label route_label = (Label)FindByName("route_label");
            route_label.Text = Travel_Instance.Route;

            Label time_label = (Label)FindByName("time_label");
            time_label.Text = Travel_Instance.Time;

            Label date_label = (Label)FindByName("date_label");
            date_label.Text = Travel_Instance.Date;
        }

        public void create_seates()
        {
            int numSeats = Travel_Instance.Seats;

            int numRows = (int)Math.Ceiling((double)numSeats / 4);

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int seatNum = i * 4 + j + 1;
                    if (seatNum <= numSeats)
                    {
                        Button seatButton = new Button
                        {
                            Text = seatNum.ToString(),
                            HeightRequest = 50,
                            WidthRequest = 100,
                            HorizontalOptions = LayoutOptions.CenterAndExpand,
                            VerticalOptions = LayoutOptions.CenterAndExpand,
                            CornerRadius = 50
                        };

                        // Check if the seat is booked and set it as red and not clickable
                        if (bookings.Any(b => b.Id == seatNum))
                        {
                            seatButton.BackgroundColor = Color.Red;
                            seatButton.TextColor = Color.White;
                            seatButton.IsEnabled = false;
                        }
                        else
                        {
                            seatButton.Clicked += (sender, args) =>
                            {
                                Button clickedButton = (Button)sender;
                                if (clickedButton.BackgroundColor == Color.Blue)
                                {
                                    clickedButton.BackgroundColor = Color.Default;
                                    clickedButton.TextColor = Color.Default;
                                    selectedSeats--;
                                    selectedSeatNumbers.Remove(seatNum);
                                }
                                else if (selectedSeats < 5)
                                {
                                    clickedButton.BackgroundColor = Color.Blue;
                                    clickedButton.TextColor = Color.White;
                                    selectedSeats++;
                                    selectedSeatNumbers.Add(seatNum);
                                }
                                else
                                {
                                    DisplayAlert("Error", "You can't select more than 5 seats", "OK");
                                }
                            };
                        }

                        Grid.SetRow(seatButton, i);
                        Grid.SetColumn(seatButton, j + (j >= 2 ? 1 : 0));
                        mainGrid.Children.Add(seatButton);
                    }
                }
            }
        }

        public void Get_booked_seats()
        {
            try
            {
                string querry = "SELECT Seat_Nr FROM reservations WHERE Travel_ID = " + Travel_Instance.id + ";";

                MySqlConnection conn = new MySqlConnection(MySql.connection_string);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(querry, conn);
                cmd.Connection = conn;

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Booked_Seats b = new Booked_Seats();
                        b.Id = int.Parse(dr[0].ToString());
                        bookings.Add(b);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                //conn.Close();
            }
        }

        void BookSeatsEvent(object sender, EventArgs e)
        {
            foreach (int seatNum in selectedSeatNumbers)
            {
                try
                {
                    string querry = "INSERT INTO `reservations` (`ID`, `Client_ID`, `Travel_ID`, `Seat_Nr`) " +
                        "VALUES (NULL, '" + Client_User.Id + "', '" + Travel_Instance.id + "', '" + seatNum + "');";

                    MySqlConnection conn = new MySqlConnection(MySql.connection_string);
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(querry, conn);
                    cmd.Connection = conn;

                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
                catch (Exception ex)
                {
                    DisplayAlert("Error", ex.ToString(), "ok");
                    break;
                }
            }
            DisplayAlert("Succes", "Advance to your ticket details.", "Ok");
            var nextPage = new Ticket();
            Navigation.PushAsync(nextPage);

            string body = "<h1>Thank you for booking with us!</h1>";
            body += "<p>Here are the details of your booking:</p>";
            body += "<ul>";
            body += "<li><b>Name:</b> " + Client_User.Name + "</li>";
            body += "<li><b>Email:</b> " + Client_User.Email + "</li>";
            body += "<li><b>Selected Seats:</b> " + selectedSeats + "</li>";
            body += "<li><b>Total Price:</b> " + selectedSeats + " * " + Travel_Instance.Price + " = " + (selectedSeats * Travel_Instance.Price) + "</li>";
            body += "</ul>";
            body += "<p>We look forward to seeing you on your journey!</p>";

            //SendEmail(Client_User.Email, "Seat booking confirmation", body);

        }

        private void SendEmail(string toAddres, string subject, string body)
        {
            var fromAddress = new MailAddress("email@gmail.com", "Your Name");
            var toAddress = new MailAddress(toAddres);
            const string fromPassword = "password";
            const string smtpServer = "smtp.gmail.com";
            const int smtpPort = 587;

            var smtp = new SmtpClient
            {
                Host = smtpServer,
                Port = smtpPort,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            };

            smtp.Send(message);
        }

    }
}