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

namespace HG_Bus_System___Admin_Panel.Views.Driver_Views
{
    public partial class Add_Driver_Form : Form
    {
        public Add_Driver_Form()
        {
            InitializeComponent();
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            Driver_Functions df = new Driver_Functions();
            df.add_driver(name_textBox.Text, lastname_textBox.Text, birthday_dateTimePicker.Value.ToString("yyyy-MM-dd"), email_textBox.Text, pass_textBox.Text);
            this.Close();
        }
    }
}
