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
        public List<WeatherRoot> weatherRoots = new List<WeatherRoot>();
        public async Task<WeatherRoot> GetWeather(double lat,double lon )
        {
            if (weatherRoots.Count != 0)
            {
                foreach(WeatherRoot o in weatherRoots)
                {
                    if (o.coord.lat == lat && o.coord.lon == lon)
                        return o;
                }
            }
            WeatherRoot w = await bl.ReturnWeatherBl(lat, lon);
            weatherRoots.Add(w);    
            return w;
        }

    }
}
