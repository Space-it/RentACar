using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RentACar.Controllers
{
    public class AdminController : Controller
    {
        private rentacarEntities db = new rentacarEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (model.Username != null && model.Password != null)
            {
                var log = model.Username;
                var pass = model.Password;

                if (System.Configuration.ConfigurationManager.AppSettings["AdminLogin"] == log &&
                    System.Configuration.ConfigurationManager.AppSettings["AdminPassword"] == pass)
                {
                    FormsAuthentication.RedirectFromLoginPage(log, false);
                }
            }
            return View();

        }
        public ActionResult AdminPanel()
        {
            if (db.Orders.ToList().Count != 0)
                return View(db.Orders.OrderByDescending(x => x.OrderId).First());
            else
                return View(new Order() { Adress = "Нету адреса", CarId = "0", Email = "Нету адреса", EndDate = "Нету", EndTime = "Нету", StartDate = "Нету", StartTime = "Нету", IsOpen = "Нету", Message = "Нету", Name = "Нету", OrderId = 0, Phone = "Нету" });
        }
    }
}