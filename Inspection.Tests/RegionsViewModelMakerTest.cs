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
        private List<FlooredCarFlat> flooredCarsFlat;
        private RegionsViewModelMaker regionsViewModelMaker;

        [TestInitialize]
        public void SetUp()
        {
            AutoMapperConfiguration.Configure();
            flooredCarsFlat = new List<FlooredCarFlat>
            {
                new FlooredCarFlat {RegionId = 1, RegionName = "Region1", DealerId = 1, DealerName = "Dealer1", VehicleId = 0},
                new FlooredCarFlat {RegionId = 1, RegionName = "Region1", DealerId = 1, DealerName = "Dealer2", VehicleId = 1},
                new FlooredCarFlat {RegionId = 2, RegionName = "Region2", DealerId = 2, DealerName = "Dealer3", VehicleId = 2}
            };
            regionsViewModelMaker = new RegionsViewModelMaker(flooredCarsFlat);
        }

        [TestMethod]
        public void GivenTwoCarsFromDistinctRegionsTwoInspectionRegionsAreCreated()
        {
            var regions = regionsViewModelMaker.extractDistinctRegions();
            Assert.AreEqual(2, regions.Count);
            Assert.AreEqual(flooredCarsFlat[0].RegionId, regions[0].RegionId);
            Assert.AreEqual(flooredCarsFlat[2].RegionId, regions[1].RegionId);
            Assert.IsInstanceOfType(regions[0], typeof(InspectionRegion));
            Assert.IsInstanceOfType(regions[1], typeof(InspectionRegion));
        }

        [TestMethod]
        public void GivenTwoCarsFromSameDealerTheDealerIsOnlyAddedOnceToTheRegion()
        {
            var regions = regionsViewModelMaker.extractDistinctRegions();
            regionsViewModelMaker.attachDistinctDealersToRegions();
            Assert.AreEqual(1, regions[0].Dealers.Count);
        }

        [TestMethod]
        public void GivenTwoCarsFromSameDealerTwoCarsAreAddedToTheDealer()
        {
            var regions = regionsViewModelMaker.extractDistinctRegions();
            regionsViewModelMaker.attachDistinctDealersToRegions();
            regionsViewModelMaker.attachFlooredCarsToDealers();
            Assert.AreEqual(2, regions[0].Dealers[0].FlooredCars.Count);
        }

        [TestMethod]
        public void GivenAListOfFlooredCarsAListOfRegionViewModelsIsCreated()
        {
            var regions = (List<InspectionRegion>)regionsViewModelMaker.make();
            Assert.AreEqual(2, regions.Count);
            Assert.AreEqual(2, regions[0].Dealers.Count + regions[1].Dealers.Count);
        }
    }
}
