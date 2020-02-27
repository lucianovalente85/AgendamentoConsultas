using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoConsultas.Models.Anamenese
{
    public class AnameneseEntity
    {
        public string Sintomas { get; set; }
        public string DoencasPreExistentes { get; set; }
        public List<string> PartesDoCorpo { get; set; }
       
    }
}
