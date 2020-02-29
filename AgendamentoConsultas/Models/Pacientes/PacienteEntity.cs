using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoConsultas.Models.Pacientes
{
    public class PacienteEntity
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int Cpf { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public int PlanoSaudeId { get; set; }
        public virtual PlanoSaudeEntity PlanoDeSaude { get; set; }
    }
}
