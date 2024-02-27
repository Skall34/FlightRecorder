using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightRecorder
{
    public class Avion
    {
        public int Index { get; set; }
        public string? ICAO { get; set; }
        public string? Type { get; set; }
        public string? Immat { get; set; }
        public string? Localisation { get; set; }
        public string? Hub { get; set; }
        public int CoutHoraire { get; set; }
        public int Etat { get; set; }
        public int Status { get; set; }
        public string? Horametre { get; set; }
        public string? DernierUtilisateur { get; set; }
    }
}
