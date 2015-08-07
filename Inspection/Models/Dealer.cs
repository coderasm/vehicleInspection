using System.Collections.Generic;

namespace Inspection.Models
{
    public class Dealer
    {
        public int DealerId { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }
        public List<FlooredCar> FlooredCars { get; set; }

        public Dealer()
        {
            FlooredCars = new List<FlooredCar>();
        }
    }
}
