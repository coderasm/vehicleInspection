using System.Collections.Generic;

namespace Inspection.Models
{
    public class Dealer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }
        public IEnumerable<FlooredCar> FlooredCars { get; set; }

        public Dealer()
        {
            FlooredCars = new List<FlooredCar>();
        }
    }
}
