using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _027_Hastane_Randevu.admin
{
    public partial class AdminGiris : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }
        private void Giris()
        {
            if (textboxKullaniciAdi.Text == "halitak" && textboxKullaniciParola.Text == "636363")
            {
                Session["admin"] = textboxKullaniciAdi.Text;
                Response.Redirect("Anasayfa.aspx");
            }
        }
        protected void btnGiris_Click(object sender, EventArgs e)
        {
            Giris();
        }
    }
}