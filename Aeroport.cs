using FSUIPC;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FlightRecorder
{
    public class Fret
    {
        public int fret { get; set; }
    }

    public class Aeroport
    {
        public string? Ident { get; set; }
        public string? type { get; set; }
        public string name { get; set; }
        public string? municipality { get; set; }
        public double latitude_deg { get; set; }
        public double longitude_deg { get; set; }
        public int elevation_ft { get; set; }
        public string? Piste { get; set; }
        public string? LongueurDePiste { get; set; }
        public string? TypeDePiste { get; set; }
        public string? Observations { get; set; }
        public string? Wikipedia_Link { get; set; }
        public int fret { get; set; }

        private const string DBFILE = "aeroports.json";

        public Aeroport(uint id, string _ident, string _type, string _name, double latitude, double longitude)
        {
            type = _type;
            name = _name;
            Ident = _ident;
            latitude_deg = latitude;
            longitude_deg = longitude;
        }

        public double DistanceTo(double targetLatitude, double targetLongitude)
        {
            double earthRadius = 6371; // Earth's radius in kilometers

            double dLat = DegreeToRadian(targetLatitude - latitude_deg);
            double dLon = DegreeToRadian(targetLongitude - longitude_deg);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(DegreeToRadian(latitude_deg)) * Math.Cos(DegreeToRadian(targetLatitude)) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            double distance = earthRadius * c;

            return distance;
        }
        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        public static Aeroport? FindClosestAirport(List<Aeroport> airports, double targetLatitude, double targetLongitude)
        {
            Aeroport? closestAirport = null;
            double shortestDistance = double.MaxValue;

            foreach (var airport in airports)
            {
                double distance = airport.DistanceTo(targetLatitude, targetLongitude);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    closestAirport = airport;
                }
            }
            return closestAirport;
        }

        public static async Task<List<Aeroport>> fetchAirports(string baseUrl, DateTime lastUpdateFileTime)
        {
            long epoch = 0; // lastUpdateFileTime.ToFileTime();
            if (File.Exists(DBFILE))
            {
                FileInfo fi = new FileInfo(DBFILE);
                DateTime creationTime = fi.CreationTime;
                epoch = (long)(creationTime - new DateTime(1970, 1, 1)).TotalMilliseconds;
            }

            string url = baseUrl + "?query=airports&date=" + epoch.ToString();
            UrlDeserializer dataReader = new UrlDeserializer(url);
            List<Aeroport>? result;
            result = await dataReader.FetchAirportsDataAsync(DBFILE);
            if (result == null)
            {
                //no airports from the server, try to load the local database.
                if (File.Exists(DBFILE))
                {
                    //read the aeroports.json file.
                    StreamReader sr = new StreamReader(DBFILE);
                    string allData = sr.ReadToEnd();
                    result = deserializeAeroports(allData);
                    if (null == result)
                    {
                        result = new List<Aeroport>();
                    }
                }
                else
                {
                    //no data from server and no local file available... it sucks....
                    result = new List<Aeroport>();
                }
            }
            return result;
        }

        public static async Task<int> fetchFreight(string baseUrl, string airportID)
        {

            string url = baseUrl + "?query=freight&airport=" + airportID;
            UrlDeserializer dataReader = new UrlDeserializer(url);
            int result;
            result = await dataReader.FetchFreightDataAsync();
            return result;
        }



        public static List<Aeroport>? deserializeAeroports(string jsonString)
        {
            //var data = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonString);
            List<Aeroport>? aeroports = JsonConvert.DeserializeObject<List<Aeroport>>(jsonString);
            return aeroports;
        }

        
        public static int deserializeFreight(string jsonString)
        {
            //var data = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonString);
            Fret? result = JsonConvert.DeserializeObject<Fret>(jsonString);
            if (null != result)
            {
                return result.fret;
            }
            else
            {
                return -1;
            }
        }
    }

}
