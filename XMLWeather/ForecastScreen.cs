using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLWeather
{
    public partial class ForecastScreen : UserControl
    {
        int weather;
       public static string search = "";

        public ForecastScreen()
        {
            InitializeComponent();
            displayForecast();
        }

        public void displayForecast()
        {
            date1.Text = DateTime.Now.AddDays(1).DayOfWeek.ToString();
            
            min1.Text = $"{Math.Round(Convert.ToDouble(Form1.days[1].tempLow), 0)}°";
            max1.Text= $"{Math.Round(Convert.ToDouble(Form1.days[1].tempHigh), 0)}°";

            date2.Text = DateTime.Now.AddDays(2).DayOfWeek.ToString();
           
            min2.Text = $"{Math.Round(Convert.ToDouble(Form1.days[2].tempLow), 0)}°";
            max2.Text = $"{Math.Round(Convert.ToDouble(Form1.days[2].tempHigh), 0)}°";

            date3.Text = DateTime.Now.AddDays(3).DayOfWeek.ToString();
            
            min3.Text = $"{Math.Round(Convert.ToDouble(Form1.days[3].tempLow), 0)}°";
            max3.Text = $"{Math.Round(Convert.ToDouble(Form1.days[3].tempHigh), 0)}°";


            weather = Convert.ToInt32(Form1.days[1].number);

            if (weather > 199 && weather < 233)
            {
                pictureBox1.Image = Properties.Resources.thundericon;
            }
            else if (weather > 299 && weather < 532)
            {
                pictureBox1.Image = Properties.Resources.rainicon;
            }
            else if (weather > 599 && weather < 632)
            {
                pictureBox1.Image = Properties.Resources.snowicon;
            }
            else if (weather > 699 && weather < 782)
            {
                pictureBox1.Image = Properties.Resources.othericon;
            }
            else if (weather > 800 && weather < 805)
            {
                pictureBox1.Image = Properties.Resources.cloudicon;
            }
            else if (weather == 800)
            {
                pictureBox1.Image = Properties.Resources.sunicon;
            }

            weather = Convert.ToInt32(Form1.days[2].number);

            if (weather > 199 && weather < 233)
            {
                pictureBox2.Image = Properties.Resources.thundericon;
            }
            else if (weather > 299 && weather < 532)
            {
                pictureBox2.Image = Properties.Resources.rainicon;
            }
            else if (weather > 599 && weather < 632)
            {
                pictureBox2.Image = Properties.Resources.snowicon;
            }
            else if (weather > 699 && weather < 782)
            {
                pictureBox2.Image = Properties.Resources.othericon;
            }
            else if (weather > 800 && weather < 805)
            {
                pictureBox2.Image = Properties.Resources.cloudicon;
            }
            else if (weather == 800)
            {
                pictureBox2.Image = Properties.Resources.sunicon;
            }

            weather = Convert.ToInt32(Form1.days[2].number);

            if (weather > 199 && weather < 233)
            {
                pictureBox3.Image = Properties.Resources.thundericon;
            }
            else if (weather > 299 && weather < 532)
            {
                pictureBox3.Image = Properties.Resources.rainicon;
            }
            else if (weather > 599 && weather < 632)
            {
                pictureBox3.Image = Properties.Resources.snowicon;
            }
            else if (weather > 699 && weather < 782)
            {
                pictureBox3.Image = Properties.Resources.othericon;
            }
            else if (weather > 800 && weather < 805)
            {
                pictureBox3.Image = Properties.Resources.cloudicon;
            }
            else if (weather == 800)
            {
                pictureBox3.Image = Properties.Resources.sunicon;
            }

            

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            CurrentScreen cs = new CurrentScreen();
            f.Controls.Add(cs);
        }

        private void ForecastScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
