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
        public void addFlight(FlightInfo.Root flightIP)
        {
            using (var ctx = new FlightContext())
            {
                var f = new Flight() {Id=-1, Source="TLV", Destination= "JFK",FlightCode= "1111",DateTime= DateTime.Today
                ,AircraftRegistration="12-axxx",Airline="wizz"
                };

                var flight = new Flight
                {
                    Id = -1,
                    FlightCode = flightIP.identification.callsign,
                    AircraftRegistration = flightIP.aircraft.registration,
                    Airline = flightIP.airline.name,
                    Source = flightIP.airport.origin.name,
                    Destination = flightIP.airport.destination.name,
                    DateTime = DateTime.Today
                };
                if (ctx.Flights.Find(flight.FlightCode) == null)
                {
                    ctx.Flights.Add(flight);
                    ctx.SaveChanges();
                }
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
        public int Id { get; set; }
        public string FlightCode { get; set; }
        public string AircraftRegistration { get; set; }
        public string Airline { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public DateTime DateTime { get; set; }
    }
}
