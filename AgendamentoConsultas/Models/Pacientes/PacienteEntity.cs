using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoConsultas.Models.Pacientes
{
    public class PacienteEntity
    {
        public int Id { get; set; }
        [Index(IsUnique=true)]
        [Required(ErrorMessage = "Favor informar um código.")]
        public int Codigo { get; set; }
        [Required(ErrorMessage ="Favor informar um nome.")]
        public string Nome { get; set; }
        [Index(IsUnique = true)]
        [StringLength(11)]
        [Required(ErrorMessage = "Favor informar um CPF.")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Favor informar uma senha.")]
        public string Senha { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "Favor informar uma data.")]
        public DateTime DataNascimento { get; set; }
        public int PlanoDeSaudeId { get; set; }
        public PlanoSaudeEntity PlanoDeSaude { get; set; }


    }
}
