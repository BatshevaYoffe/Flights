using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Da
{
    public class Program
    {
        static void Main(string[] args)
        {
            var f = new Flight()
            {
                Id = -1,
                Source = "TLV",
                Destination = "JFK",
                FlightCode = "1111",
                DateTime = DateTime.Today,
                AircraftRegistration = "12-axxx",
                Airline = "wizz"

            };
            using (var ctx = new FlightContext())
            {
                ctx.Flights.Add(f);
                ctx.SaveChanges();
            }
        }
    }

    public class FlightContext : DbContext
    {
        public FlightContext() : base("FlightsDB")
        {
           // Database.SetInitializer<FlightContext>(new CreateDatabaseIfNotExists<FlightContext>());
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
