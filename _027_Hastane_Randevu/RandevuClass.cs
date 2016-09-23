using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _027_Hastane_Randevu
{
    public class RandevuClass
    {
        HastaneEntities db = new HastaneEntities();
        public int UyeID { get; set; }
        public int DoktorID { get; set; }
        public DateTime TarihSaat { get; set; }

        public string Ekle()
        {
            try
            {
                Randevu randevu = new Randevu();
                randevu.uyeID = UyeID;
                randevu.doktorID = DoktorID;
                randevu.randevuTarihSaat = TarihSaat;
                db.Randevus.Add(randevu);
                db.SaveChanges();
                return "Randevu Alındı";
            }
            catch (Exception)
            {
                return "Hata";
                throw;
            }
        }
        public List<DateTime> Kontrol()
        {
            try
            {
                List<DateTime> randevu = db.Randevus.Where(r => r.randevuTarihSaat == TarihSaat && r.doktorID == DoktorID).Select(k => k.randevuTarihSaat).ToList();
                return randevu;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<viewRandevuDetay> Getir(int uyeID)
        {
            List<viewRandevuDetay> randevuGecmis =
            db.viewRandevuDetays.Where(r => r.uyeID == uyeID).ToList();
            return randevuGecmis;
        }
        public List<viewRandevuDetay> GetirDoktor(int doktorID)
        {
            try
            {
                List<viewRandevuDetay> randevuGecmis = db.viewRandevuDetays.Where(r => r.doktorID == doktorID).ToList();
                return randevuGecmis;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}