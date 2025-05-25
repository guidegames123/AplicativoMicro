using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using Micro_OndasAPI.Models;
using Micro_OndasAPI.Models.Usuario;
using Micro_OndasAPI.Persistencia;

namespace Micro_OndasAPI.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        [HttpPost]
        [Route("Criar")]
        public RetornoPadraoModel Criar([FromBody] UsuarioModel u)
        {
            UsuarioPersistencia usu = new UsuarioPersistencia();
            return usu.CriarUsuario(u);
        }

        [HttpPost]
        [Route("Login")]
        public RetornoPadraoModel login([FromBody] UsuarioLoginModel u)
        {
            UsuarioPersistencia usu = new UsuarioPersistencia();
            return usu.Login(u);
        }
    }
}