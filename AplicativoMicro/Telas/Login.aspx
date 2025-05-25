<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AplicativoMicro.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 200px; margin: auto; padding-top: 100px;">
            <asp:Label ID="Label1" runat="server" Text="Login:"></asp:Label><br />
            <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox><br /><br />

            <asp:Label ID="Label2" runat="server" Text="Senha:"></asp:Label><br />
            <asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox><br /><br />

            <asp:Button ID="btnEntrar" runat="server" Text="Entrar" OnClick="btnEntrar_Click" /><br /><br />
            <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" /><br /><br />

            <asp:Label ID="lblMensagem" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
