<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RGecmis.aspx.cs" Inherits="_027_Hastane_Randevu.RGecmis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="rgecmis-wrap">
        <asp:Repeater ID="repRandevuGecmis" runat="server">
            <HeaderTemplate>
                <div id="divHeader">
                    <div class="divdoktor">
                        Doktor
                    </div>
                    <div class="divtarih">
                        Tarih
                    </div>
                    <div class="divhastane">
                        Hastane
                    </div>
                    <div class="divklinik">
                        Klinik
                    </div>
                    <div class="divsehir">
                        Şehir
                    </div>
                    <div class="divilce">
                        İlçe
                    </div>
                </div>
            </HeaderTemplate>
            <ItemTemplate>
                <div id="divItem">
                    <div class="divdoktor">
                        <label><%# Eval("doktorAd") %></label>
                    </div>
                    <div class="divtarih">
                        <label><%# Convert.ToDateTime(Eval("randevuTarihSaat")).ToLongDateString() %></label>
                    </div>
                    <div class="divhastane">
                        <label><%# Eval("hastaneAd") %></label>
                    </div>
                    <div class="divklinik">
                        <label><%# Eval("klinikAd") %></label>
                    </div>
                    <div class="divsehir">
                        <label><%# Eval("sehirAd") %></label>
                    </div>
                    <div class="divilce">
                        <label><%# Eval("ilceAd") %></label>
                    </div>
                </div>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <div id="divAlter">
                    <div class="divdoktor">
                        <label><%# Eval("doktorAd") %></label>
                    </div>
                    <div class="divtarih">
                        <label><%# Convert.ToDateTime(Eval("randevuTarihSaat")).ToLongDateString() %></label>
                    </div>
                    <div class="divhastane">
                        <label><%# Eval("hastaneAd") %></label>
                    </div>
                    <div class="divklinik">
                        <label><%# Eval("klinikAd") %></label>
                    </div>
                    <div class="divsehir">
                        <label><%# Eval("sehirAd") %></label>
                    </div>
                    <div class="divilce">
                        <label><%# Eval("ilceAd") %></label>
                    </div>
                </div>
            </AlternatingItemTemplate>
        </asp:Repeater>
        <div>
            <asp:Label ID="lblKayitSayisi" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
