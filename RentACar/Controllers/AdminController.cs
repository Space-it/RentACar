using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Controllers
{
    public class AdminController : Controller
    {
        private rentacarEntities db = new rentacarEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View(db.Orders.OrderByDescending(x=>x.OrderId).First());
        }
    }
}