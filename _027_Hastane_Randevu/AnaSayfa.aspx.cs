using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _027_Hastane_Randevu
{
    public partial class AnaSayfa : System.Web.UI.Page
    {
        VeriKontrol VK = new VeriKontrol();
        Doldur d = new Doldur();
        Listele liste;
        static int sehirID, ilceID, hastaneID, klinikID, doktorID;
        static string hastaneAdi, klinikAdi, doktorAdi;
        static List<viewDoktor> doktorListesi = new List<viewDoktor>();
        static DateTime randevuTarih;
        static TimeSpan randevuSaat;
        doktor.MesaiClass mesai = new doktor.MesaiClass();
        static RandevuClass randevuNesne = new RandevuClass();
        static List<Button> listbutton = new List<Button>();

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

                listDoktor.SelectedIndex = 0;
                listDoktor.Enabled = false;
            }
            else
            {
                listIlce.Enabled = true;
                SelectSehir();

                listHastane.SelectedIndex = 0;
                listHastane.Enabled = false;

                listKlinik.SelectedIndex = 0;
                listKlinik.Enabled = false;

                listDoktor.SelectedIndex = 0;
                listDoktor.Enabled = false;

                ListItem listb = new ListItem("İlçe Seçiniz", "-1");
                listIlce.Items.Insert(0, listb);
            }
            // SelectIlce();
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

                listDoktor.SelectedIndex = 0;
                listDoktor.Enabled = false;
            }
            else
            {
                listHastane.Enabled = true;
                SelectIlce();

                listKlinik.SelectedIndex = 0;
                listKlinik.Enabled = false;

                listDoktor.SelectedIndex = 0;
                listDoktor.Enabled = false;

                ListItem listc = new ListItem("Hastane Seçiniz", "-1");
                listHastane.Items.Insert(0, listc);
            }
            //SelectHastane();
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

                listDoktor.SelectedIndex = 0;
                listDoktor.Enabled = false;
            }
            else
            {
                listKlinik.Enabled = true;
                SelectHastane();

                listDoktor.SelectedIndex = 0;
                listDoktor.Enabled = false;

                ListItem listd = new ListItem("Klinik Seçiniz", "-1");
                listKlinik.Items.Insert(0, listd);
            }
            //SelectKlinik();
        }
        private void SelectHastane()
        {
            hastaneID = Convert.ToInt32(listHastane.SelectedValue);
            listKlinik.DataSource = d.DoldurKlinik(hastaneID);
            listKlinik.DataTextField = "klinikAd";
            listKlinik.DataValueField = "klinikID";
            listKlinik.DataBind();
        }
        protected void listKlinik_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listKlinik.SelectedIndex == 0)
            {
                listDoktor.SelectedIndex = 0;
                listDoktor.Enabled = false;
            }
            else
            {
                listDoktor.Enabled = true;
                SelectKlinik();

                ListItem liste = new ListItem("Doktor Seçiniz", "-1");
                listDoktor.Items.Insert(0, liste);
            }
            //SelectDoktor();
        }
        private void SelectKlinik()
        {
            klinikID = Convert.ToInt32(listKlinik.SelectedValue);
            listDoktor.DataSource = d.DoldurDoktor(klinikID);
            listDoktor.DataTextField = "doktorAd";
            listDoktor.DataValueField = "doktorID";
            listDoktor.DataBind();
        }
        protected void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        private void Temizle()
        {
            listSehir.SelectedIndex = 0;
            listIlce.SelectedIndex = 0;
            listHastane.SelectedIndex = 0;
            listKlinik.SelectedIndex = 0;
            listDoktor.SelectedIndex = 0;
            txtTarih.Text = "";

            listIlce.Enabled = false;
            listHastane.Enabled = false;
            listKlinik.Enabled = false;
            listDoktor.Enabled = false;
        }

        protected void btnRandevuAra_Click(object sender, EventArgs e)
        {
            
            if (txtTarih.Text == "")
            {
                lblAdi.Text = "Tarih Seçmelisiniz";
            }
            else
            {
                pnlList.Visible = true;
                ListeleDoktor();
                pnlKlavuz.Visible = true;
                pnlRandevu.Visible = false;
                if (VK.Kontrol(listHastane.SelectedItem.Text))
                    hastaneAdi = listHastane.SelectedItem.Text;
                if (VK.Kontrol(listKlinik.SelectedItem.Text))
                    klinikAdi = listKlinik.SelectedItem.Text;
                if (VK.Kontrol(listDoktor.SelectedItem.Text))
                    doktorAdi = listDoktor.SelectedItem.Text;
                if (VK.Kontrol(txtTarih.Text))
                    randevuTarih = Convert.ToDateTime(txtTarih.Text);
            }
        }
        private void ListeleDoktor()
        {
            try
            {
                if (listSehir.SelectedIndex != 0)
                {
                    if (listIlce.SelectedIndex != 0)
                    {
                        if (listHastane.SelectedIndex != 0)
                        {
                            if (listKlinik.SelectedIndex != 0)
                            {
                                if (listDoktor.SelectedIndex != 0)
                                    liste = new Listele(listDoktor.SelectedItem.Text, listKlinik.SelectedItem.Text, listHastane.SelectedItem.Text, listIlce.SelectedItem.Text, listSehir.SelectedItem.Text);
                                else
                                    liste = new Listele(listKlinik.SelectedItem.Text, listHastane.SelectedItem.Text, listIlce.SelectedItem.Text, listSehir.SelectedItem.Text);
                            }
                            else
                                liste = new Listele(listHastane.SelectedItem.Text, listIlce.SelectedItem.Text, listSehir.SelectedItem.Text);
                        }
                        else
                            liste = new Listele(listIlce.SelectedItem.Text, listSehir.SelectedItem.Text);
                    }
                    else
                        liste = new Listele(listSehir.SelectedItem.Text);
                }
                randevuTarih = Convert.ToDateTime(txtTarih.Text);
                doktorListesi = liste.ListeleDoktor();
                repDoktor.DataSource = doktorListesi;
                repDoktor.DataBind();
            }
            catch (Exception)
            {
                lblAdi.Text = "En azından bir şehir seçmelisiniz !";
            }
        }

        protected void repRandevu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                Button btn = (Button)e.Item.FindControl("btnRandevu");
                RandevuKontrol(btn);
            }
        }
        private void RandevuKontrol(Button btn)
        {
            randevuNesne.DoktorID = Convert.ToInt32(doktorID);
            //   randevuNesne.RandevuTarih = randevuTarih;
            // randevuNesne.RandevuSaat = TimeSpan.Parse(btn.Text);
            randevuNesne.TarihSaat = randevuTarih.Add(TimeSpan.Parse(btn.Text));
            List<DateTime> randevuListe = randevuNesne.Kontrol();
            foreach (var item in randevuListe)
            {
                //if (btn.Text == item.randevuSaat.ToString().Substring(0, 5))
                //{
                //    btn.Enabled = false;
                //}
                if (btn.Text == item.ToShortTimeString())
                {
                    btn.Enabled = false;
                }
            }
        }

        protected void btnRandevu_Click(object sender, EventArgs e)
        {
            pnlRandevuAra.Visible = false;
            pnlRandevuDetay.Visible = true;
            pnlList.Visible = true;
            RandevuAl(sender);
            updatepanelSolTaraf.Update();
        }

        protected void lnkbtnDoktor_Click(object sender, EventArgs e)
        {

        }

        protected void repRandevu_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Choose":
                    {
                        Mesai mes = mesai.GetirByID(Convert.ToInt32(e.CommandArgument.ToString()));

                        break;
                    }


            }
        }

        protected void repDoktor_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Click":
                    {
                        doktorID = Convert.ToInt32(e.CommandArgument.ToString());

                        hastaneAdi = doktorListesi.Where(w => w.doktorID == doktorID).FirstOrDefault().hastaneAd;
                        klinikAdi = doktorListesi.Where(w => w.doktorID == doktorID).FirstOrDefault().klinikAd;
                        doktorAdi = doktorListesi.Where(w => w.doktorID == doktorID).FirstOrDefault().doktorAd;

                        pnlKlavuz.Visible = false;
                        pnlRandevu.Visible = true;
                        pnlList.Visible = true;

                        //repDoktor.DataSource = doktorListesi;
                        //repDoktor.DataBind();

                        repRandevu.DataSource = mesai.Getir(Convert.ToInt32(doktorID));
                        repRandevu.DataBind();
                        UpdatePanel7.Update();

                        break;
                    }
            }
            
            
        }

        private void RandevuAl(object sender)
        {
            Button btn = sender as Button;
            randevuNesne.DoktorID = Convert.ToInt32(doktorID);
            randevuNesne.UyeID = Convert.ToInt32(Session["uyeID"]);
            //    randevuNesne.RandevuTarih = randevuTarih;
            //    randevuNesne.RandevuSaat = TimeSpan.Parse(btn.Text);
            randevuNesne.TarihSaat = randevuTarih.Add(TimeSpan.Parse(btn.Text));
            randevuSaat = TimeSpan.Parse(btn.Text);
            labelHastane.Text = hastaneAdi;
            labelKlinik.Text = klinikAdi;
            labelDoktor.Text = doktorAdi;
            labelTarih.Text = randevuTarih.ToShortDateString();
            labelSaat.Text = randevuSaat.ToString().Substring(0, 5);
        }

        protected void btnRandevuAl_Click(object sender, EventArgs e)
        {
            lblRandevuDetayMesaj.Text = randevuNesne.Ekle();
            pnlRandevuDetay.Visible = false;
            pnlRandevuDetayMesaj.Visible = true;
            pnlRandevuAra.Visible = false;
            pnlRandevu.Visible = false;
            pnlKlavuz.Visible = true;
            pnlList.Visible = false;
            updatepanelSolTaraf.Update();
        }

        protected void listDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectDoktor();
        }
        private void SelectDoktor()
        {
            doktorID = Convert.ToInt32(listDoktor.SelectedValue);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                object uye = Session["uyeID"];
                if (uye == null)
                {
                    Response.Redirect("Giris.aspx");
                }

                lblSaat.Text = "Saat  " + DateTime.Now.ToLongTimeString();
                lblAdi.Text = "Hoş geldiniz " + Session["uyeAd"] + " " + Session["uyeSoyad"];


                pnlRandevu.Visible = false;
                pnlKlavuz.Visible = true;
                pnlList.Visible = false;

                //listSehir.DataSource = d.DoldurSehir();
                //listSehir.DataTextField = "sehirAd";
                //listSehir.DataValueField = "sehirID";
                //listSehir.DataBind();
                ListDoldur(listSehir, "sehirAd", "sehirID");

                listSehir.Items.Insert(0, new ListItem("Şehir Seçiniz", "-1"));

                listIlce.Items.Insert(0, new ListItem("İlçe Seçiniz", "-1"));

                listHastane.Items.Insert(0, new ListItem("Hastane Seçiniz", "-1"));

                listKlinik.Items.Insert(0, new ListItem("Klinik Seçiniz", "-1"));

                listDoktor.Items.Insert(0, new ListItem("Doktor Seçiniz", "-1"));

                listIlce.Enabled = false;
                listHastane.Enabled = false;
                listKlinik.Enabled = false;
                listDoktor.Enabled = false;

                //ListDoldur(listIlce, "ilceAd", "ilceID");
                //ListDoldur(listHastane, "hastaneAd", "hastaneID");
                //ListDoldur(listKlinik, "klinikAd", "klinikID");
                //ListDoldur(listDoktor, "doktorAd", "doktorID");
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
            if (ad == "doktorAd")
            {
                klinikID = Convert.ToInt32(listKlinik.SelectedValue);
                list.DataSource = d.DoldurDoktor(klinikID);
            }

            list.DataTextField = ad;
            list.DataValueField = id;
            list.DataBind();
        }
    }
}