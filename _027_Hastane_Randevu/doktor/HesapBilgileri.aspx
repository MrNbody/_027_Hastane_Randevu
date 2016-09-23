<%@ Page Title="" Language="C#" MasterPageFile="~/doktor/doktorMain.Master" AutoEventWireup="true" CodeBehind="HesapBilgileri.aspx.cs" Inherits="_027_Hastane_Randevu.doktor.HesapBilgileri" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel" runat="server">
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
                    <asp:Button ID="btnKaydet" CssClass="btnKaydet" runat="server" Text="Kaydet" OnClick="btnKaydet_Click" />
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnKaydet" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
