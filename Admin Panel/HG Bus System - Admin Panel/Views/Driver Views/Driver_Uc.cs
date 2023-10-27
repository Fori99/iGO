using HG_Bus_System___Admin_Panel.Models;
using HG_Bus_System___Admin_Panel.MySql;
using HG_Bus_System___Admin_Panel.Views.City_Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HG_Bus_System___Admin_Panel.Views.Driver_Views
{
    public partial class Driver_Uc : UserControl
    {
        public static string id = "";
        public static string name = "";
        public static string lastname = "";
        public static string birthday = "";
        public static string email = "";
        public static string password = "";

        public Driver_Uc()
        {
            InitializeComponent();
            show_drivers();
        }

        public void show_drivers()
        {
            driver_dataGridView.Rows.Clear();
            driver_dataGridView.ClearSelection();

            List<Drivers> list_drivers = new List<Drivers>();
            list_drivers = Driver_Functions.get_drivers();

            if (list_drivers != null)
            {
                foreach (Drivers d in list_drivers)
                {
                    driver_dataGridView.Rows.Add(d.ID.ToString(), d.Name, d.Lastname, d.Birthday.ToString("dd-MM-yyyy"), d.Email);
                }
            }
            Cities_UC.AutosizeColumns(driver_dataGridView);
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            Add_Driver_Form add_Driver_Form = new Add_Driver_Form();
            add_Driver_Form.FormClosed += refresh_driver;
            add_Driver_Form.Show();
        }

        private void refresh_driver(object sender, FormClosedEventArgs e)
        {
            show_drivers();
        }

        private void driver_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in driver_dataGridView.SelectedRows)
            {
                id = (row.Cells[0].Value.ToString());
                name = (row.Cells[1].Value.ToString());
                lastname = (row.Cells[2].Value.ToString());
                birthday = (row.Cells[3].Value.ToString());
                email = (row.Cells[4].Value.ToString());

                Edit_Driver_Form edit_Driver_Form = new Edit_Driver_Form();
                edit_Driver_Form.FormClosed += refresh_driver;
                edit_Driver_Form.Show();
            }
        }
    }
}
