using HG_Bus_System___Admin_Panel.MySql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HG_Bus_System___Admin_Panel.Views.Driver_Views
{
    public partial class Edit_Driver_Form : Form
    {        
        public Edit_Driver_Form()
        {
            InitializeComponent();
            id_textBox.Text = Driver_Uc.id;
            name_textBox.Text = Driver_Uc.name;
            lastname_textBox.Text = Driver_Uc.lastname;
            birthday_dateTimePicker.Value = DateTime.ParseExact(Driver_Uc.birthday, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            email_textBox.Text = Driver_Uc.email;
        }

        private void edit_button_Click(object sender, EventArgs e)
        {
            Driver_Functions df = new Driver_Functions();
            df.update_driver(id_textBox.Text, name_textBox.Text, lastname_textBox.Text, birthday_dateTimePicker.Value.ToString("yyyy-MM-dd"), email_textBox.Text);
            this.Close();
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            Driver_Functions df = new Driver_Functions();
            df.delete_driver(id_textBox.Text);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            New_Password_Form new_Password_Form = new New_Password_Form();
            new_Password_Form.Show();
        }
    }
}
