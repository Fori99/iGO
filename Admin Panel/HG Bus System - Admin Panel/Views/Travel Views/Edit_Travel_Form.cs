using Google.Protobuf;
using HG_Bus_System___Admin_Panel.Models;
using HG_Bus_System___Admin_Panel.MySql;
using HG_Bus_System___Admin_Panel.Views.Bus_Views;
using HG_Bus_System___Admin_Panel.Views.Driver_Views;
using HG_Bus_System___Admin_Panel.Views.Travel_Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HG_Bus_System___Admin_Panel.Views.Route_Views
{
    public partial class Edit_Travel_Form : Form
    {
        public Edit_Travel_Form()
        {
            InitializeComponent();
            show_drivers();
            show_busses();
            show_routes();

            id_textBox.Text = Travel_Uc.id;

            foreach (Id_Name item in driver_comboBox.Items)
            {
                if (item.Name == Travel_Uc.driver)
                {
                    driver_comboBox.SelectedItem = item;
                    break;
                }
            }

            foreach (Id_Name item in bus_comboBox.Items)
            {
                if (item.Name == Travel_Uc.bus)
                {
                    bus_comboBox.SelectedItem = item;
                    break;
                }
            }

            foreach (Id_Name item in route_comboBox.Items)
            {
                if (item.Name == Travel_Uc.route)
                {
                    route_comboBox.SelectedItem = item;
                    break;
                }
            }

            DateTime dateValue = DateTime.ParseExact(Travel_Uc.date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            dateTimePicker1.Value = dateValue;
                        
            DateTime timeValue = DateTime.ParseExact(Travel_Uc.time, "HH:mm", CultureInfo.InvariantCulture);
            dateTimePicker2.Value = timeValue;

        }

        public void show_drivers()
        {
            List<Travel_Info> list = new List<Travel_Info>();
            list = Travel_Functions.get_bus_drivers();

            if (list != null)
            {
                foreach (Travel_Info ti in list)
                {
                    driver_comboBox.Items.Add(new Id_Name(ti.ID, ti.Name));
                }
            }
        }

        public void show_busses()
        {
            List<Travel_Info> list = new List<Travel_Info>();
            list = Travel_Functions.get_busses();

            if (list != null)
            {
                foreach (Travel_Info ti in list)
                {
                    bus_comboBox.Items.Add(new Id_Name(ti.ID, ti.Name));
                }
            }
        }

        public void show_routes()
        {
            List<Travel_Info> list = new List<Travel_Info>();
            list = Travel_Functions.get_routes();

            if (list != null)
            {
                foreach (Travel_Info ti in list)
                {
                    route_comboBox.Items.Add(new Id_Name(ti.ID, ti.Name));
                }
            }
        }

        private void edit_button_Click(object sender, EventArgs e)
        {
            string id = id_textBox.Text;
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string time = dateTimePicker2.Value.ToString("HH:mm:ss");
            int driver_id = ((Id_Name)driver_comboBox.SelectedItem).ID;
            int bus_id = ((Id_Name)bus_comboBox.SelectedItem).ID;
            int route_id = ((Id_Name)route_comboBox.SelectedItem).ID;

            Travel_Functions tf = new Travel_Functions();
            tf.update_traves(id, date, time, driver_id.ToString(), bus_id.ToString(), route_id.ToString());
            this.Close();
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            Travel_Functions tf = new Travel_Functions();
            tf.delete_travel(id_textBox.Text);
            this.Close();
        }
    }
}
