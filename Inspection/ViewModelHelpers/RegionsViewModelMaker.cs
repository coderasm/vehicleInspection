using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Inspection.Models;

namespace Inspection.ViewModelHelpers
{
    public class RegionsViewModelMaker : ViewModelMaker
    {
        private IEnumerable<FlooredCarFlat> flooredCarsFlat;
        public List<InspectionRegion> Regions { get; private set; } 

        public RegionsViewModelMaker(IEnumerable<FlooredCarFlat> flooredCarsFlat)
        {
            this.flooredCarsFlat = flooredCarsFlat;
            Regions = new List<InspectionRegion>();
        }
        public object make()
        {
            Regions = extractDistinctRegions();
            attachDistinctDealersToRegions();
            //attachFlooredCarsToDealers();
            return Regions;
        }

        public List<InspectionRegion> extractDistinctRegions()
        {
            return flooredCarsFlat.Select(Mapper.Map<InspectionRegion>).Distinct().ToList();
        }

        public List<InspectionRegion> attachDistinctDealersToRegions()
        {
            
        }
    }
}
