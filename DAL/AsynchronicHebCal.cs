using HebDades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AsynchronicHebCal
    {

        public async void AsyncReturnStatus(DateTime date)
        {
            using (var webClient = new System.Net.WebClient())
            {
                var yyyy = date.ToString("yyyy");
                var mm = date.ToString("MM");
                var dd = date.ToString("dd");
                string URL1 = $"https://www.hebcal.com/converter?cfg=json&date={yyyy}-{mm}-{dd}&g2h=1&strict=1";
                string URL = $"https://www.hebcal.com/converter?cfg=json&date=(yyyy)-(mm)-(dd)&g2h=1&strict=1";
                var json = await webClient.DownloadStringTaskAsync(URL);
                Root Date = JsonConvert.DeserializeObject<Root>(json);

                if (Date.events[0].Contains("Erev"))
                    throw new Exception("ערב חג");
                else
                    throw new Exception("יום רגיל");

            }

        }

    }
}
