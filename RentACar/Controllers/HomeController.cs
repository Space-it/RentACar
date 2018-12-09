using RentACar.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
            var CarList = new List<Car>();
            CarList.Add(new Car()
            {
                Id = 9999,
                ModelName = ""
            });
            foreach (var item in db.Cars.ToList())
                CarList.Add(item);

            ViewBag.CarId = CarList;
            Order o = new Order();
            o.Adress = model.Adress;
            o.StartDate = model.StartDate;
            o.EndDate = model.EndDate;
            o.StartTime = model.StartTime;
            o.EndTime = model.EndTime;
            return View("Booking", o);
        }

        // GET: Orders/Create
        [HttpGet]
        public ActionResult Booking()
        {
            var CarList = new List<Car>();
            CarList.Add(new Car()
            {
                Id = 9999,
                ModelName = ""
            });
            foreach (var item in db.Cars.ToList())
                CarList.Add(item);
            
            ViewBag.CarId = CarList;
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
                if (string.IsNullOrEmpty(order.Message))
                    order.Message = "Пусто";
                db.Orders.Add(order);
                try
                {
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    throw raise;
                }
                ViewBag.Message = "Запрос успешно отправлен!";
                return View("InfoMessage");
            }

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

        [HttpPost]
        public ActionResult SendEmail(EmailModel model)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("zprentacar.info@gmail.com", "05190713car");
            smtp.EnableSsl = true;

            MailMessage emailMes = new MailMessage("zprentacar.info@gmail.com", "rent_a_car.zp@mail.ru", "RentACar Contact message from " + model.Name, model.Message + "\nМой почтовый адрес: " + model.Email);
            smtp.Send(emailMes);
            return RedirectToAction("InfoMessage", "Home");
        }
        public ActionResult InfoMessage()
        {
            ViewBag.Message = "Сообщение успешно отправлено! Возврат на главную через 5 секунд...";
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
        public PartialViewResult Email()
        {
            return PartialView("Email", db.ContactEmails);
        }
        public PartialViewResult Phone()
        {
            return PartialView("Phone", db.ContactPhones);
        }
        public PartialViewResult PhoneTransfer()
        {
            return PartialView("PhoneTransfer", db.ContactPhones);
        }
        public ActionResult Error()
        {
            return View();
        }

    }
}