using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather;

namespace DAL1
{
    public class AsynchroinicWheaterData
    {
        const string Key = "6c707f6663ef3b437c92ae5b2bf997b5";
        public async Task<WeatherRoot> RetuenWeatherData(double lat, double lon)
        {
            using (var webClient = new System.Net.WebClient())
            {
                string URL = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={Key}&units=metric";
                var json = await webClient.DownloadStringTaskAsync(URL);
                WeatherRoot weather = JsonConvert.DeserializeObject<WeatherRoot>(json);
                return weather;
            }
        }
    }
}