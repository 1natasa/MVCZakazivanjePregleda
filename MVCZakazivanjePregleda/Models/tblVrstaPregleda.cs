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

    public partial class tblVrstaPregleda
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblVrstaPregleda()
        {
            this.tblPregleds = new HashSet<tblPregled>();
            this.tblTipPregledas = new HashSet<tblTipPregleda>();
        }

        public int vrstaPregledaID { get; set; }

        [System.ComponentModel.DisplayName("Vrsta pregleda")]
        public string nazivVrstePregleda { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPregled> tblPregleds { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblTipPregleda> tblTipPregledas { get; set; }
    }
}