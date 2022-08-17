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


               

                if (ctx.Flights.Any(o => o.SourceId == flight.SourceId))
                {
                    return;
                }



                
                ctx.Flights.Add(flight);
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
        
        public FlightContext() : base("FlightsDB")
        {

        }

        public DbSet<FlightInfoPartial> Flights { get; set; }

    }

    
}
