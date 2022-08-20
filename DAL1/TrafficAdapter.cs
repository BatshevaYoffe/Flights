using FlightModel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FlightModel.FlightInfo;

namespace DAL1
{
    public class TrafficAdapter
    {
        private const string AllURL = @"https://data-cloud.flightradar24.com/zones/fcgi/feed.js?faa=1&bounds=33.874%2C29.433%2C30.862%2C37.601&satellite=1&mlat=1&flarm=1&adsb=1&gnd=1&air=1&vehicles=1&estimated=1&maxage=14400";
        private const string FlightURL = @"https://data-live.flightradar24.com/clickhandler/?version=1.5&flight=";
        public Dictionary<string, List<FlightInfoPartial>> GetCurrentFlights()
        {
            //
            Dictionary<string, List<FlightInfoPartial>> Result = new Dictionary<string, List<FlightModel.FlightInfoPartial>>();

            JObject AllFlightData = null;
            IList<string> Keys = null;
            IList<Object> Values = null;

            List<FlightInfoPartial> Incoming = new List<FlightInfoPartial>();
            List<FlightInfoPartial> Outgoing = new List<FlightInfoPartial>();

            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(AllURL);
                HelperClass Helper = new HelperClass();
                AllFlightData = JObject.Parse(json);
                try
                {
                    foreach (var item in AllFlightData)
                    {
                        var key = item.Key;
                        if (key == "full_count") continue;
                        if (key == "version") continue;
                        if (item.Value[11].ToString() == "TLV") Outgoing.Add(new FlightInfoPartial
                        {
                            Id = -1,//
                            Source = item.Value[11].ToString(),
                            Destination = item.Value[12].ToString(),
                            SourceId = key,
                            Long = Convert.ToDouble(item.Value[1]),
                            Lat = Convert.ToDouble(item.Value[2]),
                            DateTime = Helper.GetDataTimeFromEpoch((int)Convert.ToDouble(item.Value[10])),
                            FlightCode = item.Value[13].ToString()
                        });
                        if (item.Value[12].ToString() == "TLV") Incoming.Add(new FlightInfoPartial
                        {
                            Id = -1,
                            Source = item.Value[11].ToString(),
                            Destination = item.Value[12].ToString(),
                            SourceId = key,
                            Long = Convert.ToDouble(item.Value[1]),
                            Lat = Convert.ToDouble(item.Value[2]),
                            DateTime = Helper.GetDataTimeFromEpoch((int)Convert.ToDouble(item.Value[10])),
                            FlightCode = item.Value[13].ToString()
                        });
                    }

                }
                catch (Exception e)
                {
                    Debug.Print(e.Message);
                }

            }
            Result.Add("Incoming", Incoming);
            Result.Add("Outgoing", Outgoing);

            return Result;
        }
        //
        public Root GetFlightData(string key)
        {
            var CuurentUrl = FlightURL + key;
            Root CurrentFlight = null;

            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(CuurentUrl);
                try
                {
                    CurrentFlight = (Root)Newtonsoft.Json.JsonConvert.DeserializeObject(json, typeof(Root));
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }

            return CurrentFlight;
        }
    }
}
