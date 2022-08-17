//using FlightModel;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Data.Entity;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DAL1
//{
//    public class ConectionToDB
//    {
//        //static void Main(string[] args)
//        //{
//        //    var f = new Flight1()
//        //    {
//        //        Id = -1,
//        //        Source = "TLV",
//        //        Destination = "JFK",
//        //        FlightCode = "1111",
//        //        DateTime = DateTime.Today,
//        //        AircraftRegistration = "12-axxx",
//        //        Airline = "wizz"

//        //    };
//        //    using (var ctx = new FlightContext1())
//        //    {
//        //        ctx.Flights.Add(f);
//        //        ctx.SaveChanges();
//        //    }
//        //}
//    }
//        //public void addFlight(FlightInfoPartial flight)
//        //{
//        //    using (var ctx = new FlightContext())
//        //    {
               

//        //        //var flight = new Flight()
//        //        //{ 
//        //        //    Id = -1,
//        //        //    FlightCode = flightIP.identification.callsign,
//        //        //    AircraftRegistration = flightIP.aircraft.registration,
//        //        //    Airline = flightIP.airline.name,
//        //        //    Source = flightIP.airport.origin.name,
//        //        //    Destination = flightIP.airport.destination.name,
//        //        //    DateTime = DateTime.Today
//        //        //};
//        //        //try
//        //        //{
//        //        //    if (ctx.Flights.Any(o => o.FlightCode == flight.FlightCode))
//        //        //    {
//        //        //        throw new Exception("this flight exist in the data base");
//        //        //    }
//        //        //}
//        //        //catch (Exception e)
//        //        //{
//        //        //    Debug.Print(e.Message);
//        //        //}

//        //        //ctx.Flights.Add(flight);
//        //        ctx.SaveChanges();
                
//        //    }
//        //}
//        //function to get flights that selected by date
//    //    List<FlightInfoPartial> returnFlightByDate(DateTime dateTime)
//    //    { 
//    //        using (var ctx = new FlightContext())
//    //        {
//    //            var flights = (from f in ctx.Flights where f.DateTime==dateTime select f ).ToList<FlightInfoPartial>();
//    //            return flights;
//    //        }
//    //    }


//    //}
//    public class FlightContext1 : DbContext
//    {
//        public FlightContext1() : base("FlightsDB")
//        {
//            Database.SetInitializer<FlightContext>(new CreateDatabaseIfNotExists<FlightContext>());
//        }

//        public DbSet<Flight1> Flights { get; set; }

//    }
//    public class Flight1
//    {
//        public int Id { get; set; }
//        public string FlightCode { get; set; }
//        public string AircraftRegistration { get; set; }
//        public string Airline { get; set; }
//        public string Source { get; set; }
//        public string Destination { get; set; }
//        public DateTime DateTime { get; set; }
//    }
//}
