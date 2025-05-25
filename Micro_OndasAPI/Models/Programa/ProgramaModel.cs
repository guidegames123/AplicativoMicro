using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Micro_OndasAPI.Models.Programa
{
    public class ProgramaModel
    {

        public int id { get; set; }
        public string nome { get; set; }
        public string alimento { get; set; }
        public int potencia { get; set; }
        public string caractere_animacao { get; set; }
        public int tempo { get; set; }
        public string descricao { get; set; }
        public int usuario_id { get; set; }

    }
}