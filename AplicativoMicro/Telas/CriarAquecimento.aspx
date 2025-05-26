<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CriarAquecimento.aspx.cs" Inherits="AplicativoMicro.Telas.CriarAquecimento" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Criar aquecimento</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width:220px; margin:auto;">
            <h2>Criar Aquecimento</h2>

            <asp:Label ID="Label3" runat="server" Text="Nome:" />
            <asp:TextBox ID="txtNome" runat="server" />

            <br />

            <asp:Label ID="Label1" runat="server" Text="Alimento:" />
            <asp:TextBox ID="txtAlimento" runat="server" />

            <br />

            <asp:Label ID="Label2" runat="server" Text="Potencia:" />
            <asp:TextBox ID="txtPotencia" runat="server" />

            <br />

            <asp:Label ID="Label4" runat="server" Text="Caractere:" />
            <asp:TextBox ID="txtCaractereAnimecao" runat="server" />

            <br />

            <asp:Label ID="Label5" runat="server" Text="Tempo:" />
            <asp:TextBox ID="txtTempo" runat="server" />

            <br />

            <asp:Label ID="Label6" runat="server" Text="Descricao:" />
            <asp:TextBox ID="txtDescricao" runat="server" />

            <br /><br />

            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />

            <br /><br />

            <asp:Label ID="lblMensagem" runat="server" ForeColor="Red" />
        </div>
    </form>
</body>
</html>
