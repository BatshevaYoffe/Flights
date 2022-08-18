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
        public List<FlightInfoPartial> ReturnFlightsByDates(DateTime FDate, DateTime LDate)
        {
            List<FlightInfoPartial> flights = null;
            using (var ctx = new FlightContext())
            {
                flights = (from f in ctx.Flights where (f.DateTime >= FDate &&f.DateTime<= LDate) select f).ToList<FlightInfoPartial>();
                
            }

            return flights;
        }
    }


    
    



    public class FlightContext : DbContext
    {
        
        public FlightContext() : base("FlightsDB")
        {

        }

        public DbSet<FlightInfoPartial> Flights { get; set; }

    }

    
}
