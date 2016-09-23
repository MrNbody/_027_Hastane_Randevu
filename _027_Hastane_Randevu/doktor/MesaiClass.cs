using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _027_Hastane_Randevu.doktor
{
    public class MesaiClass
    {
        HastaneEntities db = new HastaneEntities();
        public TimeSpan MesaiSaat { get; set; }

        public void Ekle(int doktorID, TimeSpan mesaiSaat)
        {
            try
            {
                Mesai mesai = new Mesai();
                mesai.doktorID = doktorID;
                mesai.mesaiSaat = mesaiSaat;
                db.Mesais.Add(mesai);
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Mesai> Getir(int doktorID)
        {
            try
            {
                List<Mesai> mesai = db.Mesais.Where(m => m.doktorID == doktorID).ToList();
                return mesai;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Mesai GetirByID(int mesaiID)
        {
            Mesai mesai;
            try
            {
                
                mesai = db.Mesais.Where(m => m.mesaiID == mesaiID).FirstOrDefault();
               
            }
            catch (Exception)
            {

                throw;
            }
            return mesai;
        }
    }
}