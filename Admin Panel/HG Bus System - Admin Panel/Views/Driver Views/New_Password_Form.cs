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
    public partial class New_Password_Form : Form
    {
        public New_Password_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Driver_Functions df = new Driver_Functions();
            df.update_driver_password(Driver_Uc.id, pass_textBox.Text);
            this.Close();
        }
    }
}
