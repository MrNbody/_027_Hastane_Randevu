<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Giris.aspx.cs" Inherits="_027_Hastane_Randevu.Giris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Giriş</title>
    <link href="css/giris.css" rel="stylesheet" />
    <script>
        function kontrol() {
            var tc = document.getElementById('<%= txtTCno.ClientID %>').value;
            var parola = document.getElementById('<%= txtParola.ClientID %>').value;
            if (tc == "" || parola == "") {
                document.getElementById("btnKayit").disabled = true;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="pnlGiris" runat="server">
            <div class="giris">
                <div>
                    <label id="ust">Vatandaş Giriş Ekranı</label>
                </div>
                <div>
                    <label>Kimlik No:</label>
                    <asp:TextBox ID="txtTCno" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label>Parola:</label>
                    <asp:TextBox TextMode="Password" ID="txtParola" runat="server"></asp:TextBox>
                </div>
                <div class="input">
                    <asp:Label ID="lblGiris" runat="server"></asp:Label>
                    <asp:Button ID="btnGiris" Text="Giriş" runat="server" OnClick="btnGiris_Click"/>
                    <asp:Button ID="btnKayit" Text="Kaydol" runat="server" OnClick="btnKayit_Click"/>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlKayit" runat="server">
            <div class="kaydol">
                    <div>
                        <label>Tc:</label>
                        <asp:TextBox ID="TextBoxTc" runat="server"></asp:TextBox>
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
                <div class="input">
                    <asp:Label ID="lblKayit" runat="server"></asp:Label>
                    <asp:Button ID="btnIptal" Text="Geri" runat="server" OnClick="btnIptal_Click"/>
                    <asp:Button ID="btnKaydet" Text="Kaydol" runat="server" OnClick="btnKaydet_Click"/>
                </div>
            </div>
        </asp:Panel>
    </form>
</body>
</html>
