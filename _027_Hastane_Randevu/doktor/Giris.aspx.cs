using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _027_Hastane_Randevu.doktor
{
    public partial class Giris : System.Web.UI.Page
    {
        VeriKontrol VK = new VeriKontrol();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            GirisClass giris = new GirisClass();
            if(VK.Kontrol(txtTCno.Text))
                giris.tc = txtTCno.Text;
            if(VK.Kontrol(txtParola.Text))
                giris.parola = txtParola.Text;
            Doktor doktor = giris.DoktorGirisYap();
            if (doktor != null)
            {
                Giriss(doktor);
            }
            else
                lblMesaj.Text = "Giris Yapılamadı";
                
        }
        private void Giriss(Doktor doktor)
        {
            Session["doktorID"] = doktor.doktorID;
            Session["doktoAd"] = doktor.doktorAd;
            Session["doktoSoyad"] = doktor.doktorSoyad;
            Response.Redirect("AnaSayfa.aspx");
        }
    }
}