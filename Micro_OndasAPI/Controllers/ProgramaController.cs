using Micro_OndasAPI.Models;
using Micro_OndasAPI.Models.Programa;
using Micro_OndasAPI.Models.Usuario;
using Micro_OndasAPI.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Micro_OndasAPI.Controllers
{
    [RoutePrefix("api/programa")]
    public class ProgramaController : ApiController
    {

        [HttpPost]
        [Route("Criar")]
        public RetornoPadraoModel Criar([FromBody] ProgramaModel p)
        {
            ProgramasPersistencia programa = new ProgramasPersistencia();
            return programa.CriarPrograma(p);
        }

        [HttpGet]
        [Route("listar")]
        public RetornoPadraoModel Listar(int usuario_id)
        {
            ProgramasPersistencia programa = new ProgramasPersistencia();
            return programa.Listar(usuario_id);
        }

    }
}