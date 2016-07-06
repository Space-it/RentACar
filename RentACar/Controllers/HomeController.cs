using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cars()
        {
            rentacarEntities db = new rentacarEntities();
            db.Cars.Add(new Car()
            {
                EngineCapacity = "3",
                ImageUrl = "test",
                ModelName = "shkoda",
                NumberOfDoors = "4",
                NumberOfPassengers = "3",
                Price = "200",
                TransmissionType = "Автомат",
                TrunkVolume = "3сумки"
            });
            db.SaveChanges();
            return View(db.Cars);
        }
        public ActionResult Transfer()
        {
            return View();
        }

    }
}