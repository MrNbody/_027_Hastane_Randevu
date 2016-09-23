using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace _027_Hastane_Randevu.admin
{
    public partial class Doktor : System.Web.UI.Page
    {
        int sehirID, ilceID, hastaneID;
        string emailREG = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
    //    string parolaREG = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,20}$";
        string tcREG = @"^\d*$";
        string telREG = @"^(0(\d{3})([ -])?(\d{3})([ -])?(\d{2})([ -])?(\d{2}))$";
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

                ListItem listc = new ListItem("Hastane Seçiniz", "-1");
                listHastane.Items.Insert(0, listc);

                ListItem listd = new ListItem("Klinik Seçiniz", "-1");
                listKlinik.Items.Insert(0, listd);

                listIlce.Enabled = false;
                listHastane.Enabled = false;
                listKlinik.Enabled = false;
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
            if (ad == "klinikAd")
            {
                hastaneID = Convert.ToInt32(listHastane.SelectedValue);
                list.DataSource = d.DoldurKlinik(hastaneID);
            }

            list.DataTextField = ad;
            list.DataValueField = id;
            list.DataBind();
        }
        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            Regex regEmail = new Regex(emailREG);
          //  Regex regParola = new Regex(parolaREG);
            Regex regTc = new Regex(tcREG);
            Regex regTel = new Regex(telREG);

            DoktorClass doktor = new DoktorClass();
            if ((VK.Kontrol(textboxEmail.Text)) && (regEmail.Match(textboxEmail.Text).Success)) 
                doktor.Email =textboxEmail.Text;

            if (VK.Kontrol(textboxParola.Text)/* && (regParola.Match(textboxParola.Text).Success)*/) 
                doktor.Parola = textboxParola.Text;

            if (VK.Kontrol(textboxAd.Text))
                doktor.Ad = textboxAd.Text;

            if (VK.Kontrol(textboxSoyad.Text))
                doktor.Soyad = textboxSoyad.Text;

            if (VK.Kontrol(textboxTC.Text) && (regTc.Match(textboxTC.Text).Success) && textboxTC.Text.Length == 11) 
                doktor.Tc = textboxTC.Text;

            if (VK.Kontrol(textboxTel.Text) && (regTel.Match(textboxTel.Text).Success)) 
                doktor.Telefon = textboxTel.Text;

            if (VK.Kontrol(textboxCinsiyet.Text))
                doktor.Cinsiyet = textboxCinsiyet.Text;

            if (VK.Kontrol(listKlinik.SelectedValue))
                doktor.Klinik = Convert.ToInt32(listKlinik.SelectedValue);

            if (doktor.Ekle())
                labelMesaj.Text = "Eklendi";
            else
                labelMesaj.Text = "Eklenemedi";
        }
        protected void listSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listSehir.SelectedIndex == 0)
            {
                listIlce.SelectedIndex = 0;
                listIlce.Enabled = false;

                listHastane.SelectedIndex = 0;
                listHastane.Enabled = false;

                listKlinik.SelectedIndex = 0;
                listKlinik.Enabled = false;
            }
            else
            {
                listIlce.Enabled = true;
                SelectSehir();

                listHastane.SelectedIndex = 0;
                listHastane.Enabled = false;

                listKlinik.SelectedIndex = 0;
                listKlinik.Enabled = false;

                ListItem listb = new ListItem("İlçe Seçiniz", "-1");
                listIlce.Items.Insert(0, listb);
            }
        }
        private void SelectSehir()
        {
            sehirID = Convert.ToInt32(listSehir.SelectedValue);
            listIlce.DataSource = d.DoldurIlce(sehirID);
            listIlce.DataTextField = "ilceAd";
            listIlce.DataValueField = "ilceID";
            listIlce.DataBind();
        }

        protected void listIlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listIlce.SelectedIndex == 0)
            {
                listHastane.SelectedIndex = 0;
                listHastane.Enabled = false;

                listKlinik.SelectedIndex = 0;
                listKlinik.Enabled = false;
            }
            else
            {
                listHastane.Enabled = true;
                SelectIlce();

                listKlinik.SelectedIndex = 0;
                listKlinik.Enabled = false;

                ListItem listc = new ListItem("Hastane Seçiniz", "-1");
                listHastane.Items.Insert(0, listc);
            }
        }
        private void SelectIlce()
        {
            ilceID = Convert.ToInt32(listIlce.SelectedValue);
            listHastane.DataSource = d.DoldurHastane(ilceID);
            listHastane.DataTextField = "hastaneAd";
            listHastane.DataValueField = "hastaneID";
            listHastane.DataBind();
        }

        protected void listHastane_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listHastane.SelectedIndex == 0)
            {
                listKlinik.SelectedIndex = 0;
                listKlinik.Enabled = false;
            }
            else
            {
                listKlinik.Enabled = true;
                SelectHastane();

                ListItem listd = new ListItem("Klinik Seçiniz", "-1");
                listKlinik.Items.Insert(0, listd);
            }
        }
        private void SelectHastane()
        {
            hastaneID = Convert.ToInt32(listHastane.SelectedValue);
            listKlinik.DataSource = d.DoldurKlinik(hastaneID);
            listKlinik.DataTextField = "klinikAd";
            listKlinik.DataValueField = "klinikID";
            listKlinik.DataBind();
        }
    }
}