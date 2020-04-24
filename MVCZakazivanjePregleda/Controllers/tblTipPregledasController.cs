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
    public class tblTipPregledasController : Controller
    {
        private ZakazivanjePregledaEntities db = new ZakazivanjePregledaEntities();

        // GET: tblTipPregledas
        public ActionResult Index()
        {
            var tblTipPregledas = db.tblTipPregledas.Include(t => t.tblVrstaPregleda);
            return View(tblTipPregledas.ToList());
        }

        // GET: tblTipPregledas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTipPregleda tblTipPregleda = db.tblTipPregledas.Find(id);
            if (tblTipPregleda == null)
            {
                return HttpNotFound();
            }
            return View(tblTipPregleda);
        }

        // GET: tblTipPregledas/Create
        public ActionResult Create()
        {
            ViewBag.vrstaPregledaID = new SelectList(db.tblVrstaPregledas, "vrstaPregledaID", "nazivVrstePregleda");
            return View();
        }

        // POST: tblTipPregledas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tipPregledaID,nazivTipaPregleda,vrstaPregledaID")] tblTipPregleda tblTipPregleda)
        {
            if (ModelState.IsValid)
            {
                db.tblTipPregledas.Add(tblTipPregleda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.vrstaPregledaID = new SelectList(db.tblVrstaPregledas, "vrstaPregledaID", "nazivVrstePregleda", tblTipPregleda.vrstaPregledaID);
            return View(tblTipPregleda);
        }

        // GET: tblTipPregledas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTipPregleda tblTipPregleda = db.tblTipPregledas.Find(id);
            if (tblTipPregleda == null)
            {
                return HttpNotFound();
            }
            ViewBag.vrstaPregledaID = new SelectList(db.tblVrstaPregledas, "vrstaPregledaID", "nazivVrstePregleda", tblTipPregleda.vrstaPregledaID);
            return View(tblTipPregleda);
        }

        // POST: tblTipPregledas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tipPregledaID,nazivTipaPregleda,vrstaPregledaID")] tblTipPregleda tblTipPregleda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblTipPregleda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.vrstaPregledaID = new SelectList(db.tblVrstaPregledas, "vrstaPregledaID", "nazivVrstePregleda", tblTipPregleda.vrstaPregledaID);
            return View(tblTipPregleda);
        }

        // GET: tblTipPregledas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTipPregleda tblTipPregleda = db.tblTipPregledas.Find(id);
            if (tblTipPregleda == null)
            {
                return HttpNotFound();
            }
            return View(tblTipPregleda);
        }

        // POST: tblTipPregledas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblTipPregleda tblTipPregleda = db.tblTipPregledas.Find(id);
            db.tblTipPregledas.Remove(tblTipPregleda);
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
