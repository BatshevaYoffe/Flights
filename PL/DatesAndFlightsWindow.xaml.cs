using FlightModel;
using PL.VM;
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
using System.Windows.Shapes;

namespace PL
{
    /// <summary>
    /// Interaction logic for DatesAndFlightsWindow.xaml
    /// </summary>
    public partial class DatesAndFlightsWindow : Window
    {
        SelectDatesVM vm { get; set; }
        public DatesAndFlightsWindow()
        {
            InitializeComponent();
            vm = new VM.SelectDatesVM(DetailsPanel);
            this.DataContext = vm;
        }

        private void selectedDates(object sender, SelectionChangedEventArgs e)
        {
            List<DateTime> Dates=(sender as Calendar).SelectedDates.ToList();
            DateTime f = Dates[0];
            DateTime l = Dates[Dates.Count-1];
            vm.FindFlightsAtRangeOfDates(f,l);

        }
        private void FlightsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FlightInfoPartial SelectedFlight = e.AddedItems[0] as FlightInfoPartial;
            vm.ShowData(SelectedFlight);
        }
    }
}
