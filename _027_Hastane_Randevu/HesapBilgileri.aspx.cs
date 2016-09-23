using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _027_Hastane_Randevu
{
    public partial class HesapBilgileri : System.Web.UI.Page
    {
        VeriKontrol VK = new VeriKontrol();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                object uye = Session["uyeID"];
                if (uye == null)
                {
                    Response.Redirect("Giris.aspx");
                }
                else
                    Doldur();
            }
        }
        private void Doldur()
        {
            Doldur uye = new Doldur();
            var liste = uye.TextBoxUye(Convert.ToInt32(Session["uyeID"]));
            TextBoxEmail.Text = liste.uyeEmail;
            TextBoxParola.Text = liste.uyeSifre;
            TextBoxTc.Text = liste.uyeTc;
            TextBoxAd.Text = liste.uyeAd;
            TextBoxSoyad.Text = liste.uyeSoyad;
            ListBoxCinsiyet.Text = liste.uyeCins;
            TextBoxYer.Text = liste.uyeDogumYer;
            TextBoxTarih.Text = liste.uyeDogumTarih.ToShortDateString();
            TextBoxBaba.Text = liste.uyeBabaAd;
            TextBoxAnne.Text = liste.uyeAnneAd;
            TextBoxTelefon.Text = liste.uyeTel;

        }
        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            UyeClass uye = new UyeClass();
            if(VK.Kontrol(TextBoxEmail.Text))
                uye.Email = TextBoxEmail.Text;
            if (VK.Kontrol(TextBoxParola.Text))
                uye.Sifre = TextBoxParola.Text;
            //if (VK.Kontrol(TextBoxTc.Text))
            //    uye.Tc = TextBoxTc.Text;
            if (VK.Kontrol(TextBoxAd.Text))
                uye.Ad = TextBoxAd.Text;
            if (VK.Kontrol(TextBoxSoyad.Text))
                uye.Soyad = TextBoxSoyad.Text;
            if (VK.Kontrol(ListBoxCinsiyet.Text))
                uye.Cins = ListBoxCinsiyet.Text;
            if (VK.Kontrol(TextBoxYer.Text))
                uye.DogumYeri = TextBoxYer.Text;
            if (VK.Kontrol(TextBoxTarih.Text))
                uye.DogumTarihi = Convert.ToDateTime(TextBoxTarih.Text);
            if (VK.Kontrol(TextBoxAnne.Text))
                uye.AnneAd = TextBoxAnne.Text;
            if (VK.Kontrol(TextBoxBaba.Text))
                uye.BabaAd = TextBoxBaba.Text;
            if (VK.Kontrol(TextBoxTelefon.Text))
                uye.Tel = TextBoxTelefon.Text;

            //if (uye.UyeKontrol(TextBoxTc.Text) != null) 
            //{
            //    labelMesaj.Text = "Böyle bir TC ile zaten kayıt var";
            //}
            //else
            //{
                if (uye.Guncelle(Convert.ToInt32(Session["uyeID"])))
                    labelMesaj.Text = "Başarılı";
                else
                    labelMesaj.Text = "Hata";
            //}
        }
    }
}