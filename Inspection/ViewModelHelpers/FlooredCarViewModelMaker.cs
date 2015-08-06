using System;
using System.Collections.Generic;
using Inspection.Controllers;
using Inspection.Models;

namespace Inspection.ViewModelHelpers
{
    public class FlooredCarViewModelMaker : ViewModelMaker
    {
        private IEnumerable<FlooredCar> flooredCars;

        public FlooredCarViewModelMaker(IEnumerable<FlooredCar> flooredCars)
        {
            this.flooredCars = flooredCars;
        }
        public object make()
        {
            throw new NotImplementedException();
        }
    }
}
