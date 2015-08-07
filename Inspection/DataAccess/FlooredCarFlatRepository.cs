using System.Collections.Generic;
using System.Threading.Tasks;
using Inspection.Models;

namespace Inspection.DataAccess
{
    public interface FlooredCarFlatRepository
    {
        Task<List<FlooredCarFlat>> getAll();

        Task<FlooredCarFlat> getById(int id);

        Task<List<FlooredCarFlat>> getAllNeverInspected();

        Task<List<FlooredCarFlat>> getAllByRegion(int regionId);

        Task<List<FlooredCarFlat>> getAllByDealer(int dealerId);
    }
}