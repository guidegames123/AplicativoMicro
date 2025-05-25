using System;
using System.Collections.Generic;
using System.Linq;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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

                lblPotencia.Text = "Potência: 10";
                lblTempoPotencia.Text = "";
                lbVisor.Text = "00:00";
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
        }

        private void adicionaNumero(int botao_numero)
        {
            AtualizaEstado();
            if (tempo_digitado.Length < 4)
            {
                tempo_digitado += botao_numero;
                AtualizaVisor();
            }
            else
            {
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
            if (!pausa)
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
                lblPotencia.Text = "Potência: 10";
                lblTempoPotencia.Text += "Aquecimento concluido";
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
            else
            {
                segundos--;
                lblTempoPotencia.Text += new string(char.Parse(caractere), potencia) + " ";
            }

            lbVisor.Text = $"{minutos:00}:{segundos:00}";
            SalvaEstado();
        }

        protected void btnComecar_Click(object sender, EventArgs e)
        {
            AtualizaEstado();

            if (!input || minutos == 0 && segundos == 0)
                InicioRapido();

            if ((minutos >= 2 && segundos > 0) || minutos > 2)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Digite um valor menor que 2 minutos.');", true);
                SalvaEstado();
                return;
            }

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

        #region Botões Numéricos

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

        #endregion

    }
}