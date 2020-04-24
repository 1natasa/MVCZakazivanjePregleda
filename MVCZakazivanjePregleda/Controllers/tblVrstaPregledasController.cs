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
    public class tblVrstaPregledasController : Controller
    {
        private ZakazivanjePregledaEntities db = new ZakazivanjePregledaEntities();

        // GET: tblVrstaPregledas
        public ActionResult Index()
        {
            return View(db.tblVrstaPregledas.ToList());
        }

        // GET: tblVrstaPregledas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVrstaPregleda tblVrstaPregleda = db.tblVrstaPregledas.Find(id);
            if (tblVrstaPregleda == null)
            {
                return HttpNotFound();
            }
            return View(tblVrstaPregleda);
        }

        // GET: tblVrstaPregledas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblVrstaPregledas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "vrstaPregledaID,nazivVrstePregleda")] tblVrstaPregleda tblVrstaPregleda)
        {
            if (ModelState.IsValid)
            {
                db.tblVrstaPregledas.Add(tblVrstaPregleda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblVrstaPregleda);
        }

        // GET: tblVrstaPregledas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVrstaPregleda tblVrstaPregleda = db.tblVrstaPregledas.Find(id);
            if (tblVrstaPregleda == null)
            {
                return HttpNotFound();
            }
            return View(tblVrstaPregleda);
        }

        // POST: tblVrstaPregledas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "vrstaPregledaID,nazivVrstePregleda")] tblVrstaPregleda tblVrstaPregleda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblVrstaPregleda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblVrstaPregleda);
        }

        // GET: tblVrstaPregledas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVrstaPregleda tblVrstaPregleda = db.tblVrstaPregledas.Find(id);
            if (tblVrstaPregleda == null)
            {
                return HttpNotFound();
            }
            return View(tblVrstaPregleda);
        }

        // POST: tblVrstaPregledas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblVrstaPregleda tblVrstaPregleda = db.tblVrstaPregledas.Find(id);
            db.tblVrstaPregledas.Remove(tblVrstaPregleda);
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
