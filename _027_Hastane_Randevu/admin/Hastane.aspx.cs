using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _027_Hastane_Randevu.admin
{
    public partial class Hastane : System.Web.UI.Page
    {
        int sehirID, ilceID;
        VeriKontrol VK = new VeriKontrol();
        _027_Hastane_Randevu.Doldur d = new Doldur();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                object admin = Session["admin"];
                if (admin == null)
                {
                    Response.Redirect("adminGiris.aspx");
                }

                ListDoldur(listSehir, "sehirAd", "sehirID");

                ListItem lista = new ListItem("Şehir Seçiniz", "-1");
                listSehir.Items.Insert(0, lista);

                ListItem listb = new ListItem("İlçe Seçiniz", "-1");
                listIlce.Items.Insert(0, listb);

                listIlce.Enabled = false;
            }
        }
        private void ListDoldur(DropDownList list, string ad, string id)
        {
            if (ad == "sehirAd")
                list.DataSource = d.DoldurSehir();
            if (ad == "ilceAd")
            {
                sehirID = Convert.ToInt32(listSehir.SelectedValue);
                list.DataSource = d.DoldurIlce(sehirID);
            }
            if (ad == "hastaneAd")
            {
                ilceID = Convert.ToInt32(listIlce.SelectedValue);
                list.DataSource = d.DoldurHastane(ilceID);
            }

            list.DataTextField = ad;
            list.DataValueField = id;
            list.DataBind();
        }

        protected void listSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listSehir.SelectedIndex == 0)
            {
                listIlce.SelectedIndex = 0;
                listIlce.Enabled = false;
            }
            else
            {
                listIlce.Enabled = true;
                SelectSehir();

                ListItem listb = new ListItem("İlçe Seçiniz", "-1");
                listIlce.Items.Insert(0, listb);
            }
        }
        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            HastaneClass hastane = new HastaneClass();
            if(VK.Kontrol(textboxHastane.Text))
                hastane.HastaneAdi = textboxHastane.Text;
            if(VK.Kontrol(listIlce.SelectedValue))
                hastane.IlceID = Convert.ToInt32(listIlce.SelectedValue);

            if (hastane.Ekle())
                labelMesaj.Text = "Eklendi";
            else
                labelMesaj.Text = "Eklenemedi";
        }
        private void SelectSehir()
        {
            sehirID = Convert.ToInt32(listSehir.SelectedValue);
            listIlce.DataSource = d.DoldurIlce(sehirID);
            listIlce.DataTextField = "ilceAd";
            listIlce.DataValueField = "ilceID";
            listIlce.DataBind();
        }
    }
}