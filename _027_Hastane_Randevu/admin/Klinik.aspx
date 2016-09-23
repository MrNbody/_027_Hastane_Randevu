<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminMain.Master" AutoEventWireup="true" CodeBehind="Klinik.aspx.cs" Inherits="_027_Hastane_Randevu.admin.Klinik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:ScriptManager ID="ScriptManager" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <div class="body">
                <div>
                    <label>Şehir</label>
                    <asp:DropDownList ID="listSehir" runat="server" AutoPostBack="true" OnSelectedIndexChanged="listSehir_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div>
                    <label>İlçe</label>
                    <asp:DropDownList ID="listIlce" runat="server" AutoPostBack="true" OnSelectedIndexChanged="listIlce_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div>
                    <label>Hastane</label>
                    <asp:DropDownList ID="listHastane" runat="server" AutoPostBack="true"></asp:DropDownList>
                </div>
                <div>
                    <label>Klinik</label>
                    <asp:TextBox ID="textboxKlinik" runat="server"></asp:TextBox>
                </div>
                <div class="btnKaydet">
                    <asp:Label ID="labelMesaj" runat="server" Text="Mesaj"></asp:Label>
                    <asp:Button ID="btnKaydet" runat="server" Text="Ekle" OnClick="btnKaydet_Click" />
                </div>
            </div>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnKaydet" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
