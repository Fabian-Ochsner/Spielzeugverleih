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
        private SpielverleihDb db = new SpielverleihDb();

        // GET: Spielzeugs
        public ActionResult Index()
        {
            return View(db.Spielzeugs.ToList());
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
            return View();
        }

        // POST: Spielzeugs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SpielzeugID,Name,Bild,Beschreibung,Price,Status")] Spielzeug spielzeug)
        {
            if (ModelState.IsValid)
            {
                db.Spielzeugs.Add(spielzeug);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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
            return View(spielzeug);
        }

        // POST: Spielzeugs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SpielzeugID,Name,Bild,Beschreibung,Price,Status")] Spielzeug spielzeug)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spielzeug).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
