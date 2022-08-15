using BL;
using FlightModel;
using PL.Model;
using PL.VM.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PL.VM
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<FlightInfoPartial> InComingFlights {get;set;}
        public ObservableCollection<FlightInfoPartial> OutGoingFlights { get; set; }
        public ShowFlightsCommand ReadAll { get; set; }

        IBL bl = new BLImp();
        private FlightInfoPartialModel FIPModel;
        
        public ViewModel()
        {
            FIPModel = new FlightInfoPartialModel();
            ReadAll = new ShowFlightsCommand(this);
            //ReadAll.read += ShowAllFlights;
            

        }

        public void ShowAllFlights()
        {
            InComingFlights = new ObservableCollection<FlightInfoPartial>(FIPModel.InComingflights);
            OutGoingFlights = new ObservableCollection<FlightInfoPartial>(FIPModel.OutGoingflights);

        }




        //public List<FlightInfoPartial> deleteNullFromList(string category)
        //{
        //    List<FlightInfoPartial> list = null;
        //    if (category == "incoming")
        //        list = bl.GetCurrentInComingFlights();
        //    if (category == "outgoing")
        //        list = bl.GetCurrentOutGoingFlights();
        //    try
        //    {
        //        foreach (FlightInfoPartial flight in list)
        //        {
        //            if (flight.FlightCode == "" || flight.Destination == "")
        //                list.Remove(flight);

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.Print(e.Message);
        //    }
        //    return list;


        //}
        public FlightInfo.Root VmGetFlightData(string sourceId)
        {
            FlightInfo.Root Flight = bl.GetDataofOneFlight(sourceId);
            return Flight;  
        }
        public List<FlightInfo.Trail> OrderPlacesOfFlight(string sourceId)
        {
            FlightInfo.Root Flight =bl.GetDataofOneFlight(sourceId);
            List<FlightInfo.Trail>  OrderedPlaces=(from f in Flight.trail
                                     orderby f.ts
                                     select f).ToList<FlightInfo.Trail>();

            return OrderedPlaces;
        }
        public void SaveFlightInDB(FlightInfo.Root flightRoot)
        {
            bl.BLSaveFlight(flightRoot);
        }
    }
}
