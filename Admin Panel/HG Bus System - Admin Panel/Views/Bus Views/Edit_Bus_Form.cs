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

namespace HG_Bus_System___Admin_Panel.Views.Bus_Views
{
    public partial class Edit_Bus_Form : Form
    {
        public Edit_Bus_Form()
        {
            InitializeComponent();

            id_textBox.Text = Bus_Uc.id;
            manufacturer_textBox.Text = Bus_Uc.manufacturer;
            model_textBox.Text = Bus_Uc.model;
            seats_textBox.Text = Bus_Uc.seats;

            Image image = Bus_Functions.get_bus_image(id_textBox.Text);
            if (image != null)
            {
                pictureBox1.Image = image;
            }

            
        }

        private void edit_button_Click(object sender, EventArgs e)
        {
            ImageConverter converter = new ImageConverter();
            byte[] imageBytes = (byte[])converter.ConvertTo(pictureBox1.Image, typeof(byte[]));

            Bus_Functions bf = new Bus_Functions();
            bf.update_bus(id_textBox.Text, manufacturer_textBox.Text, model_textBox.Text, seats_textBox.Text, imageBytes);
            this.Close();
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            ImageConverter converter = new ImageConverter();
            byte[] imageBytes = (byte[])converter.ConvertTo(pictureBox1.Image, typeof(byte[]));

            Bus_Functions bf = new Bus_Functions();
            bf.delete_bus(id_textBox.Text);
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Create a new OpenFileDialog instance
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the filter to only allow image files
            openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

            // Show the file dialog
            DialogResult result = openFileDialog.ShowDialog();

            // If the user clicked OK and selected a file, load the image into the PictureBox control
            if (result == DialogResult.OK && openFileDialog.FileName != "")
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
            }
        }
    }
}
