using System;

namespace Inspection.Models
{
    public class FlooredCarFlat
    {
        public int VehicleId { get; set; }
        public DateTime? FundsRecd { get; set; }
        public DateTime? FlooringDate { get; set; }
        public int RegionId { get; set; }
        public string RegionName { get; set; }
        public int DealerId { get; set; }
        public string DealerName { get; set; }
        public DateTime? LastInspectedOn { get; set; }
        public DateTime? ToBeInspectedBy { get; set; }
    }
}
