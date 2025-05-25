using AplicativoMicro.Persistencias;
using Micro_OndasAPI.Models;
using Micro_OndasAPI.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicativoMicro
{
    public partial class Cadastrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            HttpStatusCode http;
            RetornoPadraoModel retorno;

            UsuarioModel usuario = new UsuarioModel()
            {
                nome = txtNome.Text,
                login = txtLogin.Text,
                senha = txtSenha.Text
            };

            CadastrarPersistencia cadastrar = new CadastrarPersistencia();
            retorno = cadastrar.Inserir(usuario, out http);

            if (retorno.Status == true)
            {
                lblMensagem.ForeColor = System.Drawing.Color.Green;
                lblMensagem.Text = "Cadastrado com sucesso!";
                Response.Redirect("Login.aspx");
            }
            else
            {
                lblMensagem.Text = "OPS... Algo deu errado: " + retorno.Mensagem;
            }
        }
    }
}