using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightRecorder
{
    public class AirportsFromFic
    {
        public string ICAO { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Municipality { get; set; }
        public double LatitudeDeg { get; set; }
        public double LongitudeDeg { get; set; }
        public int ElevationFt { get; set; }
        public string Piste { get; set; }
        public string LongueurDePiste { get; set; }
        public string TypeDePiste { get; set; }
        public string Observations { get; set; }
        public string WikipediaLink { get; set; }
        public int Fret { get; set; }
        public int Pax { get; set; }
    }
}
