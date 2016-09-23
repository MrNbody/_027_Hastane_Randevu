<%@ Page Title="Anasayfa" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AnaSayfa.aspx.cs" Inherits="_027_Hastane_Randevu.AnaSayfa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>

    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <script>
        $(function () {
            $(".usadt").dialog();
        });
    </script>
    <script>
        function test() {
            $(".ust").dialog();
        }
    </script>
    <script>
        $(function () {
            $("#<%=txtTarih.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' }).val();
        });
    </script>
    <script>
        jQuery(function () {
            var dlg = jQuery(".asdasd").dialog({
                draggable: true,
                resizable: true,
                show: 'Transfer',
                hide: 'Transfer',
                width: 320,
                autoOpen: false,
                minHeight: 10,
                minwidth: 10
            });
            dlg.parent().appendTo(jQuery("form:first"));
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="randevu-wrap">
        <div class="ust">
            <asp:Label ID="lblSaat" runat="server" CssClass="lblSaat"></asp:Label>
            <asp:Label ID="lblAdi" runat="server" CssClass="lblHos"></asp:Label>
        </div>
        <div class="sol">




            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>


            <asp:UpdatePanel ID="updatepanelSolTaraf" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <asp:Panel ID="pnlRandevuAra" runat="server">



                        <div class="lstbx">
                            Şehir<asp:DropDownList ID="listSehir" runat="server" AutoPostBack="true" OnSelectedIndexChanged="listSehir_SelectedIndexChanged"></asp:DropDownList>
                        </div>

                        <div class="lstbx">
                            İlçe<asp:DropDownList ID="listIlce" runat="server" AutoPostBack="true" OnSelectedIndexChanged="listIlce_SelectedIndexChanged"></asp:DropDownList>
                        </div>

                        <div class="lstbx">
                            Hastane<asp:DropDownList ID="listHastane" runat="server" AutoPostBack="true" OnSelectedIndexChanged="listHastane_SelectedIndexChanged"></asp:DropDownList>
                        </div>

                        <div class="lstbx">
                            Klinik<asp:DropDownList ID="listKlinik" runat="server" AutoPostBack="true" OnSelectedIndexChanged="listKlinik_SelectedIndexChanged"></asp:DropDownList>
                        </div>

                        <div class="lstbx">
                            Doktor<asp:DropDownList ID="listDoktor" runat="server" AutoPostBack="true" OnSelectedIndexChanged="listDoktor_SelectedIndexChanged"></asp:DropDownList>
                        </div>

                        <div class="lstbx">
                            Tarih<asp:TextBox ID="txtTarih" runat="server"></asp:TextBox>
                        </div>

                        <div class="temizle">
                            <asp:Button ID="btnTemizle" Text="Temizle" runat="server" OnClick="btnTemizle_Click" OnClientClick="test()" />
                        </div>
                        <div class="randevu">
                            <asp:Button ID="btnRandevuAra" Text="Randevu Ara" runat="server" OnClick="btnRandevuAra_Click" />
                        </div>
                    </asp:Panel>


                    <asp:Panel ID="pnlRandevuDetay" runat="server" Visible="false">
                        <div class="detay">
                            <div>
                                <span>Hastane: </span>
                                <asp:Label ID="labelHastane" runat="server"></asp:Label>
                            </div>
                            <div>
                                <span>Klinik: </span>
                                <asp:Label ID="labelKlinik" runat="server"></asp:Label>
                            </div>
                            <div>
                                <span>Doktor: </span>
                                <asp:Label ID="labelDoktor" runat="server"></asp:Label>
                            </div>
                            <div>
                                <span>Randevu Tarih: </span>
                                <asp:Label ID="labelTarih" runat="server"></asp:Label>
                            </div>
                            <div>
                                <span>Randevu Saat: </span>
                                <asp:Label ID="labelSaat" runat="server"></asp:Label>
                            </div>
                            <div>
                                <asp:Button ID="btnRandevuAl" CssClass="btnRandevuAl" runat="server" Text="Randevu Al" OnClick="btnRandevuAl_Click" />
                            </div>
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="pnlRandevuDetayMesaj" runat="server" Visible="false">
                        <div class="detay">
                            <asp:Label ID="lblRandevuDetayMesaj" runat="server"></asp:Label>
                        </div>
                    </asp:Panel>

                </ContentTemplate>

            </asp:UpdatePanel>
        </div>
        <div class="sag">
            <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Panel ID="pnlKlavuz" runat="server">
                        <ul>
                            <li>
                                <h1>Hoş Geldiniz</h1>
                            </li>
                            <li>
                                <h2>Randevunuzu 3 adımda alabileceksiniz.</h2>
                            </li>
                            <li>
                                <h3>1. adımda sol taraftaki arama araçlarını kullanarak uygun hekimlerin listesini getirebilirsiniz.</h3>
                            </li>
                            <li>
                                <h3>2. adımda hekim listesinden istediğiniz hekimi seçerek hekim çalışma cetvelini görüntüleyebilirsiniz.</h3>
                            </li>
                            <li>
                                <h3>3. adımda hekim çalışma cetvelinden uygun bir slot seçip randevunuzu kaydedebilirsiniz.</h3>
                            </li>
                        </ul>
                    </asp:Panel>

                    <asp:Panel ID="pnlRandevu" runat="server">
                        <div class="saat">

                            <asp:Repeater ID="repRandevu" runat="server" OnItemDataBound="repRandevu_ItemDataBound" OnItemCommand="repRandevu_ItemCommand">
                                <ItemTemplate>
                                    <div>
                                        <asp:HiddenField ID="hdMesaiID" runat="server" Value='<%#Eval("mesaiID") %>' />
                                        <asp:Button ID="btnRandevu" runat="server" CommandArgument='<%#Eval("mesaiID") %>' CommandName="Choose" Text=' <%#Eval("mesaiSaat").ToString().Substring(0,5) %>' OnClick="btnRandevu_Click"></asp:Button>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>

                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="alt">

            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pnlList" runat="server" Visible="false">
                        <asp:Repeater ID="repDoktor" runat="server" OnItemCommand="repDoktor_ItemCommand">
                            <HeaderTemplate>
                                <div class="listDoktorc">
                                    Doktor
                                </div>
                                <div class="listDoktorc">
                                    Klinik
                                </div>
                                <div class="listDoktorc">
                                    Hastane
                                </div>
                                <div class="listDoktorc">
                                    İlçe
                                </div>
                                <div class="listDoktorc">
                                    Şehir
                                </div>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%--                                <asp:LinkButton ID="lnkbtnDoktor" CommandArgument='<%#Eval("doktorID") %>' runat="server" CommandName='Click'>--%>

                                <div class="listDoktora">
                                    <%--<a href="AnaSayfa.aspx?doktorID=<%# Eval("doktorID") %>"><%# Eval("doktorAd") %></a>--%>
                                    <%--<asp:HyperLink ID="HyperLink1" NavigateUrl='<%# String.Format("~/AnaSayfa.aspx?doktorID={0}", Eval("doktorID")) %>' runat="server"><%# Eval("doktorAd") %></asp:HyperLink>--%>
                                    <label>
                                        <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Eval("doktorID") %>' runat="server" CommandName='Click'><%# Eval("doktorAd") %></asp:LinkButton></label>

                                </div>
                                <div class="listDoktora">
                                    <%--<a href="AnaSayfa.aspx?doktorID=<%# Eval("doktorID") %>"><%# Eval("klinikAd") %></a>--%>
                                    <%--<asp:HyperLink ID="HyperLink2" NavigateUrl='<%# String.Format("~/AnaSayfa.aspx?doktorID={0}", Eval("doktorID")) %>' runat="server"><%# Eval("klinikAd") %></asp:HyperLink>--%>
                                    <label><%# Eval("klinikAd") %></label>
                                </div>
                                <div class="listDoktora">
                                    <%--<a href="AnaSayfa.aspx?doktorID=<%# Eval("doktorID") %>"><%# Eval("hastaneAd") %></a>--%>
                                    <%--<asp:HyperLink ID="HyperLink3" NavigateUrl='<%# String.Format("~/AnaSayfa.aspx?doktorID={0}", Eval("doktorID")) %>' runat="server"><%# Eval("hastaneAd") %></asp:HyperLink>--%>
                                    <label><%# Eval("hastaneAd") %></label>
                                </div>
                                <div class="listDoktora">
                                    <%--<a href="AnaSayfa.aspx?doktorID=<%# Eval("doktorID") %>"><%# Eval("ilceAd") %></a>--%>
                                    <%--<asp:HyperLink ID="HyperLink4" NavigateUrl='<%# String.Format("~/AnaSayfa.aspx?doktorID={0}", Eval("doktorID")) %>' runat="server"><%# Eval("ilceAd") %></asp:HyperLink>--%>
                                    <label><%# Eval("ilceAd") %></label>
                                </div>
                                <div class="listDoktora">
                                    <%--<a href="AnaSayfa.aspx?doktorID=<%# Eval("doktorID") %>"><%# Eval("sehirAd") %></a>--%>
                                    <%--<asp:HyperLink ID="HyperLink5" NavigateUrl='<%# String.Format("~/AnaSayfa.aspx?doktorID={0}", Eval("doktorID")) %>' runat="server"><%# Eval("sehirAd") %></asp:HyperLink>--%>
                                    <label><%# Eval("sehirAd") %></label>
                                </div>

                                <%--                                </asp:LinkButton>--%>
                            </ItemTemplate>
                            <FooterTemplate>
                            </FooterTemplate>
                        </asp:Repeater>
                    </asp:Panel>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnRandevuAra" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>


        </div>
    </div>

</asp:Content>
