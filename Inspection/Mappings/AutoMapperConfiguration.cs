using AutoMapper;
using Inspection.Models;

namespace Inspection.Mappings
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<FlooredCarFlat, FlooredCar>();
            Mapper.CreateMap<FlooredCarFlat, InspectionRegion>();
        }
    }
}