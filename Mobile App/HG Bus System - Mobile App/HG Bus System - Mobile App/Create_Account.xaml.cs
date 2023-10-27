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

    public partial class Create_Account : ContentPage
    {
        public Create_Account()
        {
            InitializeComponent();
        }

        private async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            string name = NameEntry.Text;
            string lastName = LastNameEntry.Text;
            string birthday = BirthdayPicker.Date.ToString("yyyy-MM-dd");
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            sign_up(name, lastName, birthday, email, password);
        }

        private async void sign_up(string name, string lastName, string birthday, string email, string password)
        {
            try
            {
                string querry = "INSERT INTO `client_users` (`ID`, `Name`, `Lastname`, `Birthday`, `Email`, `Pass`) " +
                    "VALUES (NULL, '" + name + "', '" + lastName + "', '" + birthday + "', '" + email + "', '" + password + "');";

                MySqlConnection conn = new MySqlConnection(MySql.connection_string);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(querry, conn);
                cmd.Connection = conn;

                cmd.ExecuteNonQuery();
                conn.Close();

                //await DisplayAlert("Account Created!");

                var nextPage = new MainPage();
                await Navigation.PushAsync(nextPage);
            }
            catch (Exception ex)
            {
                //await DisplayAlert(ex.ToString());
            }
        }
    }
}