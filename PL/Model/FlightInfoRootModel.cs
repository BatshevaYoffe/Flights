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
        public List<FlightInfo.Root> FlightsInformation;

        public  FlightInfoRootModel()
        {
            FlightsInformation=new List<FlightInfo.Root>();
        }
       public FlightInfo.Root GetDataOfFlightFromModel(string flightCode)
       {
            foreach (FlightInfo.Root f in FlightsInformation)
            {
                if(flightCode== f.identification.callsign)
                    return f;
            }
            FlightInfo.Root flightRoot = bl.GetDataofOneFlight(flightCode);
            FlightsInformation.Add(flightRoot);
                return flightRoot;



       }
    }
}
