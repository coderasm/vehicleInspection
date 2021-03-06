﻿using System.Collections.Generic;

namespace Inspection.Models
{
    public class InspectionRegion
    {
        public int RegionId { get; set; }
        public string RegionName { get; set; }
        public List<Dealer> Dealers { get; set; }

        public InspectionRegion()
        {
            Dealers = new List<Dealer>();
        }
    }
}
