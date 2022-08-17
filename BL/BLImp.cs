using DAL1;
using FlightModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather;

namespace BL
{
    public class BLImp : IBL
    {
        AsynchronicTrafficAdapter asynchronicTrafficAdapter = new AsynchronicTrafficAdapter();
        AsynchronicHebCal asynchronicHebCal = new AsynchronicHebCal();
        AsynchroinicWheaterData asynchroinicWheaterData = new AsynchroinicWheaterData();
        public List<FlightInfoPartial> GetCurrentOutGoingFlights()
        {
            var FlightKeys = asynchronicTrafficAdapter.GetCurrentFlights();

            try
            {
                foreach (FlightInfoPartial flight in FlightKeys["Outgoing"])
                {
                    if (flight.FlightCode == "" || flight.Destination == "")
                        FlightKeys["Outgoing"].Remove(flight);

                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }
            return FlightKeys["Outgoing"];
        }
        public List<FlightInfoPartial> GetCurrentInComingFlights()
        {
            var FlightKeys = asynchronicTrafficAdapter.GetCurrentFlights();
            try
            {
                foreach (FlightInfoPartial flight in FlightKeys["Incoming"])
                {
                    if (flight.FlightCode == "" || flight.Destination == "")
                        FlightKeys["Incoming"].Remove(flight);

                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }
            return FlightKeys["Incoming"];
        }
        public FlightInfo.Root GetDataofOneFlight(string SourceId)
        {
            return asynchronicTrafficAdapter.GetFlightData(SourceId);
        }
        public void BLSaveFlight(FlightInfoPartial flight)
        {

            ConectionToTheDataBase conectionToDB = new ConectionToTheDataBase();
            conectionToDB.AddFlight(flight);
        }
        public async Task<string> ReturnStatusOfDate(DateTime date)
        {
            string status = await asynchronicHebCal.GetStatusOfDate(date);
            return status;

        }
        public async Task<WeatherRoot> ReturnWeatherBl(double lat,double lon)
        {
            WeatherRoot weatherRoot =  await asynchroinicWheaterData.RetuenWeatherData(lat, lon);
            return weatherRoot;
        }
    }
}
