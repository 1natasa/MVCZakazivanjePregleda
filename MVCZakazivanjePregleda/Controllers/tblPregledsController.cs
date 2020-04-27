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
    
    public class tblPregledsController : Controller
    {
        private ZakazivanjePregledaEntities db = new ZakazivanjePregledaEntities();

        // GET: tblPregleds
        [Authorize]
        public ActionResult Index()
        {
            var tblPregleds = db.tblPregleds.Include(t => t.tblDoktor).Include(t => t.tblPacijent).Include(t => t.tblUstanova).Include(t => t.tblVrstaPregleda);
            //var pregled = from a in db.tblDoktors
                       //   join  b in db.tblVrstaPregledas on a.vrstaPregledaID equals b.vrstaPregledaID
                       //   select 

            return View(tblPregleds.ToList());
        }

        // GET: tblPregleds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPregled tblPregled = db.tblPregleds.Find(id);
            if (tblPregled == null)
            {
                return HttpNotFound();
            }
            return View(tblPregled);
        }

        // GET: tblPregleds/Create
        public ActionResult Create()
        {
            ViewBag.doktorID = new SelectList(db.tblDoktors, "doktorID", "doktor");
            
            
            ViewBag.pacijentID = new SelectList(db.tblPacijents, "pacijentID", "pacijent");
            ViewBag.ustanovaID = new SelectList(db.tblUstanovas, "ustanovaID", "ustanova");
            ViewBag.vrstaPregledaID = new SelectList(db.tblVrstaPregledas, "vrstaPregledaID", "nazivVrstePregleda");
            return View();
        }

        // POST: tblPregleds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pregledID,terminPregleda,vremePregleda,dodatneNapomene,ustanovaID,pacijentID,vrstaPregledaID,doktorID")] tblPregled tblPregled)
        {
            if (ModelState.IsValid)
            {
                db.tblPregleds.Add(tblPregled);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.doktorID = new SelectList(db.tblDoktors, "doktorID", "doktor", tblPregled.doktorID);
            ViewBag.pacijentID = new SelectList(db.tblPacijents, "pacijentID", "pacijent", tblPregled.pacijentID);
            ViewBag.ustanovaID = new SelectList(db.tblUstanovas, "ustanovaID", "ustanova", tblPregled.ustanovaID);
            ViewBag.vrstaPregledaID = new SelectList(db.tblVrstaPregledas, "vrstaPregledaID", "nazivVrstePregleda", tblPregled.vrstaPregledaID);
            return View(tblPregled);
        }

        // GET: tblPregleds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPregled tblPregled = db.tblPregleds.Find(id);
            if (tblPregled == null)
            {
                return HttpNotFound();
            }
            ViewBag.doktorID = new SelectList(db.tblDoktors, "doktorID", "doktor", tblPregled.doktorID);
            ViewBag.pacijentID = new SelectList(db.tblPacijents, "pacijentID", "pacijent", tblPregled.pacijentID);
            ViewBag.ustanovaID = new SelectList(db.tblUstanovas, "ustanovaID", "ustanova", tblPregled.ustanovaID);
            ViewBag.vrstaPregledaID = new SelectList(db.tblVrstaPregledas, "vrstaPregledaID", "nazivVrstePregleda", tblPregled.vrstaPregledaID);
            return View(tblPregled);
        }

        // POST: tblPregleds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pregledID,terminPregleda,vremePregleda,dodatneNapomene,ustanovaID,pacijentID,vrstaPregledaID,doktorID")] tblPregled tblPregled)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPregled).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.doktorID = new SelectList(db.tblDoktors, "doktorID", "doktor", tblPregled.doktorID);
            ViewBag.pacijentID = new SelectList(db.tblPacijents, "pacijentID", "pacijent", tblPregled.pacijentID);
            ViewBag.ustanovaID = new SelectList(db.tblUstanovas, "ustanovaID", "ustanova", tblPregled.ustanovaID);
            ViewBag.vrstaPregledaID = new SelectList(db.tblVrstaPregledas, "vrstaPregledaID", "nazivVrstePregleda", tblPregled.vrstaPregledaID);
            return View(tblPregled);
        }

        // GET: tblPregleds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPregled tblPregled = db.tblPregleds.Find(id);
            if (tblPregled == null)
            {
                return HttpNotFound();
            }
            return View(tblPregled);
        }

        // POST: tblPregleds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPregled tblPregled = db.tblPregleds.Find(id);
            db.tblPregleds.Remove(tblPregled);
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
