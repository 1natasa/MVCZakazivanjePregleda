using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCZakazivanjePregleda.Models;

namespace MVCZakazivanjePregleda.Controllers
{
    public class tblKorisnikController : Controller
    {
        //Registration Action

        [HttpGet]
        public ActionResult Registration()
        {
            return View();

        
        }

        //Registration POST action

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(tblKorisnik tblKorisnik )
        {
            bool Satus = false;
            string message = " ";
            if (ModelState.IsValid)
            {
                var isExist = isEmailExist(tblKorisnik.emailKorisnika);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email adresa vec postoji");
                    return View(tblKorisnik);
                }

                tblKorisnik.sifraKorisnika = Crypto.Hash(tblKorisnik.sifraKorisnika);
                tblKorisnik.potvrdjenaSifra = Crypto.Hash(tblKorisnik.potvrdjenaSifra);

                using (ZakazivanjePregledaEntities db = new ZakazivanjePregledaEntities())
                {
                    db.tblKorisniks.Add(tblKorisnik);
                    db.SaveChanges();
                    message = "Registracije je uspesno izvrsena!";
                    Satus = true;
                }

            } else
            {
                message = "Neuspesan zahtev!";
            }
            ViewBag.Message = message;
            ViewBag.Status = Satus;
            
            return View(tblKorisnik);
        }
        //Verify email

        //Verify email LINK

        //Login

        //Login POST

        //Logout

        [NonAction]
        public bool isEmailExist(string emailKorisnika)
        {
            using (ZakazivanjePregledaEntities db = new ZakazivanjePregledaEntities())
            {

                var v = db.tblKorisniks.Where(a => a.emailKorisnika == emailKorisnika).FirstOrDefault();
                return v != null;
            }
        }

    }

    
}