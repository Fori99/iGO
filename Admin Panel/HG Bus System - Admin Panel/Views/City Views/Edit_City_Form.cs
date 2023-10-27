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

namespace HG_Bus_System___Admin_Panel.Views.City_Views
{
    public partial class Edit_City_Form : Form
    {
        public Edit_City_Form()
        {
            InitializeComponent();
            id_textBox.Text = Cities_UC.city_ID;
            name_textBox.Text = Cities_UC.city_name;
        }

        private void edit_button_Click(object sender, EventArgs e)
        {
            City_Functions cf = new City_Functions();
            cf.update_city(int.Parse(id_textBox.Text), name_textBox.Text);
            this.Close();
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            City_Functions cf = new City_Functions();
            cf.delete_city(int.Parse(id_textBox.Text));
            this.Close();
        }
    }
}
