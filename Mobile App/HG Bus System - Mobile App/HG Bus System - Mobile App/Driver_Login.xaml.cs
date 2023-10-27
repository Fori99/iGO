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
    public partial class Driver_Login : ContentPage
    {
        public Driver_Login()
        {
            InitializeComponent();
        }

        void SingInProcedure(object sender, EventArgs e)
        {
            login(entry_username.Text.ToString(), entry_password.Text.ToString());
            entry_username.Text = "";
            entry_password.Text = "";
        }

        private async void login(string username, string pass)
        {
            try
            {
                //await DisplayAlert("Login Success", "Welcome Back " + username, "Next!");
                string login_querry = "SELECT * FROM bus_drivers WHERE Email = '" + username + "' and Pass = '" + pass + "';";

                MySqlConnection conn = new MySqlConnection(MySql.connection_string);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(login_querry, conn);
                cmd.Connection = conn;

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();

                    Driver_User.Id = int.Parse(dr[0].ToString());
                    Driver_User.Name = (dr[1].ToString());
                    Driver_User.Lastmane = dr[2].ToString();
                    Driver_User.Birthday = dr[3].ToString();
                    Driver_User.Email = username;

                    await DisplayAlert("Login Success", "Welcome Back " + Driver_User.Name, "Next!");

                    var nextPage = new Routes();
                    await Navigation.PushAsync(nextPage);
                }
                else
                {
                    await DisplayAlert("Login Failed", "Please Check Your Credentials", "Try Again!");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Unexpected Error", ex.ToString(), "Try Again!");
                //conn.Close();
            }
        }

        private void go_to_driver(object sender, EventArgs e)
        {
            DisplayAlert("New Account", "Call our admin team at +355 69 586 1375 to register as a driver and join our team. We look forward to hearing from you!", "Okay!");
        }
    }
}