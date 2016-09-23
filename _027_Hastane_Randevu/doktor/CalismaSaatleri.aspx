<%@ Page Title="" Language="C#" MasterPageFile="~/doktor/doktorMain.Master" AutoEventWireup="true" CodeBehind="CalismaSaatleri.aspx.cs" Inherits="_027_Hastane_Randevu.doktor.CalismaSaatleri" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <div class="body">
                <div>
                    <label>Başlama Saati</label>
                    <asp:TextBox ID="TextboxBaslamaSaati" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label>Bitiş Saati</label>
                    <asp:TextBox ID="TextboxBitisSaati" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label>Çalışma Periyodu</label>
                    <asp:TextBox ID="TextboxCalismaPeriyodu" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label>Öğle Başlama Saati</label>
                    <asp:TextBox ID="TextboxOgleBaslama" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label>Öğle Bitiş Saati</label>
                    <asp:TextBox ID="TextboxOgleBitis" runat="server"></asp:TextBox>
                </div>
                <div class="btnKaydet">
                    <asp:Label ID="labelMesaj" runat="server" Text="Mesaj"></asp:Label>
                    <asp:Button ID="btnKaydet" CssClass="btnKaydet" runat="server" Text="Ekle" OnClick="btnKaydet_Click" />
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnKaydet" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
