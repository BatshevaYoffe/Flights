using BL;
using FlightModel;
using Microsoft.Maps.MapControl.WPF;
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
using System.Windows;
using System.Windows.Media;
using static FlightModel.FlightInfo;

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
        private Map myMap;
        private ResourceDictionary resources;

        public ViewModel()
        {
            FIPModel = new FlightInfoPartialModel();
            InComingFlights = new ObservableCollection<FlightInfoPartial>();
            OutGoingFlights = new ObservableCollection<FlightInfoPartial>();

            ReadAll = new ShowFlightsCommand();
            ReadAll.read += ShowAllFlights;
            ReadAll.read+=AllFlightsOnMap;
            

        }

        public ViewModel(Map myMap, ResourceDictionary resources)
        {
            FIPModel = new FlightInfoPartialModel();
            InComingFlights = new ObservableCollection<FlightInfoPartial>();
            OutGoingFlights = new ObservableCollection<FlightInfoPartial>();

            ReadAll = new ShowFlightsCommand();
            ReadAll.read += ShowAllFlights;
            ReadAll.read += AllFlightsOnMap;

            this.myMap = myMap;
            this.resources = resources;
        }

        private void AllFlightsOnMap()
        {
            foreach (FlightInfoPartial flight in InComingFlights)
            {
                AddFlightToMap(flight);
            }
            foreach (FlightInfoPartial flight in OutGoingFlights)
            {
                //UpdateFlight(flight);
            }

        }

        private void AddFlightToMap(FlightInfoPartial selected)
        {
            var Flight = VmGetFlightData(selected.SourceId);
            if (Flight != null)
            {
                List<FlightInfo.Trail> OrderedPlaces = OrderPlacesOfFlight(selected.SourceId);
                addNewPolyLine(OrderedPlaces, System.Windows.Media.Colors.Blue);

                //MessageBox.Show(Flight.airport.destination.code.iata);
                Trail CurrentPlace = null;

                Pushpin PinCurrent = new Pushpin { ToolTip = selected.FlightCode };
                Pushpin PinOrigin = new Pushpin { ToolTip = Flight.airport.origin.name };
                // Pushpin PinDestination = new Pushpin { ToolTip = Flight.airport.origin.name };


                PositionOrigin origin = new PositionOrigin { X = 0.4, Y = 0.4 };
                MapLayer.SetPositionOrigin(PinCurrent, origin);


                //Better to use RenderTransform
                if (Flight.airport.destination.code.iata == "TLV")
                {
                    PinCurrent.Style = (Style)resources["ToIsrael"];
                }
                else
                {
                    PinCurrent.Style = (Style)resources["FromIsrael"];
                }

                CurrentPlace = OrderedPlaces.Last<Trail>();
                var PlaneLocation = new Location { Latitude = CurrentPlace.lat, Longitude = CurrentPlace.lng };
                PinCurrent.Location = PlaneLocation;


                CurrentPlace = OrderedPlaces.First<Trail>();
                PlaneLocation = new Location { Latitude = CurrentPlace.lat, Longitude = CurrentPlace.lng };
                PinOrigin.Location = PlaneLocation;

                //CurrentPlace = OrderedPlaces.First<Trail>();
                //PlaneLocation = new Location { Latitude = CurrentPlace.lat, Longitude = CurrentPlace.lng };
                // PinDestination.Location = PlaneLocation;

                //PinCurrent.MouseDown += Pin_MouseDown;

                myMap.Children.Add(PinOrigin);
                myMap.Children.Add(PinCurrent);
            }


        }

        public void ShowAllFlights()
        {
            foreach(FlightInfoPartial flight in FIPModel.InComingflights)
                InComingFlights.Add(flight);
            foreach(FlightInfoPartial flight in FIPModel.OutGoingflights)
                OutGoingFlights.Add(flight);
            
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
        public void UpdateFlight(FlightInfoPartial selected)
        {
            //AsynchronicTrafficAdapter dal = new AsynchronicTrafficAdapter();
            var Flight = VmGetFlightData(selected.SourceId);
            SaveFlightInDB(Flight);

            //DetailsPanel.DataContext = Flight;



            // Update map
            if (Flight != null)
            {
                //var OrderedPlaces = (from f in Flight.trail
                //                     orderby f.ts
                //                     select f).ToList<Trail>();

                List<FlightInfo.Trail> OrderedPlaces = OrderPlacesOfFlight(selected.SourceId);
                addNewPolyLine(OrderedPlaces, System.Windows.Media.Colors.Green);

                //MessageBox.Show(Flight.airport.destination.code.iata);
                Trail CurrentPlace = null;

                Pushpin PinCurrent = new Pushpin { ToolTip = selected.FlightCode };
                Pushpin PinOrigin = new Pushpin { ToolTip = Flight.airport.origin.name };
                // Pushpin PinDestination = new Pushpin { ToolTip = Flight.airport.origin.name };


                PositionOrigin origin = new PositionOrigin { X = 0.4, Y = 0.4 };
                MapLayer.SetPositionOrigin(PinCurrent, origin);


                //Better to use RenderTransform
                if (Flight.airport.destination.code.iata == "TLV")
                {
                    PinCurrent.Style = (Style)resources["ToIsrael"];
                }
                else
                {
                    PinCurrent.Style = (Style)resources["FromIsrael"];
                }

                CurrentPlace = OrderedPlaces.Last<Trail>();
                var PlaneLocation = new Location { Latitude = CurrentPlace.lat, Longitude = CurrentPlace.lng };
                PinCurrent.Location = PlaneLocation;


                CurrentPlace = OrderedPlaces.First<Trail>();
                PlaneLocation = new Location { Latitude = CurrentPlace.lat, Longitude = CurrentPlace.lng };
                PinOrigin.Location = PlaneLocation;

                //CurrentPlace = OrderedPlaces.First<Trail>();
                //PlaneLocation = new Location { Latitude = CurrentPlace.lat, Longitude = CurrentPlace.lng };
                // PinDestination.Location = PlaneLocation;

                //PinCurrent.MouseDown += Pin_MouseDown;

                myMap.Children.Add(PinOrigin);
                myMap.Children.Add(PinCurrent);
                // myMap.Children.Add(PinDestination);

            }
        }


        void addNewPolyLine(List<Trail> Route,Color color)
        {
            MapPolyline polyline = new MapPolyline();
            //polyline.Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Blue);
            polyline.Stroke = new System.Windows.Media.SolidColorBrush(color);
            polyline.StrokeThickness = 1;
            polyline.Opacity = 0.7;
            polyline.Locations = new LocationCollection();
            foreach (var item in Route)
            {
                polyline.Locations.Add(new Location(item.lat, item.lng));
            }

            //  myMap.Children.Clear();
            myMap.Children.Add(polyline);
        }
    }
}
