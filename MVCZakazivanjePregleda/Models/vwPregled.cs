//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCZakazivanjePregleda.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class vwPregled
    {
        public int pregledID { get; set; }
        public Nullable<System.DateTime> terminPregleda { get; set; }
        public Nullable<System.TimeSpan> vremePregleda { get; set; }
        public string dodatneNapomene { get; set; }
        public Nullable<int> ustanovaID { get; set; }
        public Nullable<int> pacijentID { get; set; }
        public Nullable<int> vrstaPregledaID { get; set; }
        public Nullable<int> doktorID { get; set; }
        public string imePacijenta { get; set; }
        public string prezimePacijenta { get; set; }
        public string imeDoktora { get; set; }
        public string prezimeDoktora { get; set; }
        public string specijalizacija { get; set; }
        public string nazivUstanove { get; set; }
        public string nazivVrstePregleda { get; set; }
    }
}
