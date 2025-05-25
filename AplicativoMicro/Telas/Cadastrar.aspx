<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastrar.aspx.cs" Inherits="AplicativoMicro.Cadastrar" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastrar Usuário</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width:220px; margin:auto;">
            <h2>Cadastrar</h2>

            <asp:Label ID="Label3" runat="server" Text="Nome:" />
            <asp:TextBox ID="txtNome" runat="server" />

            <br />

            <asp:Label ID="Label1" runat="server" Text="Login:" />
            <asp:TextBox ID="txtLogin" runat="server" />

            <br />

            <asp:Label ID="Label2" runat="server" Text="Senha:" />
            <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" />

            <br /><br />

            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />

            <br /><br />

            <asp:Label ID="lblMensagem" runat="server" ForeColor="Red" />
        </div>
    </form>
</body>
</html>


