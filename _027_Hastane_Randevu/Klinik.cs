//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _027_Hastane_Randevu
{
    using System;
    using System.Collections.Generic;
    
    public partial class Klinik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Klinik()
        {
            this.Doktors = new HashSet<Doktor>();
        }
    
        public int klinikID { get; set; }
        public int hastaneID { get; set; }
        public string klinikAd { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Doktor> Doktors { get; set; }
        public virtual Hastane Hastane { get; set; }
    }
}
