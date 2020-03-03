using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoConsultas.Models.Pacientes
{
    public class PacienteEntity
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public long Cpf { get; set; }
        public string Senha { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataNascimento { get; set; }
        public int PlanoDeSaudeId { get; set; }
        public virtual PlanoSaudeEntity PlanoDeSaude { get; set; }
    }
}
