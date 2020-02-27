using AgendamentoConsultas.Models.Anamenese;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoConsultas.Models.Consulta
{
    public class ConsultaEntity
    {
        public string Id { get; set; }

        public DateTime DataConsulta { get; set; }

        public string NomeProcedimento{ get; set; }

        public DateTime HorarioConsulta { get; set; }

        public AnameneseEntity Anamenese { get; set; }
        public int AnameneseId { get; set; }




    }
}
