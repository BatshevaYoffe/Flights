using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather;
using BL;

namespace PL.Model
{
    public class WeatherDataModel
    {
        IBL bl = new BLImp();

        
        public WeatherRoot GetWeather(double lat, double lon)
        {

            WeatherRoot w = bl.ReturnWeatherBl(lat, lon);

            return w;
        }

    }
}