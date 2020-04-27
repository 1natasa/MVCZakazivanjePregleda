using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MVCZakazivanjePregleda.Models
{
    [MetadataType(typeof(tblKorisnikMetadata))]
    public partial class tblKorisnik
    {
        public string potvrdjenaSifra { get; set; }
    }

    public class tblKorisnikMetadata
    {
        [Display(Name ="Email")]
        [Required(AllowEmptyStrings =false, ErrorMessage ="Email adresa je obavezna")]
        [DataType(DataType.EmailAddress)]
        public string emailKorisnika { get; set; }

        [Display(Name = "Korisnicko ime")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Korisnicko ime je obavezno")]
        public string korisnickoIme { get; set; }


        [Display(Name = "Sifra")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Sifra je obavezna")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage ="Sifra mora da ima minimum 6 karaktera")]
        public string sifraKorisnika { get; set; }

        [Display(Name = "Potvrdi sifru")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Potvrditi sifru je obavezno")]
        [Compare("sifraKorisnika", ErrorMessage ="Potvrdjena sifra i sifra se ne poklapaju")]
        public string potvrdjenaSifra { get; set; }
    }
}