using System.Collections.Generic;
using System.Threading.Tasks;
using Inspection.Models;

namespace Inspection.DataAccess
{
    public interface FlooredCarFlatRepository
    {
        Task<IEnumerable<FlooredCarFlat>> getAll();

        Task<FlooredCarFlat> getById(int id);

        Task<IEnumerable<FlooredCarFlat>> getAllNeverInspected();

        Task<IEnumerable<FlooredCarFlat>> getAllByRegion(int regionId);

        Task<IEnumerable<FlooredCarFlat>> getAllByDealer(int dealerId);
    }
}