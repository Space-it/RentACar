using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RentACar;

namespace RentACar.Controllers
{
    public class ContactPhonesController : Controller
    {
        private rentacarEntities db = new rentacarEntities();

        // GET: ContactPhones
        public ActionResult Index()
        {
            return View(db.ContactPhones.ToList());
        }

        // GET: ContactPhones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactPhone contactPhone = db.ContactPhones.Find(id);
            if (contactPhone == null)
            {
                return HttpNotFound();
            }
            return View(contactPhone);
        }

        // GET: ContactPhones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactPhones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PhoneNumber")] ContactPhone contactPhone)
        {
            if (ModelState.IsValid)
            {
                db.ContactPhones.Add(contactPhone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactPhone);
        }

        // GET: ContactPhones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactPhone contactPhone = db.ContactPhones.Find(id);
            if (contactPhone == null)
            {
                return HttpNotFound();
            }
            return View(contactPhone);
        }

        // POST: ContactPhones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PhoneNumber")] ContactPhone contactPhone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactPhone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactPhone);
        }

        // GET: ContactPhones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactPhone contactPhone = db.ContactPhones.Find(id);
            if (contactPhone == null)
            {
                return HttpNotFound();
            }
            return View(contactPhone);
        }

        // POST: ContactPhones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactPhone contactPhone = db.ContactPhones.Find(id);
            db.ContactPhones.Remove(contactPhone);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
