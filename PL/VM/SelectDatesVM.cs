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
        private RangeOfDatesModel RODModel;
        public ObservableCollection<FlightInfoPartial> SelectedFlights { get; set; }

        public StackPanel detailsPanel;

        public SelectDatesCommand SelectDates { get; set; }
        public DateTime FirstDate;//=17/08/2022;
        public DateTime LastDate;


        public SelectDatesVM(StackPanel detailsPanel)
        {
            RODModel=new RangeOfDatesModel();
            FIPModel = new FlightInfoPartialModel();
            SelectedFlights = new ObservableCollection<FlightInfoPartial>();

            //SelectDates.read += FindFlightsAtRanreOfDates;
            SelectDatesCommand SelectDates = new SelectDatesCommand();
            SelectDates.read += ShowAllFlights;

            this.detailsPanel = detailsPanel;
        }
        public void ShowAllFlights()
        {
            if (SelectedFlights.Count > 0)
            {
                FIPModel.RefreshListsOfFlights();
                SelectedFlights = new ObservableCollection<FlightInfoPartial>();
            }
            foreach (FlightInfoPartial flight in FIPModel.InComingflights)
                SelectedFlights.Add(flight);

            foreach (FlightInfoPartial flight in FIPModel.OutGoingflights)
                SelectedFlights.Add(flight);

        }
        //public DateTime FromDate
        //{

        //    get
        //    {
        //        return RODModel.FromDate;
        //    }
        //    set
        //    {
        //        RODModel.FromDate = value;
        //        OnPropertyChanged("dateFrom");
        //    }
        //}
        //public DateTime UntilDate
        //{
        //    get
        //    {
        //        return RODModel.UntilDate;
        //    }
        //    set
        //    {
        //        RODModel.UntilDate = value;
        //        OnPropertyChanged("dateUntil");
        //    }
        //}
        //protected void OnPropertyChanged([CallerMemberName] string name = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        //}

        //public void FindFlightsAtRangeOfDates()
        //{
        //    var flights = FIPModel.FlightByDates(FromDate, UntilDate);
        //    if (flights != null)
        //    {
        //        foreach (FlightInfoPartial flight in flights)
        //            SelectedFlights.Add(flight);
        //    }

        //}
        public void FindFlightsAtRangeOfDates(DateTime FromDate,DateTime UntilDate)
        {
            var flights = FIPModel.FlightByDates(FromDate, UntilDate);
            if (flights != null)
            {
                foreach (FlightInfoPartial flight in flights)
                    SelectedFlights.Add(flight);
            }
        }

        private void ShowData(ObservableCollection<FlightInfoPartial> selectedFlights)
        {
            detailsPanel.DataContext = SelectedFlights;
        }

        public void ShowData(FlightInfoPartial selectedFlight)
        {
            detailsPanel.DataContext = selectedFlight;
        }
    }
}
