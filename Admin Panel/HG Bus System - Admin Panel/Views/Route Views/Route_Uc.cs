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
    public partial class Route_Uc : UserControl
    {
        public static string route_ID = "";
        public static string start_city = "";
        public static string destination_city = "";
        public static string price = "";

        public Route_Uc()
        {
            InitializeComponent();
            show_routes();
        }

        public void show_routes()
        {
            route_dataGridView.Rows.Clear();
            route_dataGridView.ClearSelection();

            List<Routes> list_routes = new List<Routes>();
            list_routes = Route_Functions.get_routes();

            if (list_routes != null)
            {
                foreach (Routes r in list_routes)
                {
                    route_dataGridView.Rows.Add(r.ID.ToString(), r.Start_City_Name, r.Destination_City_Name, r.Price.ToString());
                }
            }

            Cities_UC.AutosizeColumns(route_dataGridView);
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            Add_Route_Form add_Route_Form = new Add_Route_Form();
            add_Route_Form.FormClosed += refresh_route;
            add_Route_Form.Show();
        }

        private void refresh_route(object sender, FormClosedEventArgs e)
        {
            show_routes();
        }

        private void route_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in route_dataGridView.SelectedRows)
            {
                route_ID = (row.Cells[0].Value.ToString());
                start_city = (row.Cells[1].Value.ToString());
                destination_city = (row.Cells[2].Value.ToString());
                price = (row.Cells[3].Value.ToString());

                Edit_Route_Form edit_Route_Form = new Edit_Route_Form();
                edit_Route_Form.FormClosed += refresh_route;
                edit_Route_Form.Show();
            }
        }
    }
}
