using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Inspection.DataAccess;
using Inspection.Models;
using Inspection.ViewModelHelpers;

namespace Inspection.Controllers
{
    public class FlooredController : ApiController
    {

        private readonly FlooredCarFlatRepository flooredCarFlatRepository;

        public FlooredController(FlooredCarFlatRepository flooredCarFlatRepository)
        {
            this.flooredCarFlatRepository = flooredCarFlatRepository;
        }
        // GET: api/Floored
        public async Task<IEnumerable<InspectionRegion>> Get()
        {
            var flooredCarsFlat = await flooredCarFlatRepository.getAll();
            ViewModelMaker viewModelMaker = new RegionsViewModelMaker(flooredCarsFlat);
            return (List<InspectionRegion>) viewModelMaker.make();
        }

        // GET: api/Rename/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Rename
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Rename/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Rename/5
        public void Delete(int id)
        {
        }
    }
}
