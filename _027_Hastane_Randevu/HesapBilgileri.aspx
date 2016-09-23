<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="HesapBilgileri.aspx.cs" Inherits="_027_Hastane_Randevu.HesapBilgileri" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css"/>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>


        <script>
        $(function () {
            $("#<%=TextBoxTarih.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' }).val();
        });
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                <div class="body">
            <div>
                <label>Tc:</label>
                <asp:TextBox ReadOnly ID="TextBoxTc" runat="server"></asp:TextBox>
            </div>
            <div>
                <label>Ad:</label>
                <asp:TextBox ID="TextBoxAd" runat="server"></asp:TextBox>
            </div>
            <div>
                <label>Soyad:</label>
                <asp:TextBox ID="TextBoxSoyad" runat="server"></asp:TextBox>
            </div>
            <div>
                <label>Cinsiyet:</label>
                <asp:DropDownList ID="ListBoxCinsiyet" runat="server">
                    <asp:ListItem>Erkek</asp:ListItem>
                    <asp:ListItem>Kadın</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                <label>Doğum Yeri:</label>
                <asp:TextBox ID="TextBoxYer" runat="server"></asp:TextBox>
            </div>
            <div>
                <label>Doğum Tarihi:</label>
                <asp:TextBox ID="TextBoxTarih" runat="server"></asp:TextBox>
            </div>
            <div>
                <label>Baba Adı:</label>
                <asp:TextBox ID="TextBoxBaba" runat="server"></asp:TextBox>
            </div>
            <div>
                <label>Anne Adı:</label>
                <asp:TextBox ID="TextBoxAnne" runat="server"></asp:TextBox>
            </div>
            <div>
                <label>Telefon:</label>
                <asp:TextBox ID="TextBoxTelefon" runat="server"></asp:TextBox>
            </div>
            <div>
                <label>E-mail:</label>
                <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
            </div>
            <div>
                <label>Parola:</label>
                <asp:TextBox ID="TextBoxParola" runat="server"></asp:TextBox>
            </div>
            <div class="btnKaydet">
                <asp:Label ID="labelMesaj" runat="server" Text="Mesaj"></asp:Label>
                <asp:Button ID="btnKaydet" CssClass="btnKaydet" runat="server" Text="Kaydet" OnClick="btnKaydet_Click"/>
            </div>
    </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnKaydet" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
