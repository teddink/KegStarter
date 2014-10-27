using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KegStarter.Models;

namespace KegStarter.Controllers
{
    public class BeerHistoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BeerHistories
        public ActionResult Index()
        {
            return View(db.BeerHistories.ToList());
        }

        // GET: BeerHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeerHistory beerHistory = db.BeerHistories.Find(id);
            if (beerHistory == null)
            {
                return HttpNotFound();
            }
            return View(beerHistory);
        }

        // GET: BeerHistories/Create
        [Authorize(Roles = "canEdit")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BeerHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult Create([Bind(Include = "BeerHistoryId,Name,Brewery,Current,DateTapped")] BeerHistory beerHistory)
        {
            if (ModelState.IsValid)
            {
                db.BeerHistories.Add(beerHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(beerHistory);
        }

        // GET: BeerHistories/Edit/5
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeerHistory beerHistory = db.BeerHistories.Find(id);
            if (beerHistory == null)
            {
                return HttpNotFound();
            }
            return View(beerHistory);
        }

        // POST: BeerHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit([Bind(Include = "BeerHistoryId,Name,Brewery,Current,DateTapped")] BeerHistory beerHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(beerHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(beerHistory);
        }

        // GET: BeerHistories/Delete/5
        [Authorize(Roles = "canEdit")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeerHistory beerHistory = db.BeerHistories.Find(id);
            if (beerHistory == null)
            {
                return HttpNotFound();
            }
            return View(beerHistory);
        }

        // POST: BeerHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult DeleteConfirmed(int id)
        {
            BeerHistory beerHistory = db.BeerHistories.Find(id);
            db.BeerHistories.Remove(beerHistory);
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
