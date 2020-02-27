using AgendamentoConsultas.Models.Consulta;
using AgendamentoConsultas.Models.PlanoSaude;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoConsultas.Models.Paciente
{
    public class pacienteEntity
    {
        public string Id { get; set; }
        public int Codigo { get; set; }
        public int Cpf { get; set; }
        public DateTime DataNascimento{ get; set; }

        //DateTime myDateTime = DateTime.Now;
        //string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

         public PlanoSaudeEntity planoSaude { get; set; }

         public ConsultaEntity consulta { get; set; }
    }
}
