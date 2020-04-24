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
    public class tblPodtipPregledasController : Controller
    {
        private ZakazivanjePregledaEntities db = new ZakazivanjePregledaEntities();

        // GET: tblPodtipPregledas
        public ActionResult Index()
        {
            var tblPodtipPregledas = db.tblPodtipPregledas.Include(t => t.tblTipPregleda);
            return View(tblPodtipPregledas.ToList());
        }

        // GET: tblPodtipPregledas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPodtipPregleda tblPodtipPregleda = db.tblPodtipPregledas.Find(id);
            if (tblPodtipPregleda == null)
            {
                return HttpNotFound();
            }
            return View(tblPodtipPregleda);
        }

        // GET: tblPodtipPregledas/Create
        public ActionResult Create()
        {
            ViewBag.tipPregledaID = new SelectList(db.tblTipPregledas, "tipPregledaID", "nazivTipaPregleda");
            return View();
        }

        // POST: tblPodtipPregledas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "podtipPregledaID,nazivPodtipaPregleda,tipPregledaID")] tblPodtipPregleda tblPodtipPregleda)
        {
            if (ModelState.IsValid)
            {
                db.tblPodtipPregledas.Add(tblPodtipPregleda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tipPregledaID = new SelectList(db.tblTipPregledas, "tipPregledaID", "nazivTipaPregleda", tblPodtipPregleda.tipPregledaID);
            return View(tblPodtipPregleda);
        }

        // GET: tblPodtipPregledas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPodtipPregleda tblPodtipPregleda = db.tblPodtipPregledas.Find(id);
            if (tblPodtipPregleda == null)
            {
                return HttpNotFound();
            }
            ViewBag.tipPregledaID = new SelectList(db.tblTipPregledas, "tipPregledaID", "nazivTipaPregleda", tblPodtipPregleda.tipPregledaID);
            return View(tblPodtipPregleda);
        }

        // POST: tblPodtipPregledas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "podtipPregledaID,nazivPodtipaPregleda,tipPregledaID")] tblPodtipPregleda tblPodtipPregleda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPodtipPregleda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tipPregledaID = new SelectList(db.tblTipPregledas, "tipPregledaID", "nazivTipaPregleda", tblPodtipPregleda.tipPregledaID);
            return View(tblPodtipPregleda);
        }

        // GET: tblPodtipPregledas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPodtipPregleda tblPodtipPregleda = db.tblPodtipPregledas.Find(id);
            if (tblPodtipPregleda == null)
            {
                return HttpNotFound();
            }
            return View(tblPodtipPregleda);
        }

        // POST: tblPodtipPregledas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPodtipPregleda tblPodtipPregleda = db.tblPodtipPregledas.Find(id);
            db.tblPodtipPregledas.Remove(tblPodtipPregleda);
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
