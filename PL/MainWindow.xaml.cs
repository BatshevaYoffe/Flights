 using BL;
using DAL;// אולי למחוק
using FlightModel;
using Microsoft.Maps.MapControl.WPF;
using PL.VM.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static FlightModel.FlightInfo;

namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FlightInfoPartial SelectedFlight = null; //Selected Flight

         //VM.ViewModel vm =new VM.ViewModel();
        
        VM.ViewModel vm { get; set; }

        public MainWindow()//
        {
            InitializeComponent();
            vm = new VM.ViewModel();
            this.DataContext = vm;
        }


        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    //load current data
        //    // this.DataContext = FlightKeys;
        //    InFlightsListBox.DataContext = vm.deleteNullFromList("incoming");
        //    OutFlightsListBox.DataContext =vm.deleteNullFromList("outgoing");

        //}

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 15);
            dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            UpdateFlight(SelectedFlight);
            Counter.Text = (Convert.ToInt32(Counter.Text) + 1).ToString();
        }

        private void FlightsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedFlight = e.AddedItems[0] as FlightInfoPartial; //InFlightsListBox.SelectedItem as FlightInfoPartial;
            UpdateFlight(SelectedFlight);

        }

        private void UpdateFlight(FlightInfoPartial selected)
        {
             //AsynchronicTrafficAdapter dal = new AsynchronicTrafficAdapter();
            var Flight = vm.VmGetFlightData(selected.SourceId);
            vm.SaveFlightInDB(Flight);
            
            DetailsPanel.DataContext = Flight;



            // Update map
            if (Flight != null)
            {
                //var OrderedPlaces = (from f in Flight.trail
                //                     orderby f.ts
                //                     select f).ToList<Trail>();

                List < FlightInfo.Trail > OrderedPlaces = vm.OrderPlacesOfFlight(selected.SourceId);
                addNewPolyLine(OrderedPlaces);

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
                    PinCurrent.Style = (Style)Resources["ToIsrael"];
                }
                else
                {
                    PinCurrent.Style = (Style)Resources["FromIsrael"];
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
            private void Pin_MouseDown(object sender, MouseButtonEventArgs e)
            {
                var pin = e.OriginalSource as Pushpin;
                MessageBox.Show(pin.ToolTip.ToString());
            }


            void addNewPolyLine(List<Trail> Route)
            {
                MapPolyline polyline = new MapPolyline();
                //polyline.Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Blue);
                polyline.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Green);
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

        private void ben(object sender, DpiChangedEventArgs e)
        {
            Pushpin PinCurrent = new Pushpin { };
            PinCurrent.Style = (Style)Resources["Airport"];



        }
    }
}
