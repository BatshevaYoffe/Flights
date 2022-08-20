using FlightModel;
using PL.Model;
using PL.VM.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PL.VM
{
    public class SelectDatesVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private FlightInfoPartialModel FIPModel;
        public ObservableCollection<FlightInfoPartial> SelectedFlights { get; set; }

        public StackPanel detailsPanel;

        
        public DateTime FirstDate;//=17/08/2022;
        public DateTime LastDate;


        public SelectDatesVM(StackPanel detailsPanel)
        {
            FIPModel = new FlightInfoPartialModel();
            SelectedFlights = new ObservableCollection<FlightInfoPartial>();

            

            this.detailsPanel = detailsPanel;
        }
        //public void ShowAllFlights()
        //{
        //    if (SelectedFlights.Count > 0)
        //    {
        //        FIPModel.RefreshListsOfFlights();
        //        SelectedFlights = new ObservableCollection<FlightInfoPartial>();
        //    }
        //    foreach (FlightInfoPartial flight in FIPModel.InComingflights)
        //        SelectedFlights.Add(flight);

        //    foreach (FlightInfoPartial flight in FIPModel.OutGoingflights)
        //        SelectedFlights.Add(flight);

        //}
        
        public void FindFlightsAtRangeOfDates(DateTime FromDate,DateTime UntilDate)
        {
            var flights = FIPModel.FlightByDates(FromDate, UntilDate);
            SelectedFlights.Clear();
            if (flights != null)
            {   
                foreach (FlightInfoPartial f in flights)
                    SelectedFlights.Add(f);
            }
        }

        //private void ShowData(ObservableCollection<FlightInfoPartial> selectedFlights)
        //{
        //    detailsPanel.DataContext = SelectedFlights;
        //}

        public void ShowData(FlightInfoPartial selectedFlight)
        {
            detailsPanel.DataContext = selectedFlight;
        }
    }
}
