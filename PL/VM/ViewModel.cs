using BL;
using FlightModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.VM
{
    public class ViewModel : INotifyPropertyChanged
    {
        IBL bl = new BLImp();

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        public List<FlightInfoPartial> deleteNullFromList(string category)
        {
            List<FlightInfoPartial> list=null;
            if (category == "incoming")
                list= bl.GetCurrentInComingFlights();   
            if (category == "outgoing")
               list= bl.GetCurrentOutGoingFlights();
            try
            {
                foreach (FlightInfoPartial flight in list)
                {
                    if (flight.FlightCode == "" ||flight.Destination=="")
                        list.Remove(flight);

                }
            }catch(Exception e)
            {
                Debug.Print(e.Message);
            }
            return list;
            
            
        }
    }
}
