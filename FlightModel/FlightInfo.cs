using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightModel
{
    public class FlightInfo
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Aircraft
        {
            public Model model { get; set; }
            public int countryId { get; set; }
            public string registration { get; set; }//רישום מטוסים 
            public string hex { get; set; }
            public object age { get; set; }
            public object msn { get; set; }
            public Images images { get; set; }
            public Identification identification { get; set; }
            public Airport airport { get; set; }
            public Time time { get; set; }
        }

        public class Airline
        {
            public string name { get; set; }
            public string @short { get; set; }
            public Code code { get; set; }
            public string url { get; set; }
        }

        public class Airport
        {
            public Origin origin { get; set; }
            public Destination destination { get; set; }
            public object real { get; set; }
        }

        public class Code
        {
            public string iata { get; set; }
            public string icao { get; set; }
        }

        public class Country
        {
            public object id { get; set; }
            public string name { get; set; }
            public string code { get; set; }
        }

        public class Destination
        {
            public string name { get; set; }
            public Code code { get; set; }
            public Position position { get; set; }
            public Timezone timezone { get; set; }
            public bool visible { get; set; }
            public string website { get; set; }
            public Info info { get; set; }
        }

        public class Estimated
        {
            public object departure { get; set; }
            public object arrival { get; set; }
        }

        public class FlightHistory
        {
            public List<Aircraft> aircraft { get; set; }
        }

        public class Generic
        {
            public Status status { get; set; }
        }

        public class Historical
        {
            public string flighttime { get; set; }
            public string delay { get; set; }
        }

        public class Identification
        {
            public string id { get; set; }
            public long row { get; set; }
            public Number number { get; set; }
            public string callsign { get; set; }
        }

        public class Images
        {
            public List<Thumbnail> thumbnails { get; set; }
            public List<Medium> medium { get; set; }
            public List<Large> large { get; set; }
        }

        public class Info
        {
            public string terminal { get; set; }
            public object baggage { get; set; }
            public object gate { get; set; }
        }

        public class Large
        {
            public string src { get; set; }
            public string link { get; set; }
            public string copyright { get; set; }
            public string source { get; set; }
        }

        public class Medium
        {
            public string src { get; set; }
            public string link { get; set; }
            public string copyright { get; set; }
            public string source { get; set; }
        }

        public class Model
        {
            public string code { get; set; }
            public string text { get; set; }
        }

        public class Number
        {
            public string @default { get; set; }
            public string alternative { get; set; }
        }

        public class Origin
        {
            public string name { get; set; }
            public Code code { get; set; }
            public Position position { get; set; }
            public Timezone timezone { get; set; }
            public bool visible { get; set; }
            public string website { get; set; }
            public Info info { get; set; }
        }

        public class Other
        {
            public int eta { get; set; }
            public int updated { get; set; }
        }

        public class Position
        {
            public double latitude { get; set; }
            public double longitude { get; set; }
            public int altitude { get; set; }
            public Country country { get; set; }
            public Region region { get; set; }
        }

        public class Real
        {
            public int departure { get; set; }
            public object arrival { get; set; }
        }

        public class Region
        {
            public string city { get; set; }
        }

        public class Root
        {
            public Identification identification { get; set; }
            public Status status { get; set; }
            public string level { get; set; }
            public bool promote { get; set; }
            public Aircraft aircraft { get; set; }
            public Airline airline { get; set; }
            public object owner { get; set; }
            public object airspace { get; set; }
            public Airport airport { get; set; }
            public FlightHistory flightHistory { get; set; }
            public object ems { get; set; }
            public List<string> availability { get; set; }
            public Time time { get; set; }
            public List<Trail> trail { get; set; }
            public int firstTimestamp { get; set; }
            public string s { get; set; }
        }

        public class Scheduled
        {
            public int departure { get; set; }
            public int arrival { get; set; }
        }

        public class Status
        {
            public bool live { get; set; }
            public string text { get; set; }
            public object icon { get; set; }
            public object estimated { get; set; }
            public bool ambiguous { get; set; }
            public Generic generic { get; set; }
            public string color { get; set; }
            public string type { get; set; }
        }

        public class Thumbnail
        {
            public string src { get; set; }
            public string link { get; set; }
            public string copyright { get; set; }
            public string source { get; set; }
        }

        public class Time
        {
            public Real real { get; set; }
            public Scheduled scheduled { get; set; }
            public Estimated estimated { get; set; }
            public Other other { get; set; }
            public Historical historical { get; set; }
        }

        public class Timezone
        {
            public string name { get; set; }
            public int offset { get; set; }
            public string offsetHours { get; set; }
            public string abbr { get; set; }
            public string abbrName { get; set; }
            public bool isDst { get; set; }
        }

        public class Trail
        {
            public double lat { get; set; }
            public double lng { get; set; }
            public int alt { get; set; }
            public int spd { get; set; }
            public int ts { get; set; }
            public int hd { get; set; }
        }


    }
}
