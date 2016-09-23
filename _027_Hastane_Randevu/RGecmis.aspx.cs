using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _027_Hastane_Randevu
{
    public partial class RGecmis : System.Web.UI.Page
    {
        RandevuClass rGecmis = new RandevuClass();
        string a;
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
                {
                    RGecmisGetir();
                }
            }
        }
        private void RGecmisGetir()
        {
            repRandevuGecmis.DataSource = rGecmis.Getir(Convert.ToInt32(Session["uyeID"]));
            repRandevuGecmis.DataBind();
        }
    }
}