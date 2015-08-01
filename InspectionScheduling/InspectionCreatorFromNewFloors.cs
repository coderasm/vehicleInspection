using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Models;

namespace InspectionScheduling
{
    public class InspectionCreatorFromNewFloors : InspectionCreator
    {
        private FlooredCarRepository flooredCarRepository;

        public InspectionCreatorFromNewFloors(FlooredCarRepository flooredCarRepository)
        {
            this.flooredCarRepository = flooredCarRepository;
        }
        public async Task<IEnumerable<Inspection>> createInspections()
        {
            var newlyFloored = await flooredCarRepository.getAllNeverInspected();
            return createInspections(newlyFloored);
        }

        private List<Inspection> createInspections(IEnumerable<FlooredCar> newlyFloored)
        {
            return newlyFloored.Select(flooredCar => new Inspection(flooredCar.VehicleId)).ToList();
        }
    }
}
