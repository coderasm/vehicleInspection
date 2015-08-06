using System;
using System.Collections.Generic;
using Inspection.Mappings;
using Inspection.Models;
using Inspection.ViewModelHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inspection.Tests
{
    [TestClass]
    public class RegionsViewModelMakerTest
    {
        [TestInitialize]
        public void SetUp()
        {
            AutoMapperConfiguration.Configure();
        }

        [TestMethod]
        public void GivenTwoCarsFromDistinctRegionsTwoInspectionRegionsAreCreated()
        {
            var flatCars = new List<FlooredCarFlat>
            {
                new FlooredCarFlat {RegionId = 1, RegionName = "Someone"},
                new FlooredCarFlat {RegionId = 2, RegionName = "Everyone"}
            };

            var regionsViewModelMaker = new RegionsViewModelMaker(flatCars);
            var flooredCars = regionsViewModelMaker.extractDistinctRegions();
            Assert.AreEqual(flatCars[0].RegionId, flooredCars[0].RegionId);
            Assert.AreEqual(flatCars[1].RegionId, flooredCars[1].RegionId);
            Assert.IsInstanceOfType(flooredCars[0], typeof(InspectionRegion));
            Assert.IsInstanceOfType(flooredCars[1], typeof(InspectionRegion));
        }
    }
}
