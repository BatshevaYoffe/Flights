using FlightModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ConectionToDB
    {
        void addFlight(FlightInfoPartial flightIP)
        {
            using (var ctx = new FlightContext())
            {
                var f = new Flight() { Source="TLV", Destination= "JFK",FlightCode= "1111",DateTime= DateTime.Now };
                var flight = new Flight() { FlightCode = flightIP.FlightCode, Source = flightIP.Source, Destination = flightIP.Destination, DateTime = flightIP.DateTime };
                ctx.Flights.Add(flight);
                ctx.SaveChanges();
            }
        }
        //function to get flights that selected by date
        List<Flight> returnFlightByDate(DateTime dateTime)
        { 
            using (var ctx = new FlightContext())
            {
                var flights = (from f in ctx.Flights where f.DateTime==dateTime select f ).ToList<Flight>();
                return flights;
            }
        }


    }
    public class FlightContext : DbContext
    {
        public FlightContext() : base("FlightsDB")
        {

        }

        public DbSet<Flight> Flights { get; set; }

    }
    public class Flight
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public string FlightCode { get; set; }
        public DateTime DateTime { get; set; }
    }
}
