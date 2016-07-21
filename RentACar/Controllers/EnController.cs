﻿using RentACar.Models;
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
    public class EnController : Controller
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
                return RedirectToAction("BookingContinue", "En", model);
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
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
                // TODO REDIRET TO CONFIRM PAGE !!!!!!!!!!
            }

            return View(order);
        }
        public ActionResult Contacts()
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

            MailMessage emailMes = new MailMessage("zprentacar.info@gmail.com", "maxim.tis96@gmail.com", "RentACar Contact message from " + model.Name, model.Message + "\n Мой почтовый адрес: "+model.Email);
           smtp.Send(emailMes);
            ViewBag.Message = "Contact for successful send! <br> Redirect to Home at 5 sec...";
            return View("InfoMessage");
        }

        public ActionResult About()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [HttpPost]
        public PartialViewResult ShowCarInfo()
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
            return PartialView("Contact", db.ContactEmails);
        }
        public PartialViewResult Phone()
        {
            return PartialView("Contact", db.ContactPhones);
        }
    }
}