using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _027_Hastane_Randevu.admin
{
    public class KlinikClass
    {
        HastaneEntities db = new HastaneEntities();
        public int HastaneID { get; set; }
        public string KlinikAdi { get; set; }
        public bool Ekle()
        {
            try
            {
                var klinik = new _027_Hastane_Randevu.Klinik();
                klinik.klinikAd = KlinikAdi;
                klinik.hastaneID = HastaneID;
                db.Kliniks.Add(klinik);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }
    }
}