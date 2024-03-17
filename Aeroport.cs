﻿using FSUIPC;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FlightRecorder
{
    public class Fret
    {
        public float fret { get; set; }
    }

    public class Aeroport
    {
        public string? ident { get; set; }
        public string? type { get; set; }
        public string? name { get; set; }
        public string? municipality { get; set; }
        public double latitude_deg { get; set; }
        public double longitude_deg { get; set; }
        public double? elevation_ft { get; set; }
        public string? Piste { get; set; }
        public string? LongueurDePiste { get; set; }
        public string? TypeDePiste { get; set; }
        public string? Observations { get; set; }
        public string? Wikipedia_Link { get; set; }
        public float? fret { get; set; }

        private const string DBFILE = "aeroports.json";

        private static string DBFILEPATH;


        public Aeroport()
        {
        }

        private static void initPath()
        {
            // Get the application name
            string appName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

            // Get the path to the user's AppData folder
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            // Combine the AppData path with the folder name
            string fullPath = Path.Combine(appDataPath, appName);

            // Ensure the directory exists, if not, create it
            Directory.CreateDirectory(fullPath);

            DBFILEPATH = Path.Combine(fullPath, DBFILE);
        }

        public Aeroport(uint id, string _ident, string _type, string _name, double latitude, double longitude)
        {
            type = _type;
            name = _name;
            ident = _ident;
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
            initPath();
            long epoch = 0; // lastUpdateFileTime.ToFileTime();
            if (File.Exists(DBFILEPATH))
            {
                FileInfo fi = new FileInfo(DBFILEPATH);
                DateTime creationTime = fi.CreationTime;
                epoch = (long)(creationTime - new DateTime(1970, 1, 1)).TotalMilliseconds;
            }

            string url = baseUrl + "?query=airports&date=" + epoch.ToString();
            UrlDeserializer dataReader = new UrlDeserializer(url);
            List<Aeroport>? result;
            Logger.WriteLine("Fechting airport informations from server");
            result = await dataReader.FetchAirportsDataAsync(DBFILEPATH);
            //if no new airport database, just load the local one.
            if (result.Count == 0)
            {
                //no airports from the server, try to load the local database.
                if (File.Exists(DBFILEPATH))
                {
                    Logger.WriteLine("Loading local airport database");
                    //read the aeroports.json file.
                    StreamReader sr = new StreamReader(DBFILEPATH);
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

        public static async Task<float> fetchFreight(string baseUrl, string airportID)
        {

            string url = baseUrl + "?query=freight&airport=" + airportID;
            UrlDeserializer dataReader = new UrlDeserializer(url);
            float result;
            result = await dataReader.FetchFreightDataAsync();
            return result;
        }



        public static List<Aeroport>? deserializeAeroports(string jsonString)
        {
            ////desrialize the whole aiport list at once. But this is bad because if one airport is bad, the whole
            ////airport database is fucked up.
            //List<Aeroport>? aeroports = JsonConvert.DeserializeObject<List<Aeroport>>(jsonString);
            
            //instead, deserialize one by one, to skip any wrongly informed airport
            var data = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonString);
            List<Aeroport> aeroports = new List<Aeroport>();
            IFormatProvider provider = CultureInfo.InvariantCulture;

            //index to count the airports, to help finding a potential error in the airports.
            int i = 1;
            if (data != null)
            {
                foreach (Dictionary<string, string> item in data)
                {
                    try
                    {
                        Aeroport a = new Aeroport();
                        a.ident = item.GetValueOrDefault("ident", "unknown"+i);
                        a.type = item.GetValueOrDefault("type", "unknown" + i);
                        a.name = item.GetValueOrDefault("name", "unknown" + i);
                        a.municipality = item.GetValueOrDefault("municipality", "unknown" + i);
                        a.latitude_deg = double.Parse(item.GetValueOrDefault("latitude_deg", "0"),provider);
                        a.longitude_deg = double.Parse(item.GetValueOrDefault("longitude_deg", "0"), provider);
                        a.elevation_ft = double.Parse(item.GetValueOrDefault("ekevation_ft", "0"), provider);
                        a.Piste = item.GetValueOrDefault("Piste", "unknown" + i);
                        a.LongueurDePiste = item.GetValueOrDefault("LongueueDePiste", "? " + i);
                        a.TypeDePiste = item.GetValueOrDefault("TypeDePiste", "unknown" + i);
                        a.Observations = item.GetValueOrDefault("Observations", "unknown" + i);
                        a.Wikipedia_Link = item.GetValueOrDefault("Wikipedia_Link", "unknown" + i);
                        aeroports.Add(a);
                    }
                    catch (Exception ex)
                    {
                        //badly formed airport. trace it for fix, but skip it.
                        Logger.WriteLine("Error in airport DB, for entry " + i + " : " + ex.Message);
                    }
                    i++;
                }
            }
            return aeroports;
        }

        
        public static float deserializeFreight(string jsonString)
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
