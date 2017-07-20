using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InsuranceQuote.Models;

namespace InsuranceQuote.Controllers
{
    public class DriverModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DriverModels
        public ActionResult Index()
        {
            return View(db.Drivers.ToList());
        }

        // GET: DriverModels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverModel driverModel = db.Drivers.Find(id);
            if (driverModel == null)
            {
                return HttpNotFound();
            }
            return View(driverModel);
        }

        // GET: DriverModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DriverModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Address,City,State,ZipCode")] DriverModel driverModel)
        {
            if (ModelState.IsValid)
            {
                driverModel.Id = Guid.NewGuid();
                db.Drivers.Add(driverModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(driverModel);
        }

        // GET: DriverModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverModel driverModel = db.Drivers.Find(id);
            if (driverModel == null)
            {
                return HttpNotFound();
            }
            return View(driverModel);
        }

        // POST: DriverModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Address,City,State,ZipCode")] DriverModel driverModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(driverModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(driverModel);
        }

        // GET: DriverModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverModel driverModel = db.Drivers.Find(id);
            if (driverModel == null)
            {
                return HttpNotFound();
            }
            return View(driverModel);
        }

        // POST: DriverModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            DriverModel driverModel = db.Drivers.Find(id);
            db.Drivers.Remove(driverModel);
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
