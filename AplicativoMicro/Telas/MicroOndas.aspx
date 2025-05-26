<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MicroOndas.aspx.cs" Inherits="AplicativoMicro.MicroOndas" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Micro-ondas Simulador</title>
    <style>
        .btn {
            width: 75px;
            height: 54px;
            font-size: 24px;
            margin: 5px;
            background-color: #333;
            color: white;
            border: none;
            cursor: pointer;
        }

        .visor {
            background-color: #333;
            color: orange;
            font-size: 32px;
            text-align: center;
            width: 400px;
            padding: 20px;
            border-radius: 8px;
        }

        .container {
            display: flex;
            gap: 50px;
            justify-content: center;
            align-items: flex-start;
            margin-top: 30px;
        }

        .painel {
            display: flex;
            flex-direction: column;
            align-items: center;
        }

        .tabela {
            width: 600px;
        }

        .grid {
            border-collapse: collapse;
            width: 100%;
        }

        .grid th, .grid td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: center;
        }

        .grid th {
            background-color: #333;
            color: white;
        }

        .teclado {
            display: grid;
            grid-template-columns: repeat(3, 1fr);
            gap: 10px;
            margin-top: 15px;
        }

        .acoes {
            display: grid;
            grid-template-columns: repeat(2, 1fr);
            gap: 10px;
            margin-top: 10px;
        }

        .labelPotencia {
            margin-top: 15px;
            font-size: 18px;
        }

        .labelTempoPotencia {
            width: 400px;
            word-wrap: break-word;
            text-align: center;
            margin-top: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick" />

        <div class="container">
            <!-- Painel do Micro-ondas -->
            <div class="painel">
                <div class="visor">
                    <asp:Label ID="lbVisor" runat="server" Text="00:00"></asp:Label>
                </div>

                <!-- Teclado numérico -->
                <div class="teclado">
                    <asp:Button ID="btn7" runat="server" Text="7" CssClass="btn" OnClick="btn7_Click" />
                    <asp:Button ID="btn8" runat="server" Text="8" CssClass="btn" OnClick="btn8_Click" />
                    <asp:Button ID="btn9" runat="server" Text="9" CssClass="btn" OnClick="btn9_Click" />

                    <asp:Button ID="btn4" runat="server" Text="4" CssClass="btn" OnClick="btn4_Click" />
                    <asp:Button ID="btn5" runat="server" Text="5" CssClass="btn" OnClick="btn5_Click" />
                    <asp:Button ID="btn6" runat="server" Text="6" CssClass="btn" OnClick="btn6_Click" />

                    <asp:Button ID="btn1" runat="server" Text="1" CssClass="btn" OnClick="btn1_Click" />
                    <asp:Button ID="btn2" runat="server" Text="2" CssClass="btn" OnClick="btn2_Click" />
                    <asp:Button ID="btn3" runat="server" Text="3" CssClass="btn" OnClick="btn3_Click" />

                    <asp:Button ID="btnFuncao" runat="server" Text="MENU" CssClass="btn" OnClick="btnMenu_Click"/>
                    <asp:Button ID="btn0" runat="server" Text="0" CssClass="btn" OnClick="btn0_Click" />
                    <asp:Button ID="btnPotencia" runat="server" Text="POT" CssClass="btn" OnClick="btnPotencia_Click" />
                </div>

                <!-- Botões de ação -->
                <div class="acoes">
                    <asp:Button ID="btnCancelar" runat="server" Text="❌" CssClass="btn" OnClick="btnCancelar_Click" />
                    <asp:Button ID="btnComecar" runat="server" Text="✔" CssClass="btn" OnClick="btnComecar_Click" />
                </div>

                <!-- Labels -->
                <div class="labelPotencia">
                    <asp:Label ID="lblPotencia" runat="server" Text="Potência: 10"></asp:Label><br />
                    
                </div>

                <div class="labelTempoPotencia">
                    <asp:Label ID="lblTempoPotencia" runat="server" Text=""></asp:Label>
                </div>

            </div>

            <!-- Tabela de Programações -->
            <div class="tabela">
               <asp:GridView ID="gvProgramacoes" runat="server" AutoGenerateColumns="False" CssClass="grid" OnRowCommand="gvProgramacoes_RowCommand" OnRowDataBound="gvProgramacoes_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="nome" HeaderText="Nome" />
                        <asp:BoundField DataField="alimento" HeaderText="Alimento" />
                        <asp:BoundField DataField="tempo" HeaderText="Tempo (s)" />
                        <asp:BoundField DataField="potencia" HeaderText="Potência" />
                        <asp:BoundField DataField="descricao" HeaderText="Descrição" />
                        <asp:BoundField DataField="caractere_animacao" HeaderText="Caractere" />
                        <asp:ButtonField ButtonType="Button" Text="Usar" CommandName="Usar" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>

    </form>
</body>
</html>
