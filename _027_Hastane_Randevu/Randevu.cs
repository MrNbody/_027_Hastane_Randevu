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
    
    public partial class Randevu
    {
        public int randevuID { get; set; }
        public int uyeID { get; set; }
        public int doktorID { get; set; }
        public System.DateTime randevuTarihSaat { get; set; }
    
        public virtual Doktor Doktor { get; set; }
        public virtual Uye Uye { get; set; }
    }
}
