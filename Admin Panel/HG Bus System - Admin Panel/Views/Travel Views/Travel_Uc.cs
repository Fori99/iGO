using HG_Bus_System___Admin_Panel.Models;
using HG_Bus_System___Admin_Panel.MySql;
using HG_Bus_System___Admin_Panel.Views.City_Views;
using HG_Bus_System___Admin_Panel.Views.Route_Views;
using MySqlX.XDevAPI.Relational;
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
    public partial class Travel_Uc : UserControl
    {
        public static string id = "";
        public static string date = "";
        public static string time = "";
        public static string driver = "";
        public static string bus = "";
        public static string route = "";
        public Travel_Uc()
        {
            InitializeComponent();
            show_travels();
        }

        public void show_travels()
        {
            travels_dataGridView.Rows.Clear();
            travels_dataGridView.ClearSelection();

            List<Travels> list_travels = new List<Travels>();
            list_travels = Travel_Functions.get_travels();

            if (list_travels != null)
            {
                foreach (Travels t in list_travels)
                {
                    travels_dataGridView.Rows.Add(t.ID.ToString(), t.Start_Date.ToString("dd-MM-yyyy"), t.Start_Time.ToString("HH:mm"), t.Bus_Driver, t.Bus, t.Route);
                }
            }

            Cities_UC.AutosizeColumns(travels_dataGridView);
        }

        private void refresh_travels(object sender, FormClosedEventArgs e)
        {
            show_travels();
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            Add_Travel_Form add_Travel_Form = new Add_Travel_Form();
            add_Travel_Form.FormClosed += refresh_travels;
            add_Travel_Form.Show();
        }

        private void travels_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in travels_dataGridView.SelectedRows)
            {
                id = (row.Cells[0].Value.ToString());
                date = (row.Cells[1].Value.ToString());
                time = (row.Cells[2].Value.ToString());
                driver = (row.Cells[3].Value.ToString());
                bus = (row.Cells[4].Value.ToString());
                route = (row.Cells[5].Value.ToString());
            }
            Edit_Travel_Form edit_Travel_Form = new Edit_Travel_Form();
            edit_Travel_Form.FormClosed += refresh_travels;
            edit_Travel_Form.Show();
        }
    }
}
