using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TruckTour.BLL.Tests
{
    [TestClass]
    public class PathCalculatorTests
    {
        private readonly PathCalculator _pathCalculator;

        public PathCalculatorTests()
        {
            _pathCalculator = new PathCalculator();
        }

        [TestMethod]
        public void GetStartPumpStationIndex_NotEnoughPetrolToReachAllStations_Minus1()
        {
            var stations = new LinkedList<PumpStation>();
            stations.AddLast(new PumpStation(0, 2, 3));
            stations.AddLast(new PumpStation(1, 4, 5));
            stations.AddLast(new PumpStation(2, 6, 7));
            Assert.AreEqual(-1, _pathCalculator.GetStartPumpStationIndex(stations));
        }


        [TestMethod]
        public void GetStartPumpStationIndex_InputDataFromTestSite_ValidStartIndex()
        {
            //data given at
            //https://www.hackerrank.com/challenges/truck-tour/problem
            var stations = new LinkedList<PumpStation>();
            stations.AddLast(new PumpStation(0, 1, 5));
            stations.AddLast(new PumpStation(1, 10, 3));
            stations.AddLast(new PumpStation(2, 6, 7));
            Assert.AreEqual(1, _pathCalculator.GetStartPumpStationIndex(stations));
        }
    }
}
