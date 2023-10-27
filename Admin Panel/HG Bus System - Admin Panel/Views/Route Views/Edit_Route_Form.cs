using HG_Bus_System___Admin_Panel.Models;
using HG_Bus_System___Admin_Panel.MySql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HG_Bus_System___Admin_Panel.Views.Route_Views
{
    public partial class Edit_Route_Form : Form
    {
        public Edit_Route_Form()
        {
            InitializeComponent();
            show_cities();
            id_textBox.Text = Route_Uc.route_ID;
            price_textBox.Text = Route_Uc.price;
           
            foreach (Id_Name item in start_city_comboBox.Items)
            {
                if (item.Name == Route_Uc.start_city)
                {
                    start_city_comboBox.SelectedItem = item;
                    break;
                }
            }

            foreach (Id_Name item in destination_city_comboBox.Items)
            {
                if (item.Name == Route_Uc.destination_city)
                {
                    destination_city_comboBox.SelectedItem = item;
                    break;
                }
            }

        }

        public void show_cities()
        {
            List<Cities> list_cities = new List<Cities>();
            list_cities = City_Functions.get_cities();

            if (list_cities != null)
            {
                foreach (Cities c in list_cities)
                {
                    start_city_comboBox.Items.Add(new Id_Name(c.ID, c.Name));
                    destination_city_comboBox.Items.Add(new Id_Name(c.ID, c.Name));
                }
            }
        }

        private void edit_button_Click(object sender, EventArgs e)
        {
            int id = int.Parse(id_textBox.Text);
            int start_City_id = ((Id_Name)start_city_comboBox.SelectedItem).ID;
            int destination_city_id = ((Id_Name)destination_city_comboBox.SelectedItem).ID;
            int price = int.Parse(price_textBox.Text);

            Route_Functions rf = new Route_Functions();
            rf.update_route(id, start_City_id, destination_city_id, price);
            this.Close();
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            int id = int.Parse(id_textBox.Text);

            Route_Functions rf = new Route_Functions();
            rf.delete_route(id);
            this.Close();
        }
    }
}
