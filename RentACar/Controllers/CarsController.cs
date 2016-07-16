using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using RentACar;

namespace RentACar.Controllers
{
    public class CarsController : Controller
    {
        private rentacarEntities db = new rentacarEntities();

        // GET: Admin
        public ActionResult Index()
        {
            return View(db.Cars.ToList());
        }

        // GET: Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Orders, "OrderId", "Name");
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransmissionType,NumberOfDoors,NumberOfPassengers,TrunkVolume,EngineCapacity,Id,ImageUrl,ModelName,Price")] Car car, HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                // сохраняем файл в папку Files в проекте
                upload.SaveAs(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "Content\\" + fileName);
                
                if (ModelState.IsValid)
                {
                    car.ImageUrl = "/Content/" + fileName;
                    db.Cars.Add(car);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(car);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransmissionType,NumberOfDoors,NumberOfPassengers,TrunkVolume,EngineCapacity,Id,ImageUrl,ModelName,Price")] Car car, HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                System.IO.File.Delete(Server.MapPath("~/" + car.ImageUrl));
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                // сохраняем файл в папку Files в проекте
                upload.SaveAs(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "Content\\" + fileName);
                car.ImageUrl = "/Content/" + fileName;
            }
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }
        //public ActionResult Edit([Bind(Include = "TransmissionType,NumberOfDoors,NumberOfPassengers,TrunkVolume,EngineCapacity,Id,ImageUrl,ModelName,Price")] Car car, HttpPostedFileBase upload)
        //{
        //    if (upload != null)
        //    {
        //        System.IO.File.Delete(Server.MapPath("~/" + car.ImageUrl));
        //        // получаем имя файла
        //        string fileName = System.IO.Path.GetFileName(upload.FileName);
        //        // сохраняем файл в папку Files в проекте
        //        upload.SaveAs(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "Content\\" + fileName);
        //        car.ImageUrl = "/Content/" + fileName;
        //    }
        //    else
        //    {
        //        car.ImageUrl = db.Cars.Where(x => x.ModelName == car.ModelName).ToList().First().ImageUrl;
        //    }
        //    if (ModelState.IsValid)
        //        {
        //            db.Entry(car).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
            
        //    return View(car);
        //}

        // GET: Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            Car car = db.Cars.Find(id);
            var ReferenceOrders = db.Orders.Where(x => x.CarId == car.Id.ToString()).ToList();
            foreach (var order in ReferenceOrders)
                order.CarId = "NoCar";
            System.IO.File.Delete(Server.MapPath("~/" + car.ImageUrl));
            db.Cars.Remove(car);
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
