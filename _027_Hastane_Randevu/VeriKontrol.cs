using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _027_Hastane_Randevu
{
    public class VeriKontrol
    {
        public bool Kontrol(string tx)
        {
            if (tx != string.Empty || tx != "")
                return true;
            else
                return false;
        }
    }
}