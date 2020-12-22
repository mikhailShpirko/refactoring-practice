using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TruckTour.BLL;

namespace TruckTour.Util.Tests
{
    [TestClass]
    public class LinkedListNodeExtensionsTests
    {
        private readonly LinkedList<PumpStation> _stations;

        public LinkedListNodeExtensionsTests()
        {
            _stations = new LinkedList<PumpStation>();
            _stations.AddLast(new PumpStation(0, 1, 5));
            _stations.AddLast(new PumpStation(1, 10, 3));
            _stations.AddLast(new PumpStation(2, 6, 7));
        }

        [TestMethod]
        public void PreviousOrLast_LastNode_PreviousNode()
        {
            var station = _stations.Last;
            var previous = station.PreviousOrLast();
            Assert.AreEqual(1, previous.Value.Index);
        }

        [TestMethod]
        public void PreviousOrLast_FirstNode_LastNode()
        {
            var station = _stations.First;
            var previous = station.PreviousOrLast();
            Assert.AreEqual(2, previous.Value.Index);
        }
    }
}
