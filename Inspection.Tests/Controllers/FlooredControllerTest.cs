using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Inspection.Controllers;
using Inspection.DataAccess;
using Inspection.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Inspection.Tests.Controllers
{
    [TestClass]
    public class FlooredControllerTest
    {
        [TestMethod]
        public void GetTest()
        {
            var flooredCarsFlat = new List<FlooredCarFlat>
            {
                new FlooredCarFlat {RegionId = 1, RegionName = "Region1", DealerId = 1, DealerName = "Dealer1", VehicleId = 0},
                new FlooredCarFlat {RegionId = 1, RegionName = "Region1", DealerId = 1, DealerName = "Dealer2", VehicleId = 1},
                new FlooredCarFlat {RegionId = 2, RegionName = "Region2", DealerId = 2, DealerName = "Dealer3", VehicleId = 2}
            };
            var fakeFlooredCarRepository = new Mock<FlooredCarFlatRepository>();
            fakeFlooredCarRepository.Setup(repo => repo.getAll()).Returns(Task.FromResult(flooredCarsFlat));
            var controller = new FlooredController(fakeFlooredCarRepository.Object);
            Assert.AreEqual(2, controller.Get());
        }
    }
}
