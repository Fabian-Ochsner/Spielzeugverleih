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
    public class SpielzeugTypsController : Controller
    {
        private SpielverleihDb db = new SpielverleihDb();

        // GET: SpielzeugTyps
        public ActionResult Index()
        {
            return View(db.SpielzeugTyps.ToList());
        }

        // GET: SpielzeugTyps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpielzeugTyp spielzeugTyp = db.SpielzeugTyps.Find(id);
            if (spielzeugTyp == null)
            {
                return HttpNotFound();
            }
            return View(spielzeugTyp);
        }

        // GET: SpielzeugTyps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpielzeugTyps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] SpielzeugTyp spielzeugTyp)
        {
            if (ModelState.IsValid)
            {
                db.SpielzeugTyps.Add(spielzeugTyp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(spielzeugTyp);
        }

        // GET: SpielzeugTyps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpielzeugTyp spielzeugTyp = db.SpielzeugTyps.Find(id);
            if (spielzeugTyp == null)
            {
                return HttpNotFound();
            }
            return View(spielzeugTyp);
        }

        // POST: SpielzeugTyps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] SpielzeugTyp spielzeugTyp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spielzeugTyp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(spielzeugTyp);
        }

        // GET: SpielzeugTyps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpielzeugTyp spielzeugTyp = db.SpielzeugTyps.Find(id);
            if (spielzeugTyp == null)
            {
                return HttpNotFound();
            }
            return View(spielzeugTyp);
        }

        // POST: SpielzeugTyps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SpielzeugTyp spielzeugTyp = db.SpielzeugTyps.Find(id);
            db.SpielzeugTyps.Remove(spielzeugTyp);
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
