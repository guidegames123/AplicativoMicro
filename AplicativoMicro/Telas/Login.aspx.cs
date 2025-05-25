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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Executa na carga da página, se necessário
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            HttpStatusCode http;
            RetornoPadraoModel retorno;
            string login = txtLogin.Text;
            string senha = txtSenha.Text;

            UsuarioModel usuario = new UsuarioModel()
            {
                login = login,
                senha = senha,
            };

            CadastrarPersistencia cadastrar = new CadastrarPersistencia();

            retorno = cadastrar.ValidarLogin(usuario, out http);

            if (retorno.Status == true)
            {
                
                Response.Redirect($"MicroOndas.aspx?usuarioId={retorno.Data}");
            }
            else
            {
                lblMensagem.Text = "OPS... Algo deu errado: " + retorno.Mensagem;
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("Cadastrar.aspx");
        }
    }
}