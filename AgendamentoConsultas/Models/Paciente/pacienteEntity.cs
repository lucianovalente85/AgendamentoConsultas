using AgendamentoConsultas.Models.Consulta;
using AgendamentoConsultas.Models.PlanoSaude;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoConsultas.Models.Paciente
{
    public class PacienteEntity
    {
        public string Id { get; set; }
        public int Codigo { get; set; }
        public int Cpf { get; set; }
        public DateTime DataNascimento{ get; set; }
                
        public List<PlanoSaudeEntity> Plano = new List<PlanoSaudeEntity>()
        {
             new PlanoSaudeEntity{PlanoSaude="UNIMED"},
             new PlanoSaudeEntity{PlanoSaude="AMIL"},
             new PlanoSaudeEntity{PlanoSaude="SAUDE SERVIDOR"},
             new PlanoSaudeEntity{PlanoSaude="BRADESCO"},
             new PlanoSaudeEntity{PlanoSaude="OUTROS"}
        };

        public ConsultaEntity Consulta { get; set; }
        public int ConsultaId { get; set; }
    }
}
