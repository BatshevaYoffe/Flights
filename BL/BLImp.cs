using DAL;
using FlightModel;
using System;
using System.Collections.Generic;
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
            return FlightKeys["Outgoing"];
        }
        public List<FlightInfoPartial> GetCurrentInComingFlights()
        {
            var FlightKeys = dal.GetCurrentFlights();
            return FlightKeys["Incoming"];
        }
    }
}
