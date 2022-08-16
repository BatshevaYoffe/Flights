using BL;
using FlightModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Model
{
    public class FlightInfoPartialModel
    {
        IBL bl = new BLImp();
        public List<FlightInfoPartial> InComingflights;
        public List<FlightInfoPartial> OutGoingflights;
        public FlightInfoPartialModel()
        {
            InComingflights = bl.GetCurrentInComingFlights();
            OutGoingflights = bl.GetCurrentOutGoingFlights();

        }
        public void save(FlightInfoPartial flight)
        {
            bl.BLSaveFlight(flight);
        } 
    }
}
