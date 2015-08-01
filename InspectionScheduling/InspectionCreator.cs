using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionScheduling
{
    public interface InspectionCreator
    {
        Task<IEnumerable<Inspection>> createInspections();
    }
}
