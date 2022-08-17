using FlightModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IBL
    {
        List<FlightInfoPartial> GetCurrentOutGoingFlights();
        List<FlightInfoPartial> GetCurrentInComingFlights();
        FlightInfo.Root GetDataofOneFlight(string SourceId);
        void BLSaveFlight(FlightInfoPartial flight);
        string ReturnStatusOfDate(DateTime date);
    }
}
