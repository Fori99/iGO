using System;
using System.Windows.Forms;
using System.IO;
using Dropbox.Api;
using Dropbox.Api.Files;
using System.Threading.Tasks;
using HG_Bus_System___Admin_Panel.Models;
using HG_Bus_System___Admin_Panel.MySql;
using System.Collections.Generic;
using HG_Bus_System___Admin_Panel.Views.City_Views;

namespace HG_Bus_System___Admin_Panel.Views.Bus_Views
{
    public partial class Bus_Uc : UserControl
    {
        public static string id;
        public static string manufacturer;
        public static string model;
        public static string seats;

        public Bus_Uc()
        {
            InitializeComponent();
            show_busses();
        }

        public void show_busses()
        {
            busses_dataGridView.Rows.Clear();
            busses_dataGridView.ClearSelection();

            List<Busses> list_busses = new List<Busses>();
            list_busses = Bus_Functions.get_busses();

            if (list_busses != null)
            {
                foreach (Busses b in list_busses)
                {
                    busses_dataGridView.Rows.Add(b.ID.ToString(), b.Manufacturer, b.Model, b.Seats_Nr.ToString());
                }
            }

            Cities_UC.AutosizeColumns(busses_dataGridView);
        }
               
        private void busses_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in busses_dataGridView.SelectedRows)
            {
                id = (row.Cells[0].Value.ToString());
                manufacturer = (row.Cells[1].Value.ToString());
                model = (row.Cells[2].Value.ToString());
                seats = (row.Cells[3].Value.ToString());

                Edit_Bus_Form edit_Bus_Form = new Edit_Bus_Form();
                edit_Bus_Form.Show();
                edit_Bus_Form.FormClosed += refresh_bus;
            }
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            Add_Bus_Form add_Bus_Form = new Add_Bus_Form();
            add_Bus_Form.FormClosed += refresh_bus;
            add_Bus_Form.Show();
        }

        private void refresh_bus(object sender, FormClosedEventArgs e)
        {
            show_busses();
        }
    }
}
