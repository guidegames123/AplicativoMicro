using AplicativoMicro.Persistencias;
using Micro_OndasAPI.Models;
using Micro_OndasAPI.Models.Programa;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicativoMicro
{
    public partial class MicroOndas : System.Web.UI.Page
    {
        int minutos;
        int segundos;
        int potencia;
        string tempo_digitado;
        string caractere;
        bool input;
        bool pausa;
        bool programa_rapido = false;
        int usuario_id;

        List<ProgramaModel> lista = new List<ProgramaModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            btn0.Enabled = false;
            usuario_id = int.Parse(Request.QueryString["usuarioId"]);
            if (!IsPostBack)
            {
                HttpStatusCode http;
                Timer1.Enabled = false;
                minutos = 0;
                segundos = 0;
                potencia = 10;
                tempo_digitado = "";
                caractere = ".";
                input = false;
                pausa = false;

                Session["minutos"] = minutos;
                Session["segundos"] = segundos;
                Session["potencia"] = potencia;
                Session["tempo_digitado"] = tempo_digitado;
                Session["caractere"] = caractere;
                Session["input"] = input;
                Session["pausa"] = pausa;
                Session["programa_rapido"] = programa_rapido;

                lblPotencia.Text = "Potência: 10";
                lblTempoPotencia.Text = "";
                lbVisor.Text = "00:00";

                lista.Add(new ProgramaModel { id = 0, nome = "Pipoca", alimento = "Pipoca (de micro-ondas)",caractere_animacao = "0", tempo = 300, potencia = 7, descricao = "Observar o barulho de estouros do milho, caso houver um intervalo de mais de 10 segundos entre um estouro e outro, interrompa o aquecimento." });
                lista.Add(new ProgramaModel { id = 0, nome = "Leite", alimento = "Leite", tempo = 500, potencia = 5, caractere_animacao = "1", descricao = "Cuidado com aquecimento de líquidos, o choque térmico aliado ao movimento do recipiente pode causar fervura imediata causando risco de queimaduras." });
                lista.Add(new ProgramaModel { id = 0, nome = "Carnes de boi", alimento = "Carne em pedaço ou fatias", caractere_animacao = "2", tempo = 1400, potencia = 4, descricao = "Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para o descongelamento uniforme" });
                lista.Add(new ProgramaModel { id = 0, nome = "Frango", alimento = "Frango (qualquer corte)", caractere_animacao = "3", tempo = 800, potencia = 7, descricao = "Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para o descongelamento uniforme." });
                lista.Add(new ProgramaModel { id = 0, nome = "Feijão", alimento = "Feijão congelado", caractere_animacao = "4", tempo = 800, potencia = 9, descricao = "Deixe o recipiente destampado e em casos de plástico, cuidado ao retirar o recipiente pois o mesmo pode perder resistência em altas temperaturas." });
                
                ProgramaPersistencia programa = new ProgramaPersistencia();
                RetornoPadraoModel retorno = programa.Listar(usuario_id,out http);
                if (retorno.Status) {
                    var json = JsonConvert.DeserializeObject<List<ProgramaModel>>(retorno.Data.ToString());
                    foreach (ProgramaModel programaM in json)
                    {
                        lista.Add(programaM);
                    }
                }
                
                gvProgramacoes.DataSource = lista;
                gvProgramacoes.DataBind();

            }
        }

        protected void gvProgramacoes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ProgramaModel item = (ProgramaModel)e.Row.DataItem;
                if (item.id != 0)
                {
                    e.Row.Font.Bold = true;
                }
            }
        }


        protected void gvProgramacoes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Usar")
            {
                lblTempoPotencia.Text = "";
                tempo_digitado = "";
                AtualizaVisor();
                potencia = 10;
                lblPotencia.Text = "Potência: 10";
                input = false;
                pausa = false;
                programa_rapido = true;
                SalvaEstado();

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvProgramacoes.Rows[index];

                string nome = row.Cells[0].Text;
                string tempo = row.Cells[2].Text;
                if (row.Cells[3].Text != "")
                {
                    potencia = int.Parse(row.Cells[3].Text);
                }
                else {
                    potencia = 10;
                }

                if (row.Cells[5].Text != "&nbsp;")
                {
                    caractere = row.Cells[5].Text;
                }
                else
                {
                    caractere = ".";
                }

                    tempo_digitado = tempo;
                lblPotencia.Text = $"Potência: {potencia}";
                AtualizaVisor();
                SalvaEstado();
            }
        }

        private void AtualizaEstado()
        {
            minutos = (int)Session["minutos"];
            segundos = (int)Session["segundos"];
            potencia = (int)Session["potencia"];
            tempo_digitado = (string)Session["tempo_digitado"];
            caractere = (string)Session["caractere"];
            input = (bool)Session["input"];
            pausa = (bool)Session["pausa"];
            programa_rapido = (bool)Session["programa_rapido"];
            bloquearBotoes();



        }

        private void SalvaEstado()
        {
            Session["minutos"] = minutos;
            Session["segundos"] = segundos;
            Session["potencia"] = potencia;
            Session["tempo_digitado"] = tempo_digitado;
            Session["caractere"] = caractere;
            Session["input"] = input;
            Session["pausa"] = pausa;
            Session["programa_rapido"] = programa_rapido;
        }

        public void bloquearBotoes() {
            if (programa_rapido)
            {
                btn0.Enabled = false;
                btn1.Enabled = false;
                btn2.Enabled = false;
                btn3.Enabled = false;
                btn4.Enabled = false;
                btn5.Enabled = false;
                btn6.Enabled = false;
                btn7.Enabled = false;
                btn8.Enabled = false;
                btn9.Enabled = false;
                btnComecar.Enabled = false;
                btnFuncao.Enabled = false;
                btnPotencia.Enabled = false;
                gvProgramacoes.Enabled = false;
            }
            else {
                btn0.Enabled = true;
                btn1.Enabled = true;
                btn2.Enabled = true;
                btn3.Enabled = true;
                btn4.Enabled = true;
                btn5.Enabled = true;
                btn6.Enabled = true;
                btn7.Enabled = true;
                btn8.Enabled = true;
                btn9.Enabled = true;
                btnFuncao.Enabled = true;
                btnPotencia.Enabled = true;
                btnComecar.Enabled = true;
                gvProgramacoes.Enabled = true;
            }

        }

        private void adicionaNumero(int botao_numero)
        {
            if (programa_rapido) { return; }
            AtualizaEstado();

            if (tempo_digitado.Length < 4)
            {
                tempo_digitado += botao_numero;
                AtualizaVisor();

                if ((minutos >= 2 && segundos > 0) || minutos > 2)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Digite um valor menor que 2 minutos.');", true);
                    tempo_digitado = "";
                    AtualizaVisor();
                    SalvaEstado();
                    return;
                }

            }
            else
            {
                tempo_digitado = "";
                AtualizaVisor();
                SalvaEstado();
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Existe mais de quatro números digitados...');", true);
            }
            SalvaEstado();
        }

        private void AtualizaVisor()
        {
            input = true;

            string texto = tempo_digitado.PadLeft(4, '0');

            minutos = int.Parse(texto.Substring(0, 2));
            segundos = int.Parse(texto.Substring(2, 2));

            minutos += segundos / 60;
            segundos = segundos % 60;

            lbVisor.Text = $"{minutos:00}:{segundos:00}";

        }

        private void InicioRapido()
        {
            tempo_digitado = "";
            if (!pausa && !programa_rapido)
            {
                lblTempoPotencia.Text = "";
                segundos += 30;
                if (segundos >= 60)
                {
                    minutos += 1;
                    segundos -= 60;
                }
                if (minutos > 2)
                {
                    minutos = 2;
                    segundos = 0;
                }
                lbVisor.Text = $"{minutos:00}:{segundos:00}";
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            AtualizaEstado();
            input = false;

            if (minutos == 0 && segundos == 0)
            {
                Timer1.Enabled = false;
                potencia = 10;
                caractere = ".";
                lblPotencia.Text = "Potência: 10";
                lblTempoPotencia.Text += "Aquecimento concluido";
                programa_rapido = false;
                SalvaEstado();
                return;
            }

            if (segundos == 0)
            {
                if (minutos > 0)
                {
                    minutos--;
                    segundos = 59;
                }
            }
            segundos--;
            lblTempoPotencia.Text += new string(char.Parse(caractere), potencia) + " ";

            lbVisor.Text = $"{minutos:00}:{segundos:00}";
            SalvaEstado();
        }

        protected void btnMenu_Click(object sender, EventArgs e) {
            Response.Redirect($"CriarAquecimento.aspx?usuarioId={usuario_id}");
        }

        protected void btnComecar_Click(object sender, EventArgs e)
        {
            AtualizaEstado();

            if (!input || minutos == 0 && segundos == 0)
                InicioRapido();

            tempo_digitado = "";
            Timer1.Enabled = true;
            pausa = false;
            SalvaEstado();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            AtualizaEstado();

            if (pausa || (segundos <= 0 && minutos <= 0))
            {
                programa_rapido = false;
                lblTempoPotencia.Text = "";
                tempo_digitado = "";
                AtualizaVisor();
                potencia = 10;
                lblPotencia.Text = "Potência: 10";
                input = false;
                pausa = false;
                
                SalvaEstado();
                return;
            }

            Timer1.Enabled = false;
            pausa = true;
            SalvaEstado();
        }

        protected void btnPotencia_Click(object sender, EventArgs e)
        {

            AtualizaEstado();
            try
            {
                potencia = int.Parse(tempo_digitado);
            }
            catch
            {
                potencia = 0;
            }

            if (potencia >= 1 && potencia <= 10)
            {
                lblPotencia.Text = "Potência: " + potencia;
                tempo_digitado = "";
                AtualizaVisor();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Digite uma potência de 1 a 10.');", true);
                potencia = 10;
                lblPotencia.Text = "Potência: 10";
            }

            if (segundos <= 0 && minutos <= 0)
                input = false;

            SalvaEstado();
            
        }

        

        protected void btn0_Click(object sender, EventArgs e) => adicionaNumero(0);
        protected void btn1_Click(object sender, EventArgs e) => adicionaNumero(1);
        protected void btn2_Click(object sender, EventArgs e) => adicionaNumero(2);
        protected void btn3_Click(object sender, EventArgs e) => adicionaNumero(3);
        protected void btn4_Click(object sender, EventArgs e) => adicionaNumero(4);
        protected void btn5_Click(object sender, EventArgs e) => adicionaNumero(5);
        protected void btn6_Click(object sender, EventArgs e) => adicionaNumero(6);
        protected void btn7_Click(object sender, EventArgs e) => adicionaNumero(7);
        protected void btn8_Click(object sender, EventArgs e) => adicionaNumero(8);
        protected void btn9_Click(object sender, EventArgs e) => adicionaNumero(9);

       

    }
}