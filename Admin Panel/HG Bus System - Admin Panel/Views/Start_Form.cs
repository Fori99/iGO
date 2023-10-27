using HG_Bus_System___Admin_Panel.Models;
using HG_Bus_System___Admin_Panel.Views.Bus_Views;
using HG_Bus_System___Admin_Panel.Views.Driver_Views;
using HG_Bus_System___Admin_Panel.Views.Route_Views;
using HG_Bus_System___Admin_Panel.Views.Travel_Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HG_Bus_System___Admin_Panel
{
    public partial class Start_Form : Form
    {
        public Start_Form()
        {
            InitializeComponent();
        }

        private void button_cities_Click(object sender, EventArgs e)
        {
            var myControl = new Cities_UC();
            main_panel.Controls.Clear();
            main_panel.Controls.Add(myControl);

            //make button cities active
            button_cities.BackgroundImage = new Bitmap(180, 50);
            Graphics.FromImage(button_cities.BackgroundImage).FillRectangle(myGradient_backcolor(), 0, 0, 180, 50);
            button_cities.ForeColor = Color.FromArgb(246, 247, 235);

            //make other button not active
            //routes
            button_routes.BackColor = Color.FromArgb(246, 247, 235);
            button_routes.ForeColor = Color.FromArgb(57, 62, 65);
            button_routes.BackgroundImage = null;

            //travel
            button_travels.BackColor = Color.FromArgb(246, 247, 235);
            button_travels.ForeColor = Color.FromArgb(57, 62, 65);
            button_travels.BackgroundImage = null;

            //busses
            button_busses.BackColor = Color.FromArgb(246, 247, 235);
            button_busses.ForeColor = Color.FromArgb(57, 62, 65);
            button_busses.BackgroundImage = null;

            //drivers
            button_drivers.BackColor = Color.FromArgb(246, 247, 235);
            button_drivers.ForeColor = Color.FromArgb(57, 62, 65);
            button_drivers.BackgroundImage = null;
        }

        private void button_routes_Click(object sender, EventArgs e)
        {
            var myControl = new Route_Uc();
            main_panel.Controls.Clear();
            main_panel.Controls.Add(myControl);

            //make button routes active
            button_routes.BackgroundImage = new Bitmap(180, 50);
            Graphics.FromImage(button_routes.BackgroundImage).FillRectangle(myGradient_backcolor(), 0, 0, 180, 50);
            button_routes.ForeColor = Color.FromArgb(246, 247, 235);

            //make other button not active
            //cities
            button_cities.BackColor = Color.FromArgb(246, 247, 235);
            button_cities.ForeColor = Color.FromArgb(57, 62, 65);
            button_cities.BackgroundImage = null;

            //travel
            button_travels.BackColor = Color.FromArgb(246, 247, 235);
            button_travels.ForeColor = Color.FromArgb(57, 62, 65);
            button_travels.BackgroundImage = null;

            //busses
            button_busses.BackColor = Color.FromArgb(246, 247, 235);
            button_busses.ForeColor = Color.FromArgb(57, 62, 65);
            button_busses.BackgroundImage = null;

            //drivers
            button_drivers.BackColor = Color.FromArgb(246, 247, 235);
            button_drivers.ForeColor = Color.FromArgb(57, 62, 65);
            button_drivers.BackgroundImage = null;
        }

        private void button_drivers_Click(object sender, EventArgs e)
        {
            var myControl = new Driver_Uc();
            main_panel.Controls.Clear();
            main_panel.Controls.Add(myControl);

            //make button drivers active
            button_drivers.BackgroundImage = new Bitmap(180, 50);
            Graphics.FromImage(button_drivers.BackgroundImage).FillRectangle(myGradient_backcolor(), 0, 0, 180, 50);
            button_drivers.ForeColor = Color.FromArgb(246, 247, 235);

            //make other button not active
            //routes
            button_routes.BackColor = Color.FromArgb(246, 247, 235);
            button_routes.ForeColor = Color.FromArgb(57, 62, 65);
            button_routes.BackgroundImage = null;

            //travel
            button_travels.BackColor = Color.FromArgb(246, 247, 235);
            button_travels.ForeColor = Color.FromArgb(57, 62, 65);
            button_travels.BackgroundImage = null;

            //busses
            button_busses.BackColor = Color.FromArgb(246, 247, 235);
            button_busses.ForeColor = Color.FromArgb(57, 62, 65);
            button_busses.BackgroundImage = null;

            //cities
            button_cities.BackColor = Color.FromArgb(246, 247, 235);
            button_cities.ForeColor = Color.FromArgb(57, 62, 65);
            button_cities.BackgroundImage = null;
        }

        private void button_busses_Click(object sender, EventArgs e)
        {
            var myControl = new Bus_Uc();
            main_panel.Controls.Clear();
            main_panel.Controls.Add(myControl);

            //make button busses active
            button_busses.BackgroundImage = new Bitmap(180, 50);
            Graphics.FromImage(button_busses.BackgroundImage).FillRectangle(myGradient_backcolor(), 0, 0, 180, 50);
            button_busses.ForeColor = Color.FromArgb(246, 247, 235);

            //make other button not active
            //routes
            button_routes.BackColor = Color.FromArgb(246, 247, 235);
            button_routes.ForeColor = Color.FromArgb(57, 62, 65);
            button_routes.BackgroundImage = null;

            //travel
            button_travels.BackColor = Color.FromArgb(246, 247, 235);
            button_travels.ForeColor = Color.FromArgb(57, 62, 65);
            button_travels.BackgroundImage = null;

            //cities
            button_cities.BackColor = Color.FromArgb(246, 247, 235);
            button_cities.ForeColor = Color.FromArgb(57, 62, 65);
            button_cities.BackgroundImage = null;

            //drivers
            button_drivers.BackColor = Color.FromArgb(246, 247, 235);
            button_drivers.ForeColor = Color.FromArgb(57, 62, 65);
            button_drivers.BackgroundImage = null;
        }

        private void button_travels_Click(object sender, EventArgs e)
        {
            var myControl = new Travel_Uc();
            main_panel.Controls.Clear();
            main_panel.Controls.Add(myControl);

            //make button travels active
            button_travels.BackgroundImage = new Bitmap(180, 50);
            Graphics.FromImage(button_travels.BackgroundImage).FillRectangle(myGradient_backcolor(), 0, 0, 180, 50);
            button_travels.ForeColor = Color.FromArgb(246, 247, 235);

            //make other button not active
            //routes
            button_routes.BackColor = Color.FromArgb(246, 247, 235);
            button_routes.ForeColor = Color.FromArgb(57, 62, 65);
            button_routes.BackgroundImage = null;

            //cities
            button_cities.BackColor = Color.FromArgb(246, 247, 235);
            button_cities.ForeColor = Color.FromArgb(57, 62, 65);
            button_cities.BackgroundImage = null;

            //busses
            button_busses.BackColor = Color.FromArgb(246, 247, 235);
            button_busses.ForeColor = Color.FromArgb(57, 62, 65);
            button_busses.BackgroundImage = null;

            //drivers
            button_drivers.BackColor = Color.FromArgb(246, 247, 235);
            button_drivers.ForeColor = Color.FromArgb(57, 62, 65);
            button_drivers.BackgroundImage = null;
        }

        private LinearGradientBrush myGradient_backcolor()
        {
            LinearGradientBrush gradientBrush = new LinearGradientBrush
                (
                    new Point(0, 0),
                    new Point(0, 50),
                    Color.FromArgb(33, 150, 243),
                    Color.FromArgb(27, 30, 123)
                );
            return gradientBrush;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

