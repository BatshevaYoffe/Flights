using BL;
using FlightModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Model
{
    public class FlightInfoRootModel
    {
        IBL bl = new BLImp();
        public List<FlightInfo.Root> FlightsInformation=null;

       public FlightInfo.Root GetDataOfFlightFromModel(string flightCode)
       {
            if (FlightsInformation!= null)
            {
                foreach (FlightInfo.Root f in FlightsInformation)
                {
                    if (f!=null&&flightCode == f.identification.callsign)
                        return f;
                }
            }
            if(FlightsInformation == null)
            {
                FlightsInformation = new List<FlightInfo.Root>();
            }
            FlightInfo.Root flightRoot = bl.GetDataofOneFlight(flightCode);
            FlightsInformation.Add(flightRoot);
                return flightRoot;



       }
    }
}
