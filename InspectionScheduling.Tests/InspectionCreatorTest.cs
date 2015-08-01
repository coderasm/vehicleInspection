using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace InspectionScheduling.Tests
{
    [TestClass]
    public class InspectionCreatorTest
    {
        [TestMethod]
        public async Task TwoFlooredAndNeverInspectedCarsHaveInspectionsCreated()
        {
            var cars = new List<FlooredCar> { new FlooredCar(), new FlooredCar() }.AsEnumerable();
            var inspections = await createInspections(cars);
            Assert.AreEqual(cars.Count(), inspections.Count());
        }

        [TestMethod]
        public async Task ThreeFlooredAndNeverInspectedCarsHaveInspectionsCreated()
        {
            var cars = new List<FlooredCar> { new FlooredCar(), new FlooredCar(), new FlooredCar() }.AsEnumerable();
            var inspections = await createInspections(cars);
            Assert.AreEqual(cars.Count(), inspections.Count());
        }

        [TestMethod]
        private void FirstFoundInspectorInRegionIsAssignedToInspection()
        {
            var vid = 4444;
            var inspection = new Inspection(vid);
        }

        private async Task<IEnumerable<Inspection>> createInspections(IEnumerable<FlooredCar> cars)
        {
            var mockFlooredCarRepository = new Mock<FlooredCarRepository>();
            mockFlooredCarRepository.Setup(r => r.getAllNeverInspected()).Returns(Task.FromResult(cars));
            InspectionCreator inspectionCreator = new InspectionCreatorFromNewFloors(mockFlooredCarRepository.Object);
            return await inspectionCreator.createInspections();
        }
    }
}
