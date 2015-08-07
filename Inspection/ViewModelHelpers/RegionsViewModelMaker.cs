using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Inspection.Models;
using Microsoft.Ajax.Utilities;

namespace Inspection.ViewModelHelpers
{
    public class RegionsViewModelMaker : ViewModelMaker
    {
        private readonly IEnumerable<FlooredCarFlat> flooredCarsFlat;
        public List<InspectionRegion> regions { get; private set; }

        public RegionsViewModelMaker(IEnumerable<FlooredCarFlat> flooredCarsFlat)
        {
            this.flooredCarsFlat = flooredCarsFlat;
            regions = new List<InspectionRegion>();
        }
        public object make()
        {
            extractDistinctRegions();
            attachDistinctDealersToRegions();
            attachFlooredCarsToDealers();
            return regions;
        }

        public List<InspectionRegion> extractDistinctRegions()
        {
            regions = flooredCarsFlat.Select(Mapper.Map<InspectionRegion>)
                                  .DistinctBy(flooredCarFlat => flooredCarFlat.RegionId)
                                  .ToList();
            return regions;
        }

        public List<InspectionRegion> attachDistinctDealersToRegions()
        {
            regions.ForEach(attachDealersToRegion);
            return regions;
        }

        private void attachDealersToRegion(InspectionRegion region)
        {
            region.Dealers = flooredCarsFlat.Select(Mapper.Map<Dealer>)
                                            .Where(dealer => dealer.RegionId == region.RegionId)
                                            .DistinctBy(dealer => dealer.DealerId)
                                            .ToList();
        }

        public List<InspectionRegion> attachFlooredCarsToDealers()
        {
            regions.ForEach(region => region.Dealers.ForEach(attachFlooredCarsToDealer));
            return regions;
        }

        private void attachFlooredCarsToDealer(Dealer dealer)
        {
            dealer.FlooredCars = flooredCarsFlat.Select(Mapper.Map<FlooredCar>)
                .Where(flooredCar => flooredCar.DealerId == dealer.DealerId)
                .DistinctBy(flooredCar => flooredCar.VehicleId)
                .ToList();
        }
    }
}
