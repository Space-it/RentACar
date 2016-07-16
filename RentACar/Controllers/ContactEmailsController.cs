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
    public class ContactEmailsController : Controller
    {
        private rentacarEntities db = new rentacarEntities();

        // GET: ContactEmails
        public ActionResult Index()
        {
            return View(db.ContactEmails.ToList());
        }

        // GET: ContactEmails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactEmail contactEmail = db.ContactEmails.Find(id);
            if (contactEmail == null)
            {
                return HttpNotFound();
            }
            return View(contactEmail);
        }

        // GET: ContactEmails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactEmails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email")] ContactEmail contactEmail)
        {
            if (ModelState.IsValid)
            {
                db.ContactEmails.Add(contactEmail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactEmail);
        }

        // GET: ContactEmails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactEmail contactEmail = db.ContactEmails.Find(id);
            if (contactEmail == null)
            {
                return HttpNotFound();
            }
            return View(contactEmail);
        }

        // POST: ContactEmails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email")] ContactEmail contactEmail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactEmail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactEmail);
        }

        // GET: ContactEmails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactEmail contactEmail = db.ContactEmails.Find(id);
            if (contactEmail == null)
            {
                return HttpNotFound();
            }
            return View(contactEmail);
        }

        // POST: ContactEmails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactEmail contactEmail = db.ContactEmails.Find(id);
            db.ContactEmails.Remove(contactEmail);
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
