<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminGiris.aspx.cs" Inherits="_027_Hastane_Randevu.admin.AdminGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Giriş</title>
    <link href="css/adminGiris.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="adminGiris">
        <div>
            <label>Kullanıcı Adı:</label>
            <asp:TextBox ID="textboxKullaniciAdi" runat="server"></asp:TextBox>
        </div>
        <div>
            <label>Parola:</label>
            <asp:TextBox ID="textboxKullaniciParola" TextMode="Password" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnGiris" Text="Giriş" runat="server" OnClick="btnGiris_Click"/>
        </div>
    </div>
    </form>
</body>
</html>
