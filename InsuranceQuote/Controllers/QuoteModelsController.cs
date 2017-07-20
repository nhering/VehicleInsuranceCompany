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
    public class QuoteModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: QuoteModels
        public ActionResult Index()
        {
            return View(db.Quotes.ToList());
        }

        // GET: QuoteModels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuoteModel quoteModel = db.Quotes.Find(id);
            if (quoteModel == null)
            {
                return HttpNotFound();
            }
            return View(quoteModel);
        }

        // GET: QuoteModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuoteModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Age,ZipCode,AnnualMilage,Make,Model,Year")] QuoteModel quoteModel)
        {
            if (ModelState.IsValid)
            {
                quoteModel.Id = Guid.NewGuid();
                db.Quotes.Add(quoteModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quoteModel);
        }

        // GET: QuoteModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuoteModel quoteModel = db.Quotes.Find(id);
            if (quoteModel == null)
            {
                return HttpNotFound();
            }
            return View(quoteModel);
        }

        // POST: QuoteModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Age,ZipCode,AnnualMilage,Make,Model,Year")] QuoteModel quoteModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quoteModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quoteModel);
        }

        // GET: QuoteModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuoteModel quoteModel = db.Quotes.Find(id);
            if (quoteModel == null)
            {
                return HttpNotFound();
            }
            return View(quoteModel);
        }

        // POST: QuoteModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            QuoteModel quoteModel = db.Quotes.Find(id);
            db.Quotes.Remove(quoteModel);
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
