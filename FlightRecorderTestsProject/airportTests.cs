using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlightRecorder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;

namespace FlightRecorder.Tests
{
    [TestClass()]
    public class airportTests
    {

        [TestMethod()]
        public void DistanceToTest()
        {
            Aeroport lfmt = new Aeroport(0, "LFMT", "airport", "Montpellier", 43.57619857788086, 3.96301007270813);
            Aeroport lfng = new Aeroport(0, "LFNG", "airport", "Candillargues", 43.610298, 4.07028);
            double distance = lfng.DistanceTo(lfmt.latitude_deg, lfmt.longitude_deg);

            //a distance is always positive
            Assert.IsTrue(distance > 0);
            // LFMT <-> LFNG  = 9.4342819308083179
            Assert.IsTrue(distance < 10);
        }


        [TestMethod()]
        public void FindClosestAirportTest()
        {
            Aeroport lfmt = new Aeroport(0, "LFMT", "airport", "Montpellier", 43.57619857788086, 3.96301007270813);
            Aeroport lfng = new Aeroport(0, "LFNG", "airport", "Candillargues", 43.610298, 4.07028);
            Aeroport kjfk = new Aeroport(0, "KJFK", "airport", "New-york JFK", 40.639447, -73.779317);
            
            List<Aeroport> aeroports=new List<Aeroport>();
            aeroports.Add(kjfk);
            aeroports.Add(lfmt);
            aeroports.Add(lfng);

            Aeroport? closest = Aeroport.FindClosestAirport(aeroports, 43.58, 3.97);
            Assert.IsNotNull(closest);
            Assert.IsTrue(closest.Ident == "LFMT");
        }

        //[TestMethod()]
        //public void LoadAirportsFromCsvTest()
        //{
        //    airportsMgr mgr = new airportsMgr("airports_tests.csv");
        //    Assert.IsTrue(mgr.Airports.Count>0);
        //}
    }
}