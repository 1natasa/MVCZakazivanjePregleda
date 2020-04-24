using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCZakazivanjePregleda.Models;

namespace MVCZakazivanjePregleda.Controllers
{
    public class tblUstanovasController : Controller
    {
        private ZakazivanjePregledaEntities db = new ZakazivanjePregledaEntities();

        // GET: tblUstanovas
        public ActionResult Index()
        {
            return View(db.tblUstanovas.ToList());
        }

        // GET: tblUstanovas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUstanova tblUstanova = db.tblUstanovas.Find(id);
            if (tblUstanova == null)
            {
                return HttpNotFound();
            }
            return View(tblUstanova);
        }

        // GET: tblUstanovas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblUstanovas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ustanovaID,nazivUstanove,adresaUstanove,mestoUstanove")] tblUstanova tblUstanova)
        {
            if (ModelState.IsValid)
            {
                db.tblUstanovas.Add(tblUstanova);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblUstanova);
        }

        // GET: tblUstanovas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUstanova tblUstanova = db.tblUstanovas.Find(id);
            if (tblUstanova == null)
            {
                return HttpNotFound();
            }
            return View(tblUstanova);
        }

        // POST: tblUstanovas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ustanovaID,nazivUstanove,adresaUstanove,mestoUstanove")] tblUstanova tblUstanova)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblUstanova).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblUstanova);
        }

        // GET: tblUstanovas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUstanova tblUstanova = db.tblUstanovas.Find(id);
            if (tblUstanova == null)
            {
                return HttpNotFound();
            }
            return View(tblUstanova);
        }

        // POST: tblUstanovas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblUstanova tblUstanova = db.tblUstanovas.Find(id);
            db.tblUstanovas.Remove(tblUstanova);
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
