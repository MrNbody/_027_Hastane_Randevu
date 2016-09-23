using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _027_Hastane_Randevu
{
    public class GirisClass
    {
        HastaneEntities db = new HastaneEntities();
        public string tc { get; set; }
        public string parola { get; set; }

        public Uye UyeGirisYap()
        {
            try
            {
                Uye uye = db.Uyes.Where(u => u.uyeTc == tc && u.uyeSifre == parola).FirstOrDefault();
                return uye;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Doktor DoktorGirisYap()
        {
            try
            {
                Doktor doktor = db.Doktors.Where(u => u.doktorTc == tc && u.doktorSifre == parola).FirstOrDefault();
                return doktor;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}