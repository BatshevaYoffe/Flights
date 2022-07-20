using BL;
using FlightModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.VM
{
    public class ViewModel
    {
        IBL bl = new BLImp();

        public List<FlightInfoPartial> deleteNullFromList(string category)
        {
            List<FlightInfoPartial> list=null;
            if (category == "incoming")
                list= bl.GetCurrentInComingFlights();   
            if (category == "outgoing")
               list= bl.GetCurrentOutGoingFlights();

            foreach(FlightInfoPartial flight in list)
            {
                if (flight.FlightCode == " ")
                    list.Remove(flight);
            }
            return list;
            
            
        }
    }
}
