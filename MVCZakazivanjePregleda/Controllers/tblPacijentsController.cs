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
    public class tblPacijentsController : Controller
    {
        private ZakazivanjePregledaEntities db = new ZakazivanjePregledaEntities();

        // GET: tblPacijents
        public ActionResult Index()
        {
            return View(db.tblPacijents.ToList());
        }

        // GET: tblPacijents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPacijent tblPacijent = db.tblPacijents.Find(id);
            if (tblPacijent == null)
            {
                return HttpNotFound();
            }
            return View(tblPacijent);
        }

        // GET: tblPacijents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblPacijents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pacijentID,imePacijenta,prezimePacijenta,adresaPacijenta,polPacijenta,datumRodjenjaPacijenta,jmbgPacijenta,brojTelefonaPacijenta,lbo")] tblPacijent tblPacijent)
        {
            if (ModelState.IsValid)
            {
                db.tblPacijents.Add(tblPacijent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblPacijent);
        }

        // GET: tblPacijents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPacijent tblPacijent = db.tblPacijents.Find(id);
            if (tblPacijent == null)
            {
                return HttpNotFound();
            }
            return View(tblPacijent);
        }

        // POST: tblPacijents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pacijentID,imePacijenta,prezimePacijenta,adresaPacijenta,polPacijenta,datumRodjenjaPacijenta,jmbgPacijenta,brojTelefonaPacijenta,lbo")] tblPacijent tblPacijent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPacijent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblPacijent);
        }

        // GET: tblPacijents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPacijent tblPacijent = db.tblPacijents.Find(id);
            if (tblPacijent == null)
            {
                return HttpNotFound();
            }
            return View(tblPacijent);
        }

        // POST: tblPacijents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPacijent tblPacijent = db.tblPacijents.Find(id);
            db.tblPacijents.Remove(tblPacijent);
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
