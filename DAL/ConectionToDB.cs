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
        void addFlight(FlightInfoPartial flight)
        {
            using (var ctx = new FlightContext())
            {
                ctx.Flights.Add(flight);
                ctx.SaveChanges();
            }
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
