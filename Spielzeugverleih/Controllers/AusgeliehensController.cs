using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Spielzeugverleih.Models;

namespace Spielzeugverleih.Controllers
{
    public class AusgeliehensController : Controller
    {
        private SpielverleihDb db = new SpielverleihDb();

        // GET: Ausgeliehens
        public ActionResult Index()
        {
            var ausgeliehens = db.Ausgeliehens.Include(a => a.Spielzeug);
            return View(ausgeliehens.ToList());
        }

        // GET: Ausgeliehens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ausgeliehen ausgeliehen = db.Ausgeliehens.Find(id);
            if (ausgeliehen == null)
            {
                return HttpNotFound();
            }
            return View(ausgeliehen);
        }

        // GET: Ausgeliehens/Create
        public ActionResult Create()
        {
            ViewBag.SpielzeugID = new SelectList(db.Spielzeugs, "SpielzeugID", "Name");
            return View();
        }

        // POST: Ausgeliehens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AusgeliehenID,SpielzeugID,DatumVon,DatumBis,Price,MieterID")] Ausgeliehen ausgeliehen)
        {
            if (ModelState.IsValid)
            {
                db.Ausgeliehens.Add(ausgeliehen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SpielzeugID = new SelectList(db.Spielzeugs, "SpielzeugID", "Name", ausgeliehen.SpielzeugID);
            return View(ausgeliehen);
        }

        // GET: Ausgeliehens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ausgeliehen ausgeliehen = db.Ausgeliehens.Find(id);
            if (ausgeliehen == null)
            {
                return HttpNotFound();
            }
            ViewBag.SpielzeugID = new SelectList(db.Spielzeugs, "SpielzeugID", "Name", ausgeliehen.SpielzeugID);
            return View(ausgeliehen);
        }

        // POST: Ausgeliehens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AusgeliehenID,SpielzeugID,DatumVon,DatumBis,Price,MieterID")] Ausgeliehen ausgeliehen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ausgeliehen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SpielzeugID = new SelectList(db.Spielzeugs, "SpielzeugID", "Name", ausgeliehen.SpielzeugID);
            return View(ausgeliehen);
        }

        // GET: Ausgeliehens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ausgeliehen ausgeliehen = db.Ausgeliehens.Find(id);
            if (ausgeliehen == null)
            {
                return HttpNotFound();
            }
            return View(ausgeliehen);
        }

        // POST: Ausgeliehens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ausgeliehen ausgeliehen = db.Ausgeliehens.Find(id);
            db.Ausgeliehens.Remove(ausgeliehen);
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
