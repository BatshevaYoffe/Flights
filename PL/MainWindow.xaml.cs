 using BL;
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
        
        VM.ViewModel vm { get; set; }

        public MainWindow()//
        {
            InitializeComponent();
            vm = new VM.ViewModel(myMap,Resources, DetailsPanel,TodayStatus);
            this.DataContext = vm;
        }

        private void FlightsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FlightInfoPartial SelectedFlight = e.AddedItems[0] as FlightInfoPartial; //InFlightsListBox.SelectedItem as FlightInfoPartial;
            vm.UpdateFlight(SelectedFlight);

        }
        private void Pin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var pin = e.OriginalSource as Pushpin;
            MessageBox.Show(pin.ToolTip.ToString());
        }

        //לוח שנה
        private void DatePicker_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }
    }
}
