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

namespace HG_Bus_System___Admin_Panel
{
    public partial class Cities_UC : UserControl
    {
        public static string city_ID = "";
        public static string city_name = "";

        public Cities_UC()
        {
            InitializeComponent();
            show_cities();                       
        }

        public void show_cities()
        {
            dataGridView_cities.Rows.Clear();
            dataGridView_cities.ClearSelection();

            List<Cities> list_cities = new List<Cities>();
            list_cities = City_Functions.get_cities();

            if (list_cities != null)
            {
                foreach (Cities c in list_cities)
                {
                    dataGridView_cities.Rows.Add(c.ID.ToString(), c.Name.ToString());
                }
            }

            AutosizeColumns(dataGridView_cities);
        }

        private void add_city_button_Click(object sender, EventArgs e)
        {
            Add_City_Form add_City_Form = new Add_City_Form();
            add_City_Form.FormClosed += refresh_city;
            add_City_Form.Show();
        }

        private void refresh_city(object sender, FormClosedEventArgs e)
        {
            show_cities();
        }

        private void dataGridView_cities_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView_cities.SelectedRows)
            {
                city_ID = (row.Cells[0].Value.ToString());
                city_name = (row.Cells[1].Value.ToString());

                Edit_City_Form edit_City_Form = new Edit_City_Form();
                edit_City_Form.FormClosed += refresh_city;
                edit_City_Form.Show();
            }
        }

        public static void AutosizeColumns(DataGridView grid)
        {
            grid.SuspendLayout();

            int width = 0;

            for (int i = 0; i < grid.Columns.Count; i++)
            {
                grid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                width += grid.Columns[i].Width;
            }

            if (width > 775)
            {
                float scale = 775.0f / width;
                for (int i = 0; i < grid.Columns.Count; i++)
                {
                    grid.Columns[i].Width = (int)(grid.Columns[i].Width * scale);
                }
            }

            grid.ResumeLayout();
        }
    }
}
