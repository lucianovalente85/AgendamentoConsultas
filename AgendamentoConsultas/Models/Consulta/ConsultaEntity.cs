using AgendamentoConsultas.Models.Anamenese;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoConsultas.Models.Consulta
{
    public class ConsultaEntity
    {
        public string id { get; set; }

        public DateTime data_consulta { get; set; }

        public string nomeProcedimento{ get; set; }

        public DateTime horarioConsulta { get; set; }

        public AnameneseEntity anamenese { get; set; }




    }
}
