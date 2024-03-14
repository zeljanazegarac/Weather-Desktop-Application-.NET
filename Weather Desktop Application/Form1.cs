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
using System.Media;


namespace Weather_Desktop_Application
{
    public partial class Form1 : Form

    {
        public Form1()
        {
            InitializeComponent();
        }

        // SoundPlayer object to handle sound playback
        private SoundPlayer player;


        // OpenWeatherMap API Key
        string APIKey = "565ba2f709dddbb009c669da5103ea73"; 
        private void Form1_Load(object sender, EventArgs e)
        {
            // Code to execute when the form loads
        }

        // Button click event handler to trigger weather data retrieval
        private void btnSearch_Click(object sender, EventArgs e)
        {
            getWeather();
            getForecast();
            getAirPollution();
            getUVIndex();
        }

        // Key down event handler for textbox to trigger search on Enter key press
        private void TBCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }


        // Variables to store latitude and longitude
        double lon;
        double lat;


        // Method to retrieve current weather data
        void getWeather()
        {
            // Using WebClient to make HTTP request to OpenWeatherMap API
            using (WebClient web = new WebClient()) 
            {
                // Constructing the API URL with city name and API key
                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric", TBCity.Text, APIKey);
                // Downloading JSON data from the API
                var json = web.DownloadString(url);
                // Deserializing JSON data into WeatherInfo.root object
                WeatherInfo.root Info = JsonConvert.DeserializeObject<WeatherInfo.root>(json);

                // Setting weather conditions display
                picIcon.ImageLocation = "https://openweathermap.org/img/w/" + Info.weather[0].icon + ".png";
                labCondition.Text = Info.weather[0].main;
                labDeatils.Text = Info.weather[0].description;


                // Setting sunrise and sunset times
                labSunset.Text = convertDateTime(Info.sys.sunset).ToShortTimeString();
                labSunrise.Text = convertDateTime(Info.sys.sunrise).ToShortTimeString();

                // Setting wind speed and pressure
                labelWindSpeed.Text = $"{Info.wind.speed} m/s ({(Info.wind.speed * 3.6):0.##} km/h)";
                labelPressure.Text = $"{Info.main.pressure} hPa";

                // Setting temperature
                labTemperature.Text = $"{Math.Round(Info.main.temp)} °C";

                // Storing latitude and longitude for future use
                lon = Info.coord.lon;
                lat = Info.coord.lat;

                string soundPath = ""; // Defining empty sound path


                // Selecting appropriate sound based on weather condition
                switch (Info.weather[0].main.ToLower())
                {
                    case "rain":
                        soundPath = @"Audio\rain.wav";
                        break;
                    case "clear":
                        soundPath = @"Audio\sunny.wav";
                        break;
                    default:
                        // No sound to play if condition does not match
                        break;
                }

                // Checking if sound path is not empty
                if (!string.IsNullOrEmpty(soundPath))
                {
                    // Combining the sound path with application startup path to get absolute path
                    soundPath = System.IO.Path.Combine(Application.StartupPath, soundPath);
                    // Checking if sound file exists
                    if (System.IO.File.Exists(soundPath))
                    {
                        // Playing the sound
                        PlaySound(soundPath);
                    }
                    else
                    {
                        // Showing error message if sound file not found
                        MessageBox.Show($"Sound not found at the following path: {soundPath}");
                    }
                }
            }
        }


        // Method to convert Unix timestamp to DateTime
        DateTime convertDateTime(long sec)
        {
            DateTime day = new DateTime(2024, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(sec).ToLocalTime();

            return day;
        }

        // Method to retrieve weather forecast
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


        // Method to retrieve air pollution data
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
                        labelAirPollution.Text = "There is no available air pollution information.";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while retrieving air pollution information. {ex.Message}");
                }
            }
        }


        // Method to retrieve UV index data
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
                    MessageBox.Show($"An error occurred while retrieving UV index information. {ex.Message}");
                }
            }
        }


        // Method to play sound
        private void PlaySound(string soundPath)
        {
            try
            {
                // Stop any previously playing sound
                player?.Stop();

                // Create a new SoundPlayer object with the specified sound path
                player = new SoundPlayer(soundPath);

                // Play the sound
                player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during sound playback. {ex.Message}");
            }
        }
    }
}
