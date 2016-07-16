using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Controllers
{
    public class HomeController : Controller
    {
        private rentacarEntities db = new rentacarEntities();
        private Order ActiveOrder;

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Order model)
        {
            if (model.Adress != null &&
                model.StartDate != null &&
                model.StartTime != null &&
                model.EndDate != null &&
                model.EndTime != null)
            {
                ActiveOrder = model;
                return RedirectToAction("BookingContinue", "Home", model);
            }
            return View();
        }
        public ActionResult Cars()
        {
            rentacarEntities db = new rentacarEntities();
            db.SaveChanges();
            return View(db.Cars);
        }
        public ActionResult Transfer()
        {
            return View();
        }



        //public ActionResult BookingContinue()
        //{
        //    ViewBag.OrderId = new SelectList(db.Cars, "Id", "ModelName");
        //    Order o = new Order();
        //    o.Adress = ActiveOrder.Adress;
        //    o.StartDate = ActiveOrder.StartDate;
        //    o.EndDate = ActiveOrder.EndDate;
        //    o.StartTime = ActiveOrder.StartTime;
        //    o.EndTime = ActiveOrder.EndTime;
        //    return View("Booking",o);
        //}
        //[HttpPost]
        [HttpGet]
        public ActionResult BookingContinue(Order model)
        {
            ViewBag.OrderId = new SelectList(db.Cars, "Id", "ModelName");
            Order o = new Order();
            o.Adress = model.Adress;
            o.StartDate = model.StartDate;
            o.EndDate = model.EndDate;
            o.StartTime = model.StartTime;
            o.EndTime = model.EndTime;
            ViewBag.CarId = db.Cars.ToList();
            return View("Booking", o);
        }

        // GET: Orders/Create
        [HttpGet]
        public ActionResult Booking()
        {
            ViewBag.CarId = db.Cars.ToList();
            return View();
        }
        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Booking([Bind(Include = "CarId,Name,Phone,Email,Message,Adress,StartDate,EndDate,StartTime,EndTime")] Order order)
        {
            order.IsOpen = "Open";
            if (ModelState.IsValid)
            { 
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
                // TODO REDIRET TO CONFIRM PAGE !!!!!!!!!!
            }

            ViewBag.CarId = new SelectList(db.Cars, "Id", "ModelName", order.OrderId);
            return View(order);
        }
        public ActionResult Contacts()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult ShowCarInfo(string input)
        {
            string idval;
            using (var reader = new StreamReader(Request.InputStream))
            {
                idval = reader.ReadToEnd();
            }
            int id = int.Parse(idval);
            return PartialView("ShowCarInfo", db.Cars.First(x => x.Id == id));
        }
    }
}