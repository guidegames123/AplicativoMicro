using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Micro_OndasAPI.Models.Usuario
{
    public class UsuarioModel
    {

        public int id { get; set; }

        public string nome { get; set; }

        public string login { get; set; }

        public string senha { get; set; }

        public string token { get; set; }

    }
}