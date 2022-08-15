using DAL;
using FlightModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BLImp : IBL
    {
        AsynchronicTrafficAdapter dal = new AsynchronicTrafficAdapter();
        public List<FlightInfoPartial> GetCurrentOutGoingFlights()
        {
            var FlightKeys = dal.GetCurrentFlights();
            
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
            var FlightKeys = dal.GetCurrentFlights();
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
             return  dal.GetFlightData(SourceId);
        }
        public void BLSaveFlight(FlightInfo.Root flightRoot)
        {
            ConectionToDB conectionToDB = new ConectionToDB();
            conectionToDB.addFlight(flightRoot);    
        }
    }
}
