using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TruckTour.BLL.Tests
{
    [TestClass]
    public class PumpStationTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_InvalidIndex_ArgumentException()
        {
            new PumpStation(-1, 1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_InvalidPetrol_ArgumentException()
        {
            new PumpStation(1, 0, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_InvalidDistanceToNextStation_ArgumentException()
        {
            new PumpStation(1, 1, 0);
        }

        [TestMethod]
        public void Constructor_ValidParams_PropertiesAssignedCorrectly()
        {
            var station = new PumpStation(1, 2, 3);
            Assert.AreEqual(1, station.Index);
            Assert.AreEqual(2, station.Petrol);
            Assert.AreEqual(3, station.DistanceToNextStation);
            Assert.AreEqual(-1, station.PetrolAfterReachingNextStationFromHere);
            Assert.IsFalse(station.HasEnoughPetrolToReachNextStationFromHere);
        }

        [TestMethod]
        public void Equals_StationsWithSameIndex_True()
        {
            var station1 = new PumpStation(1, 2, 3);
            var station2 = new PumpStation(1, 3, 4);
            Assert.IsTrue(Equals(station1, station2));
        }

        [TestMethod]
        public void Equals_StationsWithDifferentIndex_False()
        {
            var station1 = new PumpStation(1, 2, 3);
            var station2 = new PumpStation(5, 3, 4);
            Assert.IsFalse(Equals(station1, station2));
        }
    }
}
