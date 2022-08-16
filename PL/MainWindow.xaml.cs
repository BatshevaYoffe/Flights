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
            vm = new VM.ViewModel(myMap,Resources);
            //vm(myMap, Resources);
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
            vm.UpdateFlight(SelectedFlight);
            Counter.Text = (Convert.ToInt32(Counter.Text) + 1).ToString();
        }

        private void FlightsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedFlight = e.AddedItems[0] as FlightInfoPartial; //InFlightsListBox.SelectedItem as FlightInfoPartial;
            vm.UpdateFlight(SelectedFlight);

        }
        private void Pin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var pin = e.OriginalSource as Pushpin;
            MessageBox.Show(pin.ToolTip.ToString());
        }


        private void DatePicker_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }
    }
}
