using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _027_Hastane_Randevu.doktor
{
    public partial class RGecmis : System.Web.UI.Page
    {
        RandevuClass rGecmis = new RandevuClass();
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
                {
                    RGecmisGetir();
                }
            }
        }
        private void RGecmisGetir()
        {
            repRandevuGecmis.DataSource = rGecmis.Getir(Convert.ToInt32(Session["doktorID"]));
            repRandevuGecmis.DataBind();
        }
    }
}