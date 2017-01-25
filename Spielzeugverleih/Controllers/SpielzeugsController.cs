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
    public class SpielzeugsController : Controller
    {
        private SpielverleihDB db = new SpielverleihDB();

        // GET: Spielzeugs
        public ActionResult Index()
        {
            var spielzeugs = db.Spielzeugs.Include(s => s.SpielzeugTyp);
            return View(spielzeugs.ToList());
        }

        // GET: Spielzeugs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spielzeug spielzeug = db.Spielzeugs.Find(id);
            if (spielzeug == null)
            {
                return HttpNotFound();
            }
            return View(spielzeug);
        }

        // GET: Spielzeugs/Create
        public ActionResult Create()
        {
            ViewBag.SpielzeugTypID = new SelectList(db.SpielzeugTyps, "ID", "Name");
            return View();
        }

        // POST: Spielzeugs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SpielzeugID,SpielzeugTypID,Name,Bild,Beschreibung,Price,Vorhanden")] Spielzeug spielzeug)
        {
            if (ModelState.IsValid)
            {
                db.Spielzeugs.Add(spielzeug);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SpielzeugTypID = new SelectList(db.SpielzeugTyps, "ID", "Name", spielzeug.SpielzeugTypID);
            return View(spielzeug);
        }

        // GET: Spielzeugs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spielzeug spielzeug = db.Spielzeugs.Find(id);
            if (spielzeug == null)
            {
                return HttpNotFound();
            }
            ViewBag.SpielzeugTypID = new SelectList(db.SpielzeugTyps, "ID", "Name", spielzeug.SpielzeugTypID);
            return View(spielzeug);
        }

        // POST: Spielzeugs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SpielzeugID,SpielzeugTypID,Name,Bild,Beschreibung,Price,Vorhanden")] Spielzeug spielzeug)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spielzeug).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SpielzeugTypID = new SelectList(db.SpielzeugTyps, "ID", "Name", spielzeug.SpielzeugTypID);
            return View(spielzeug);
        }

        // GET: Spielzeugs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spielzeug spielzeug = db.Spielzeugs.Find(id);
            if (spielzeug == null)
            {
                return HttpNotFound();
            }
            return View(spielzeug);
        }

        // POST: Spielzeugs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Spielzeug spielzeug = db.Spielzeugs.Find(id);
            db.Spielzeugs.Remove(spielzeug);
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
