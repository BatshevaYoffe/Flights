using FlightModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL1
{
    public class ConectionToTheDataBase
    {

        public void AddFlight(FlightInfoPartial flight)
        {
            using (var ctx = new FlightContext())
            {


                var flight1 = new Flight()
                {
                    Id = flight.Id,
                    Source = flight.Source,
                    SourceId = flight.SourceId,
                    Lat = flight.Lat,
                    Long = flight.Long,
                    DateTime = flight.DateTime,
                    FlightCode = flight.FlightCode,
                    Destination = flight.Destination,
                };

                if (ctx.Flights.Any(o => o.SourceId == flight.SourceId))
                {
                    return;
                }



                ctx.Flights.Add(flight1);
                ctx.SaveChanges();

            }
        }
    }


    ////  function to get flights that selected by date
    //      public List<FlightInfoPartial> ReturnFlightByDate(DateTime dateTime)
    //      {
    //           using (var ctx = new FlightContext())
    //           {
    //          var flights = (from f in ctx.Flights where f.DateTime == dateTime select f).ToList<FlightInfoPartial>();
    //          return flights;
    //           }
    //      }



    public class FlightContext : DbContext
    {
        public FlightContext() : base("FlightsDB1")
        {

        }

        public DbSet<Flight> Flights { get; set; }

    }

    public class Flight
    {//לתקן זה זמני לבדוק אם עובד בכלל
        public int Id { get; set; }
        public string SourceId { get; set; }
        public double Long { get; set; }
        public double Lat { get; set; }
        public DateTime DateTime { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string FlightCode { get; set; }
        //public int Id { get; set; }
        //public string FlightCode { get; set; }
        //public string AircraftRegistration { get; set; }
        //public string Airline { get; set; }
        //public string Source { get; set; }
        //public string Destination { get; set; }
        //public DateTime DateTime { get; set; }
    }
}

