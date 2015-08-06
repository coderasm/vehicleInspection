using System.Collections.Generic;
using System.Threading.Tasks;
using Inspection.Models;

namespace Inspection.DataAccess
{
    public interface FlooredCarRepository
    {
        Task<IEnumerable<FlooredCar>> getAll();

        Task<FlooredCar> getById(int id);

        Task<IEnumerable<FlooredCar>> getAllNeverInspected();

        Task<IEnumerable<FlooredCar>> getAllByRegion(int regionId);

        Task<IEnumerable<FlooredCar>> getAllByDealer(int dealerId);
    }
}
