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
    public partial class Add_Route_Form : Form
    {
        public Add_Route_Form()
        {
            InitializeComponent();
            show_cities();
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

        private void add_button_Click(object sender, EventArgs e)
        {
            int start_City_id = ((Id_Name)start_city_comboBox.SelectedItem).ID;
            int destination_city_id = ((Id_Name)destination_city_comboBox.SelectedItem).ID;
            int price = int.Parse(price_textBox.Text);

            Route_Functions rf = new Route_Functions();
            rf.add_route(start_City_id, destination_city_id, price);
            this.Close();
        }

        private void start_city_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void destination_city_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void price_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
    }
}
