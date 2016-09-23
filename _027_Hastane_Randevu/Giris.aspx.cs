using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _027_Hastane_Randevu
{
    public partial class Giris : System.Web.UI.Page
    {
        VeriKontrol VK = new VeriKontrol();
        UyeClass uye = new UyeClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                pnlGiris.Visible = true;
                pnlKayit.Visible = false;
            }
        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            GirisClass giris = new GirisClass();
            if (VK.Kontrol(txtTCno.Text))
                giris.tc = txtTCno.Text;
            if (VK.Kontrol(txtParola.Text))
                giris.parola = txtParola.Text;
            Uye uye = giris.UyeGirisYap();
            if (uye != null)
            {
                Giriss(uye.uyeID, uye.uyeAd, uye.uyeSoyad);
            }
            else
                lblGiris.Text = "Giriş Yapılamadı";
        }
        private void Giriss(int uyeID, string uyeAd, string uyeSoyad)
        {
            Session["uyeID"] = uyeID;
            Session["uyeAd"] = uyeAd;
            Session["uyeSoyad"] = uyeSoyad;
            Response.Redirect("AnaSayfa.aspx");
        }
        protected void btnKayit_Click(object sender, EventArgs e)
        {
            pnlGiris.Visible = false;
            pnlKayit.Visible = true;
        }

        protected void btnIptal_Click(object sender, EventArgs e)
        {
            pnlGiris.Visible = true;
            pnlKayit.Visible = false;
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            Kaydol();
        }
        private void Kaydol()
        {
            if (VK.Kontrol(TextBoxEmail.Text))
                uye.Email = TextBoxEmail.Text;
            if (VK.Kontrol(TextBoxParola.Text))
                uye.Sifre = TextBoxParola.Text;
            if (VK.Kontrol(TextBoxTc.Text))
                uye.Tc = TextBoxTc.Text;
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

            if (uye.UyeKontrol(TextBoxTc.Text)!=null)
            {
                lblKayit.Text = "Böyle bir TC ile zaten kayıt var";
            }
            else
            {
                if (uye.Ekle() != 0)
                    lblKayit.Text = "Eklendi";
                else
                    lblKayit.Text = "Eklenmedi";
            }

            //Uye uyee = uye.Ekle();
            //Giriss(uyee.uyeID, uyee.uyeAd, uyee.uyeSoyad);
        }
    }
}