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
            airport lfmt = new airport(0, "LFMT", "airport", "Montpellier", 43.57619857788086, 3.96301007270813, "LFMT");
            airport lfng = new airport(0, "LFNG", "airport", "CAndillargues", 43.610298, 4.07028, "LFMT");
            double distance = lfng.DistanceTo(lfmt.Latitude, lfmt.Longitude);

            //a distance is always positive
            Assert.IsTrue(distance > 0);
            // LFMT <-> LFNG  = 9.4342819308083179
            Assert.IsTrue(distance < 10);
        }

        [TestMethod()]
        public void addAirportTest()
        {
            airportsMgr mgr = new airportsMgr();
            airport lfmt = new airport(0, "LFMT", "airport", "Montpellier", 43.57619857788086, 3.96301007270813, "LFMT");
            airport lfng = new airport(0, "LFNG", "airport", "CAndillargues", 43.610298, 4.07028, "LFMT");

            mgr.addAirport(lfmt);
            mgr.addAirport(lfng);

            Assert.IsTrue(mgr.Airports.Count == 2);
        }

        [TestMethod()]
        public void FindClosestAirportTest()
        {
            airportsMgr mgr = new airportsMgr();
            airport lfmt = new airport(0, "LFMT", "airport", "Montpellier", 43.57619857788086, 3.96301007270813, "LFMT");
            airport lfng = new airport(0, "LFNG", "airport", "CAndillargues", 43.610298, 4.07028, "LFMT");
            airport kjfk = new airport(0, "KJFK", "airport", "New-york JFK", 40.639447, -73.779317, "KJFK");

            mgr.addAirport(lfmt); //montpellier
            mgr.addAirport(lfng); //candillargues
            mgr.addAirport(kjfk); //new york

            airport closest = mgr.FindClosestAirport(43.58, 3.97);
            Assert.IsTrue(closest.Ident == "LFMT");
        }

        [TestMethod()]
        public void LoadAirportsFromCsvTest()
        {
            airportsMgr mgr = new airportsMgr("airports_tests.csv");
            Assert.IsTrue(mgr.Airports.Count>0);
        }
    }
}