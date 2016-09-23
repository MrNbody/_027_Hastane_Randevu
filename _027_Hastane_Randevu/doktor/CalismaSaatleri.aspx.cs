using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _027_Hastane_Randevu.doktor
{
    public partial class CalismaSaatleri : System.Web.UI.Page
    {
        VeriKontrol VK = new VeriKontrol();
        SaatClass saat = new SaatClass();
        MesaiClass mesaiClass = new MesaiClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                object uye = Session["doktorID"];
                if (uye == null)
                {
                    Response.Redirect("Giris.aspx");
                }
                if (saat.Kontrol(Convert.ToInt32(Session["doktorID"]))!=0)
                {
                    btnKaydet.Text = "Guncelle";
                    Doldur();
                }
                else
                    btnKaydet.Text = "Ekle";
            }
        }
        private void Ekle()
        {
            if(VK.Kontrol(TextboxBaslamaSaati.Text))
                saat.SaatBaslama =TimeSpan.Parse(TextboxBaslamaSaati.Text);
            if (VK.Kontrol(TextboxBitisSaati.Text))
                saat.SaatBitis = TimeSpan.Parse(TextboxBitisSaati.Text);
            if (VK.Kontrol(TextboxCalismaPeriyodu.Text))
                saat.SaatPeriyot = TimeSpan.Parse(TextboxCalismaPeriyodu.Text);
            if (VK.Kontrol(TextboxOgleBaslama.Text))
                saat.SaatOgleBaslama = TimeSpan.Parse(TextboxOgleBaslama.Text);
            if (VK.Kontrol(TextboxOgleBitis.Text))
                saat.SaatOgleBitis = TimeSpan.Parse(TextboxOgleBitis.Text);

            if (saat.Ekle(Convert.ToInt32(Session["doktorID"])))
            {
                Randevu(saat.SaatBaslama, saat.SaatBitis, saat.SaatPeriyot, saat.SaatOgleBaslama, saat.SaatOgleBitis);
                labelMesaj.Text = "Eklendi";
            }
            else
                labelMesaj.Text = "Hata";
        }
        private void Guncelle()
        {
            if(VK.Kontrol(TextboxBaslamaSaati.Text))
                saat.SaatBaslama = TimeSpan.Parse(TextboxBaslamaSaati.Text);
            if (VK.Kontrol(TextboxBitisSaati.Text))
                saat.SaatBitis = TimeSpan.Parse(TextboxBitisSaati.Text);
            if (VK.Kontrol(TextboxCalismaPeriyodu.Text))
                saat.SaatPeriyot = TimeSpan.Parse(TextboxCalismaPeriyodu.Text);
            if (VK.Kontrol(TextboxOgleBaslama.Text))
                saat.SaatOgleBaslama = TimeSpan.Parse(TextboxOgleBaslama.Text);
            if (VK.Kontrol(TextboxOgleBitis.Text))
                saat.SaatOgleBitis = TimeSpan.Parse(TextboxOgleBitis.Text);

            if (saat.Guncelle(Convert.ToInt32(Session["doktorID"])))
            {
                Randevu(saat.SaatBaslama, saat.SaatBitis, saat.SaatPeriyot, saat.SaatOgleBaslama, saat.SaatOgleBitis);
                labelMesaj.Text = "Güncellendi";
            }
            else
                labelMesaj.Text = "Hata";
        }
        private void Doldur()
        {
            var saatDoldur = saat.Doldur(Convert.ToInt32(Session["doktorID"]));
            TextboxBaslamaSaati.Text = saatDoldur.saatBaslama.ToString();
            TextboxBitisSaati.Text = saatDoldur.saatBitis.ToString();
            TextboxCalismaPeriyodu.Text = saatDoldur.saatPeriyot.ToString();
            TextboxOgleBaslama.Text = saatDoldur.saatOgleBaslama.ToString();
            TextboxOgleBitis.Text = saatDoldur.saatOgleBitis.ToString();
        }
        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if (saat.Kontrol(Convert.ToInt32(Session["doktorID"]))!=0)
                Guncelle();
            else
                Ekle();
        }

        private void Randevu(TimeSpan baslama, TimeSpan bitis, TimeSpan periyot, TimeSpan ogleBaslama, TimeSpan ogleBitis)
        {
            int doktorID = Convert.ToInt32(Session["doktorID"]);
            TimeSpan mesai = baslama;
            while (SaatHesap(mesai, periyot) < bitis)
            {
                if (SaatHesap(mesai, periyot) >= ogleBaslama && SaatHesap(mesai, periyot) <= ogleBitis)
                {
                    mesai = SaatHesap(mesai, periyot);
                    continue;
                }
                else
                {
                    mesai = SaatHesap(mesai, periyot);
                    mesaiClass.Ekle(doktorID, mesai);
                }
            }
        }
        private TimeSpan SaatHesap(TimeSpan baslama, TimeSpan periyot)
        {
            return baslama + periyot;
        }
    }
}