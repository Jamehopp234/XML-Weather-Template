using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;

namespace XMLWeather
{
    public partial class Form1 : Form
    {
       
        public static List<Day> days = new List<Day>();


        public Form1()
        {
            InitializeComponent();

            ExtractForecast("Stratford", "CA");
            ExtractCurrent("Stratford", "CA");
            
            // open weather screen for todays weather
            CurrentScreen cs = new CurrentScreen();
            this.Controls.Add(cs);
        }

        public static void ExtractForecast(string city, string country)
        {
            XmlReader reader = XmlReader.Create($"http://api.openweathermap.org/data/2.5/forecast/daily?q={city},{country}&mode=xml&units=metric&cnt=7&appid=3f2e224b815c0ed45524322e145149f0");

            while (reader.Read())
            {

                //create  a day object
                Day d = new Day();

                //fill day object with required data
                reader.ReadToFollowing("time");
                d.date = reader.GetAttribute("day");

                //days.Add(d);

                reader.ReadToFollowing("temperature");
                d.tempLow = reader.GetAttribute("min");
                d.tempHigh = reader.GetAttribute("max");

                reader.ReadToFollowing("symbol");
                d.condition = reader.GetAttribute("name");
                d.number = reader.GetAttribute("number");


                if(d.date != null)
                {
                    days.Add(d);
                }

                //TODO: if day object not null add to the days list
            }
        }

        public static void ExtractCurrent(string city, string country)
        {
            // current info is not included in forecast file so we need to use this file to get it
            XmlReader reader = XmlReader.Create($"http://api.openweathermap.org/data/2.5/weather?q={city},{country}&mode=xml&units=metric&appid=3f2e224b815c0ed45524322e145149f0");

            //find the city and current temperature and add to appropriate item in days list

            reader.ReadToFollowing("city");
            days[0].location = reader.GetAttribute("name");

            reader.ReadToFollowing("temperature");
            days[0].currentTemp = reader.GetAttribute("value");
            days[0].tempLow = reader.GetAttribute("min");
            days[0].tempHigh = reader.GetAttribute("max");

            reader.ReadToFollowing("weather");
            days[0].condition = reader.GetAttribute("value");
            days[0].number = reader.GetAttribute("number");


        }


    }
}
