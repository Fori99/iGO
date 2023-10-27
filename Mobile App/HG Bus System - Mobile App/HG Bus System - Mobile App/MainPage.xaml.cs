using HG_Bus_System___Mobile_App.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HG_Bus_System___Mobile_App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            init();
        }

        void init()
        {
            /*BackgroundColor = Constants.backgroundColor;
            //label_username.TextColor = Constants.mainTextColor;
            //label_password.TextColor = Constants.mainTextColor;
            
            logoIcon.HeightRequest = Constants.loginIconHeigh;*/
            activitySpinner.IsVisible = false;

            entry_username.Completed += (s, e) => entry_password.Focus();
            entry_password.Completed += (s, e) => button_signin.Focus();
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
                string login_querry = "SELECT * FROM client_users WHERE Email = '" + username + "' and Pass = '" + pass + "';";

                MySqlConnection conn = new MySqlConnection(MySql.connection_string);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(login_querry, conn);
                cmd.Connection = conn;

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();

                    Client_User.Id = int.Parse(dr[0].ToString());
                    Client_User.Name = (dr[1].ToString());
                    Client_User.Lastmane = dr[2].ToString();
                    Client_User.Birthday = dr[3].ToString();
                    Client_User.Email = username;

                    await DisplayAlert("Login Success", "Welcome Back " + Client_User.Name, "Next!");
                    var nextPage = new Travels();
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
            Navigation.PushAsync(new Driver_Login());
        }

        private void go_to_signup(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Create_Account());
        }
    }
}
