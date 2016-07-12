using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Controllers
{
    public class HomeController : Controller
    {
        private rentacarEntities db = new rentacarEntities();

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

        // GET: Orders/Create
        public ActionResult Booking()
        {
            ViewBag.OrderId = new SelectList(db.Cars, "Id", "ModelName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Booking([Bind(Include = "OrderId,CarId,Name,Phone,Email,Message,Adress,StartDate,EndDate,StartTime,EndTime")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
                // TODO REDIRET TO CONFIRM PAGE !!!!!!!!!!
            }

            ViewBag.OrderId = new SelectList(db.Cars, "Id", "ModelName", order.OrderId);
            return View(order);
        }
        public ActionResult Contacts()
        {
            return View();
        }
    }
}