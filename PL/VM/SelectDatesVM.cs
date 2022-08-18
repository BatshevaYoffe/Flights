﻿using FlightModel;
using PL.Model;
using PL.VM.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PL.VM
{
    public class SelectDatesVM
    {
        private FlightInfoPartialModel FIPModel;
        public ObservableCollection<FlightInfoPartial> SelectedFlights;

        public SelectDatesVM(StackPanel detailsPanel)
        {
            FIPModel = new FlightInfoPartialModel();
            SelectedFlights = new ObservableCollection<FlightInfoPartial>();

            SelectDatesCommand SelectDates = new SelectDatesCommand();
            // SelectDates.read +=;
        }

        public void FindFlightsAtRanreOfDates(DateTime FirstDate, DateTime LastDate)
        {
            var flights = FIPModel.FlightByDates(FirstDate, LastDate);
            if (flights!= null)
            {
                foreach (FlightInfoPartial flight in flights)
                    SelectedFlights.Add(flight);
            }

        }
        


    }
}