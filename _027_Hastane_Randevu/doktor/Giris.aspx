<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Giris.aspx.cs" Inherits="_027_Hastane_Randevu.doktor.Giris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Doktor Giriş</title>
    <link href="../css/giris.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="giris">
                <div>
                    <label id="ust">Doktor Giriş Ekranı</label>
                </div>
                <div>
                    <label>Kimlik No:</label>
                    <asp:TextBox ID="txtTCno" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label>Parola:</label>
                    <asp:TextBox TextMode="Password" ID="txtParola" runat="server"></asp:TextBox>
                </div>
                <div class="btnKaydet">
                    <asp:Label ID="lblMesaj" runat="server"></asp:Label>
                    <asp:Button ID="btnGiris" Text="Giriş" runat="server" OnClick="btnGiris_Click"/>
                </div>
            </div>
    </div>
    </form>
</body>
</html>
