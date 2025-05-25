<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MicroOndas.aspx.cs" Inherits="AplicativoMicro.MicroOndas" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Micro-ondas Simulador</title>
    <style>
        .btn { width: 75px; height: 54px; font-size: 24px; margin: 5px; background-color: #333; color: white; }
        .visor { background-color: #333; color: orange; font-size: 32px; text-align: center; width: 400px; padding: 20px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server" />

        <!-- Timer ASP.NET -->

    <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick" />

        <div class="visor">
            <asp:Label ID="lbVisor" runat="server" Text="00:00"></asp:Label>
        </div>
        <br />

        <!-- Linha 7,8,9 -->
        <asp:Button ID="btn7" runat="server" Text="7" CssClass="btn" OnClick="btn7_Click" />
        <asp:Button ID="btn8" runat="server" Text="8" CssClass="btn" OnClick="btn8_Click" />
        <asp:Button ID="btn9" runat="server" Text="9" CssClass="btn" OnClick="btn9_Click" />
        <br />

        <!-- Linha 4,5,6 -->
        <asp:Button ID="btn4" runat="server" Text="4" CssClass="btn" OnClick="btn4_Click" />
        <asp:Button ID="btn5" runat="server" Text="5" CssClass="btn" OnClick="btn5_Click" />
        <asp:Button ID="btn6" runat="server" Text="6" CssClass="btn" OnClick="btn6_Click" />
        <br />

        <!-- Linha 1,2,3 -->
        <asp:Button ID="btn1" runat="server" Text="1" CssClass="btn" OnClick="btn1_Click" />
        <asp:Button ID="btn2" runat="server" Text="2" CssClass="btn" OnClick="btn2_Click" />
        <asp:Button ID="btn3" runat="server" Text="3" CssClass="btn" OnClick="btn3_Click" />
        <br />

        <!-- Linha menu, 0, potencia -->
        <asp:Button ID="btnFuncao" runat="server" Text="MENU" CssClass="btn" />
        <asp:Button ID="btn0" runat="server" Text="0" CssClass="btn" OnClick="btn0_Click" />
        <asp:Button ID="btnPotencia" runat="server" Text="POT" CssClass="btn" OnClick="btnPotencia_Click" />
        <br />

        <!-- Linha cancelar e começar -->
        <asp:Button ID="btnCancelar" runat="server" Text="❌" CssClass="btn" OnClick="btnCancelar_Click" />
        <asp:Button ID="btnComecar" runat="server" Text="✔" CssClass="btn" OnClick="btnComecar_Click" />
        <br /><br />

        <asp:Label ID="lblPotencia" runat="server" Text="Potência: 10"></asp:Label><br />
        <asp:Label ID="lblTempoPotencia" runat="server" Text=""></asp:Label>

    </form>
</body>
</html>


