using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using static System.Net.WebRequestMethods;

namespace Weather_Desktop_Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string APIKey = "565ba2f709dddbb009c669da5103ea73"; 
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            getWeather();
            getForecast();
            getAirPollution();
            getUVIndex();
        }
        private void TBCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }



        double lon;
        double lat;



        void getWeather()
        {
            using (WebClient web = new WebClient()) 
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric", TBCity.Text, APIKey);
                var json = web.DownloadString(url);
                WeatherInfo.root Info = JsonConvert.DeserializeObject<WeatherInfo.root>(json);

                picIcon.ImageLocation = "https://openweathermap.org/img/w/" + Info.weather[0].icon + ".png";
                labCondition.Text = Info.weather[0].main;
                labDeatils.Text = Info.weather[0].description;



                labSunset.Text = convertDateTime(Info.sys.sunset).ToShortTimeString();
                labSunrise.Text = convertDateTime(Info.sys.sunrise).ToShortTimeString();

                labelWindSpeed.Text = $"{Info.wind.speed} m/s ({(Info.wind.speed * 3.6):0.##} km/h)";
                labelPressure.Text = $"{Info.main.pressure} hPa";

                labTemperature.Text = $"{Math.Round(Info.main.temp)} °C";


                lon = Info.coord.lon;
                lat = Info.coord.lat;
            }
        }

        DateTime convertDateTime(long sec)
        {
            DateTime day = new DateTime(2024, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(sec).ToLocalTime();

            return day;
        }

        void getForecast()
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/3.0/onecall?lat={0}&lon={1}&exclude=current,minutely,hourly,alerts&appid={2}&units=metric", lat, lon, APIKey);

                var json = web.DownloadString(url);
                WeatherForecast.ForecastInfo ForecastInfo = JsonConvert.DeserializeObject<WeatherForecast.ForecastInfo>(json);

                ForecastUC FUC;
                for (int i = 0; i < 8; i++)
                {
                    FUC = new ForecastUC();
                    FUC.picWeatherIcon.ImageLocation = "https://openweathermap.org/img/w/" + ForecastInfo.daily[i].weather[0].icon + ".png";
                    FUC.labMainWeather.Text = ForecastInfo.daily[i].weather[0].main;
                    FUC.labWeatherDescription.Text = ForecastInfo.daily[i].weather[0].description;
                    FUC.labDT.Text = convertDateTime(ForecastInfo.daily[i].dt).DayOfWeek.ToString();
                    FUC.labTemp.Text = $"{ForecastInfo.daily[i].temp.day} °C";

                    FLP.Controls.Add(FUC);
                }

            }
        }

        private void getAirPollution()
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("http://api.openweathermap.org/data/2.5/air_pollution?lat={0}&lon={1}&appid={2}", lat, lon, APIKey);

                try
                {
                    string json = web.DownloadString(url);
                    WeatherInfo.AirPollution airPollutionInfo = JsonConvert.DeserializeObject<WeatherInfo.AirPollution>(json);

                    if (airPollutionInfo.list.Length > 0)
                    {
                        labelAirPollution.Text = $"{airPollutionInfo.list[0].components.pm2_5} µg/m³";
                    }
                    else
                    {
                        labelAirPollution.Text = "Nema dostupnih informacija o zagađenju vazduha.";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Došlo je do greške prilikom dobijanja informacija o zagađenju vazduha: {ex.Message}");
                }
            }
        }


        private void getUVIndex()
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/uvi?lat={0}&lon={1}&appid={2}", lat, lon, APIKey);

                try
                {
                    string json = web.DownloadString(url);
                    WeatherInfo.UVIndexInfo uvIndexInfo = JsonConvert.DeserializeObject<WeatherInfo.UVIndexInfo>(json);

                    labelUVIndex.Text = $"{uvIndexInfo.value} {uvIndexInfo.unit}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Došlo je do greške prilikom dobijanja informacija o UV indeksu: {ex.Message}");
                }
            }
        }
    }
}
