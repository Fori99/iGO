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
    public partial class Add_City_Form : Form
    {
        public Add_City_Form()
        {
            InitializeComponent();
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            City_Functions cf = new City_Functions();
            cf.add_city(name_textBox.Text);
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
