using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using DataAccess;
using DataAccess.Models;

namespace Inspection.Controllers
{
    public class AdministrationController : Controller
    {
        private FlooredCarRepository flooredCarsDAO;

        public AdministrationController(FlooredCarRepository flooredCarsDAO)
        {
            this.flooredCarsDAO = flooredCarsDAO;
        }

        public AdministrationController() : this(new FlooredCarsDAO(new Repository<FlooredCar>()))
        {
        }

        public async Task<ActionResult> Floored()
        {
            var model = await flooredCarsDAO.getAll();
            return View(model);
        }
    }
}
