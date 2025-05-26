using AplicativoMicro.Persistencias;
using Micro_OndasAPI.Models;
using Micro_OndasAPI.Models.Programa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicativoMicro.Telas
{
    public partial class CriarAquecimento : System.Web.UI.Page
    {
        int usuario_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario_id = int.Parse(Request.QueryString["usuarioId"]);
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            HttpStatusCode http;
            RetornoPadraoModel retorno;
            int potencia = 0;
            int tempo = 0;

            try {
                potencia = int.Parse(txtPotencia.Text);
            } catch (Exception ex) {
                lblMensagem.Text = "OPS... Algo deu errado: Digite um valor inteiro de potencia";
                return;
            }


            try
            {
                tempo = int.Parse(txtTempo.Text);
            }
            catch (Exception ex)
            {
                lblMensagem.Text = "OPS... Algo deu errado: Digite um valor inteiro de tempo";
                return;
            }

            ProgramaModel programa = new ProgramaModel()
            {
                nome = txtNome.Text,
                alimento = txtAlimento.Text,
                caractere_animacao = txtCaractereAnimecao.Text,
                potencia = potencia,
                descricao = txtDescricao.Text,
                tempo = tempo,
                usuario_id = usuario_id
            };

            ProgramaPersistencia cadastrar = new ProgramaPersistencia();
            retorno = cadastrar.Inserir(programa, out http);

            if (retorno.Status == true)
            {
                lblMensagem.ForeColor = System.Drawing.Color.Green;
                lblMensagem.Text = "Cadastrado com sucesso!";
                Response.Redirect($"MicroOndas.aspx?usuarioId={int.Parse(Request.QueryString["usuarioId"])}");
            }
            else
            {
                lblMensagem.Text = "OPS... Algo deu errado: " + retorno.Mensagem;
            }
        }
    }
}