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
    public class tblDoktorsController : Controller
    {
        private ZakazivanjePregledaEntities db = new ZakazivanjePregledaEntities();

        // GET: tblDoktors
      
        
        public ActionResult Index()
        {
            return View(db.tblDoktors.ToList());
        }

        // GET: tblDoktors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDoktor tblDoktor = db.tblDoktors.Find(id);
            if (tblDoktor == null)
            {
                return HttpNotFound();
            }
            return View(tblDoktor);
        }

        // GET: tblDoktors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblDoktors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "doktorID,imeDoktora,prezimeDoktora,datumRodjenjaDoktora,brojTelefonaDoktora,brojLicence,specijalizacija")] tblDoktor tblDoktor)
        {
            if (ModelState.IsValid)
            {
                db.tblDoktors.Add(tblDoktor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblDoktor);
        }

        // GET: tblDoktors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDoktor tblDoktor = db.tblDoktors.Find(id);
            if (tblDoktor == null)
            {
                return HttpNotFound();
            }
            return View(tblDoktor);
        }

        // POST: tblDoktors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "doktorID,imeDoktora,prezimeDoktora,datumRodjenjaDoktora,brojTelefonaDoktora,brojLicence,specijalizacija")] tblDoktor tblDoktor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblDoktor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblDoktor);
        }

        // GET: tblDoktors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDoktor tblDoktor = db.tblDoktors.Find(id);
            if (tblDoktor == null)
            {
                return HttpNotFound();
            }
            return View(tblDoktor);
        }

        // POST: tblDoktors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblDoktor tblDoktor = db.tblDoktors.Find(id);
            db.tblDoktors.Remove(tblDoktor);
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
