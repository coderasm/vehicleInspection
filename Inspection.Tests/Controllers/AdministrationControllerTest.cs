using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using DataAccess;
using DataAccess.Models;
using Inspection.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inspection.Controllers;
using Moq;

namespace Inspection.Tests.Controllers
{
    [TestClass]
    public class AdministrationControllerTest
    {
        [TestMethod]
        public async Task AllFlooredCarsAreReturned()
        {
            var cars = new List<FlooredCar> {new FlooredCar(), new FlooredCar()}.AsEnumerable();
            var mockFlooredCarRepository = new Mock<FlooredCarRepository>();
            mockFlooredCarRepository.Setup(r => r.getAll()).Returns(Task.FromResult(cars));
            var administrationController = new AdministrationController(mockFlooredCarRepository.Object);
            var result = await administrationController.Floored() as ViewResult;
            var flooredCars = result.Model as IEnumerable<FlooredCar>;
            Assert.AreEqual(flooredCars.Count(), 2);
        }
    }
}
