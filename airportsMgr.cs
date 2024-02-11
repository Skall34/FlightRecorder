using FSUIPC;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightRecorder
{

    public class airport
    {
        public string Name { get; set; }
        public string Ident { get; set; }
        public string local_code { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        //"id","ident","type","name","latitude_deg","longitude_deg","elevation_ft",
        //"continent","iso_country","iso_region","municipality","scheduled_service",
        //"gps_code","iata_code","local_code","home_link","wikipedia_link","keywords"

        public airport(uint id, string ident, string type, string name,  double latitude, double longitude,string _code)
        {
            Name = name;
            Ident = ident;
            local_code = _code;
            Latitude = latitude;
            Longitude = longitude;
        }

        public double DistanceTo(double targetLatitude, double targetLongitude)
        {
            double earthRadius = 6371; // Earth's radius in kilometers

            double dLat = DegreeToRadian(targetLatitude - Latitude);
            double dLon = DegreeToRadian(targetLongitude - Longitude);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(DegreeToRadian(Latitude)) * Math.Cos(DegreeToRadian(targetLatitude)) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            double distance = earthRadius * c;

            return distance;
        }
        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
    public class airportsMgr
    {
        private List<airport> airports;

        public IReadOnlyList<airport> Airports => airports;

        public airportsMgr()
        {
            airports = new List<airport>();
        }

        public airportsMgr(string filePath)
        {
            airports = new List<airport>();
            LoadAirportsFromCsv(filePath);
        }

        public bool addAirport(airport newAirport)
        {
            bool result = false;
            if (airports.Count > 0)
            {
                airport closest = FindClosestAirport(newAirport.Latitude, newAirport.Longitude);
                if (closest != null)
                {
                    double dist = closest.DistanceTo(newAirport.Latitude, newAirport.Longitude);
                    //Do NOT add an airport which would too close to another airport
                    if (dist > 8)
                    {
                        airports.Add(newAirport);
                        result = true;
                    }
                }
            }
            else
            {
                airports.Add(newAirport);
            }
            return result;
        }

        public airport FindClosestAirport(double targetLatitude, double targetLongitude)
        {
            airport closestAirport = null;
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

        public void LoadAirportsFromCsv(string filePath)
        {
            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    // Skip the first line (header)
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        try
                        {
                            string line = reader.ReadLine();
                            var values = line.Split(',');

                            if (values.Length >= 4)
                            {
                                //"id","ident","type","name","latitude_deg","longitude_deg","elevation_ft",
                                //"continent","iso_country","iso_region","municipality","scheduled_service",
                                //"gps_code","iata_code","local_code","home_link","wikipedia_link","keywords"
                                uint id = uint.Parse(values[0]);
                                string ident = values[1]; ;
                                string airportType = values[2];
                                string name= values[3];
                                double latitude_deg = double.Parse(values[4], NumberStyles.Any, CultureInfo.InvariantCulture);
                                double longitude_deg = double.Parse(values[5], NumberStyles.Any, CultureInfo.InvariantCulture);
                                string iata_code = values[14];

                                    airports.Add(new airport(id,ident,airportType,name,latitude_deg,longitude_deg,iata_code));
                            }
                        }catch(Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading airports from CSV: {ex.Message}");
            }
        }
    }
}
