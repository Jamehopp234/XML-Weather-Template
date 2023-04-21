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
    public partial class CurrentScreen : UserControl
    {
        int weather;
        public CurrentScreen()
        {
            InitializeComponent();
            minLabel.Parent = pictureBox;
            maxLabel.Parent = pictureBox;
            cityOutput.Parent = pictureBox;
            dateLabel.Parent = pictureBox;
            currentOutput.Parent = pictureBox;
            minOutput.Parent = pictureBox;
            maxOutput.Parent = pictureBox;
            conditionsLabel.Parent = pictureBox;
            label3.Parent= pictureBox;
            forecastLabel.Parent = pictureBox;
            label5.Parent = pictureBox;
            label8.Parent= pictureBox;
            DisplayCurrent();
        }

        public void DisplayCurrent()
        {
            cityOutput.Text = Form1.days[0].location;
            dateLabel.Text = Form1.days[0].date;
            conditionsLabel.Text = Form1.days[0].condition;
            currentOutput.Text = $"{Math.Round(Convert.ToDouble(Form1.days[0].currentTemp), 0)}°";
            minOutput.Text = $"{Math.Round(Convert.ToDouble(Form1.days[0].tempLow),0)}°";
            maxOutput.Text = $"{Math.Round(Convert.ToDouble(Form1.days[0].tempHigh),0)}°";
            
            
            
            

            weather = Convert.ToInt32(Form1.days[0].number);

            if(weather > 199 && weather < 233)
            {
                pictureBox.Image = Properties.Resources.thunder;
            }
            else if (weather > 299 && weather < 532)
            {
                pictureBox.Image = Properties.Resources.Rain3;
            }
            else if (weather > 599 && weather < 632)
            {
                pictureBox.Image = Properties.Resources.snow;
            }
            else if (weather > 699 && weather < 782)
            {
                pictureBox.Image = Properties.Resources.warning;
            }
            else if (weather > 800 && weather < 805)
            {
                pictureBox.Image = Properties.Resources.clouds;
            }
            else if (weather == 800)
            {
                pictureBox.Image = Properties.Resources.sun;
            }

        }

        private void forecastLabel_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            ForecastScreen fs = new ForecastScreen();
            f.Controls.Add(fs);
        }

        private void currentSearchbutton_Click(object sender, EventArgs e)
        {
            try
            {
                Form1.days.Clear();

                Form1.ExtractForecast(cityseachinput.Text, countrysearch.Text);
                Form1.ExtractCurrent(cityseachinput.Text, countrysearch.Text);
                DisplayCurrent();
                
                
            }
            catch
            {
                cityseachinput.Text = "ERROR! City not found.";
                countrysearch.Text = "ERROR! Country not found";
            }
        }
    }
}
