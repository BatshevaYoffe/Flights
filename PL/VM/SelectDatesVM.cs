using PL.Model;
using PL.VM.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.VM
{
    public class SelectDatesVM
    {
        private FlightInfoPartialModel FIPModel;

        public SelectDatesVM()
        {
             FIPModel = new FlightInfoPartialModel();
           
            SelectDatesCommand SelectDates = new SelectDatesCommand();
           // SelectDates.read +=;
        }


    }
}
