using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Inspection.Models;

namespace Inspection.DataAccess
{
    public class FlooredCarsDAO : FlooredCarRepository
    {
        private readonly FlooredCarFlatRepository internalBaseRepository;

        public FlooredCarsDAO(FlooredCarFlatRepository internalBaseRepository)
        {
            this.internalBaseRepository = internalBaseRepository;
        }

        public async Task<IEnumerable<FlooredCar>> getAll()
        {
            var flooredCarsFlat = await internalBaseRepository.getAll();
            return mapToFlooredCars(flooredCarsFlat);
        }

        public IEnumerable<FlooredCar> mapToFlooredCars(IEnumerable<FlooredCarFlat> flooredCarsFlat)
        {
            return flooredCarsFlat.Select(Mapper.Map<FlooredCar>);
        }


        public async Task<FlooredCar> getById(int id)
        {
            var flooredCarsFlat = await internalBaseRepository.getById(id);
            return mapToFlooredCar(flooredCarsFlat);
        }

        public FlooredCar mapToFlooredCar(FlooredCarFlat flooredCarFlat)
        {
            return Mapper.Map<FlooredCar>(flooredCarFlat);
        }

        public async Task<IEnumerable<FlooredCar>> getAllNeverInspected()
        {
            var flooredCarsFlat = await internalBaseRepository.getAllNeverInspected();
            return mapToFlooredCars(flooredCarsFlat);
        }

        public Task<IEnumerable<FlooredCar>> getAllByRegion(int regionId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<FlooredCar>> getAllByDealer(int dealerId)
        {
            throw new System.NotImplementedException();
        }
    }
}
