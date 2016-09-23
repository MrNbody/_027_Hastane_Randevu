using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _027_Hastane_Randevu.doktor
{
    public partial class HesapBilgileri : System.Web.UI.Page
    {
        VeriKontrol VK = new VeriKontrol();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                object uye = Session["doktorID"];
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
            Doldur doktor = new Doldur();
            var liste = doktor.TextBoxDoktor(Convert.ToInt32(Session["doktorID"]));
            TextBoxEmail.Text = liste.doktorEmail;
            TextBoxParola.Text = liste.doktorSifre;
            TextBoxTc.Text = liste.doktorTc;
            TextBoxAd.Text = liste.doktorAd;
            TextBoxSoyad.Text = liste.doktorSoyad;
            ListBoxCinsiyet.Text = liste.doktorCinsiyet;
            TextBoxTelefon.Text = liste.doktorTel;

        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            admin.DoktorClass uye = new admin.DoktorClass();
            if(VK.Kontrol(TextBoxEmail.Text))
                uye.Email = TextBoxEmail.Text;
            if (VK.Kontrol(TextBoxParola.Text))
                uye.Parola = TextBoxParola.Text;
            //if (VK.Kontrol(TextBoxTc.Text))
            //    uye.Tc = TextBoxTc.Text;
            if (VK.Kontrol(TextBoxAd.Text))
                uye.Ad = TextBoxAd.Text;
            if (VK.Kontrol(TextBoxSoyad.Text))
                uye.Soyad = TextBoxSoyad.Text;
            if (VK.Kontrol(ListBoxCinsiyet.Text))
                uye.Cinsiyet = ListBoxCinsiyet.Text;
            if (VK.Kontrol(TextBoxTelefon.Text))
                uye.Telefon = TextBoxTelefon.Text;

            if (uye.Guncelle(Convert.ToInt32(Session["doktorID"])))
                labelMesaj.Text = "Başarılı";
            else
                labelMesaj.Text = "Hata";
        }
    }
}