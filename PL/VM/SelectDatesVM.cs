using FlightModel;
using PL.Model;
using PL.VM.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PL.VM
{
    public class SelectDatesVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private FlightInfoPartialModel FIPModel;
        public ObservableCollection<FlightInfoPartial> SelectedFlights;
        public StackPanel detailsPanel;
        public OpenDAFWindowCommand SelectDates { get; set; }
        public DateTime FirstDate;//=17/08/2022;
        public DateTime LastDate;


        public SelectDatesVM(StackPanel detailsPanel)
        {
            FIPModel = new FlightInfoPartialModel();
            SelectedFlights = new ObservableCollection<FlightInfoPartial>();

            SelectDates.read += FindFlightsAtRanreOfDates;
            //SelectDatesCommand SelectDates = new SelectDatesCommand();
            // SelectDates.read +=;

            this.detailsPanel = detailsPanel;
        }

        public void FindFlightsAtRanreOfDates()//DateTime FirstDate, DateTime LastDate)
        {
            var flights = FIPModel.FlightByDates(FirstDate, LastDate);
            if (flights!= null)
            {
                foreach (FlightInfoPartial flight in flights)
                    SelectedFlights.Add(flight);
            }

        }

        public void ShowData(FlightInfoPartial selectedFlight)
        {
            detailsPanel.DataContext = selectedFlight;
        }
    }
}
