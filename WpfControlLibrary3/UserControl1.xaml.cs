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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfControlLibrary3
{
    public partial class UserControl1 : UserControl
    {
        SelectDatesVM vm { get; set; }
        //SelectDatesVM SelectDatesVM = new SelectDatesVM(detailsPanel);

        public UserControl1()
        {
            InitializeComponent();
            vm = new PL.VM.SelectDatesVM(DetailsPanel);
            this.DataContext = vm;
        }
        private void selectedDates(object sender, SelectionChangedEventArgs e)
        {
            List<DateTime> Dates = (sender as Calendar).SelectedDates.ToList();
            DateTime f = Dates[0];
            DateTime l = Dates[Dates.Count - 1];
            vm.FindFlightsAtRangeOfDates(f, l);

        }
        private void FlightsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FlightInfoPartial SelectedFlight = e.AddedItems[0] as FlightInfoPartial;
            vm.ShowData(SelectedFlight);
        }
    }
}
