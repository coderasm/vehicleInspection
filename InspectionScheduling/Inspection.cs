using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InspectionScheduling
{
    public class Inspection
    {
        private int vehicleId;

        public Inspection(int vehicleId)
        {
            this.vehicleId = vehicleId;
        }

        public object inspectorId { get; set; }
    }
}
