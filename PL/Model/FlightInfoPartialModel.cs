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
        public List<FlightInfoPartial> SelectedFlightsAtRangeOfDates;
        public FlightInfoPartialModel()
        {
            InComingflights = bl.GetCurrentInComingFlights();
            OutGoingflights = bl.GetCurrentOutGoingFlights();

        }
        public void save(FlightInfoPartial flight)
        {
            bl.BLSaveFlight(flight);
        }
        public List<FlightInfoPartial> FlightByDates(DateTime firstDate, DateTime lastDate)
        {
            SelectedFlightsAtRangeOfDates=bl.GetSelectedFlightsByDates(firstDate, lastDate);
            
            return SelectedFlightsAtRangeOfDates;
        }
        public void RefreshListsOfFlights()
        {
            InComingflights = bl.GetCurrentInComingFlights();
            OutGoingflights = bl.GetCurrentOutGoingFlights();
        }
           
    }

    
}
