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
                
        public List<PlanoSaudeEntity> plano = new List<PlanoSaudeEntity>()
        {
             new PlanoSaudeEntity{planoSaude="UNIMED"},
             new PlanoSaudeEntity{planoSaude="AMIL"},
             new PlanoSaudeEntity{planoSaude="SAUDE SERVIDOR"},
             new PlanoSaudeEntity{planoSaude="BRADESCO"},
             new PlanoSaudeEntity{planoSaude="OUTROS"}
        };

        public ConsultaEntity consulta { get; set; }
    }
}
