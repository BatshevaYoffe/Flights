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
            List<FlightInfoPartial> flights = new List<FlightInfoPartial>();
            using (var ctx = new FlightContext())
            {
                foreach (var flight in ctx.Flights)
                {
                    if (flight.DateTime.Date >= FDate.Date && flight.DateTime.Date <= LDate.Date)
                    {
                        flights.Add(flight);
                    }
                }
                //flights = (from f in ctx.Flights where (f.DateTime.Date >= FDate.Date &&f.DateTime.Date<= LDate.Date) select f).ToList<FlightInfoPartial>();
                
            }

            if (flights.Count > 0) 
                return flights;
            return null ;
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
