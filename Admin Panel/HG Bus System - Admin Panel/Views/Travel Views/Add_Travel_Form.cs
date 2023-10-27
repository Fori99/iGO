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

namespace HG_Bus_System___Admin_Panel.Views.Travel_Views
{
    public partial class Add_Travel_Form : Form
    {
        public Add_Travel_Form()
        {
            InitializeComponent();
            show_drivers();
            show_busses();
            show_routes();
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

        private void add_button_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string time = dateTimePicker2.Value.ToString("HH:mm:ss");
            int driver_id = ((Id_Name)driver_comboBox.SelectedItem).ID;
            int bus_id = ((Id_Name)bus_comboBox.SelectedItem).ID;
            int route_id = ((Id_Name)route_comboBox.SelectedItem).ID;

            Travel_Functions tf = new Travel_Functions();
            tf.add_travel(date, time, driver_id.ToString(), bus_id.ToString(), route_id.ToString());
            this.Close();
        }
    }
}
