﻿using BL;
using FlightModel;
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

namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FlightInfoPartial SelectedFlight = null; //Selected Flight
        IBL bl = new BLImp();

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //load current data
            // this.DataContext = FlightKeys;
            InFlightsListBox.DataContext = bl.GetCurrentInComingFlights();
            OutFlightsListBox.DataContext = bl.GetCurrentOutGoingFlights();

        }

        private void FlightsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
