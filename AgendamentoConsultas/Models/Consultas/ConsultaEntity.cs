using AgendamentoConsultas.Models.Anamnese;
using AgendamentoConsultas.Models.Pacientes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoConsultas.Models.Consultas
{
    public class ConsultaEntity
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Favor informar uma data.")]
        public DateTime DataConsulta { get; set; }
        [Required(ErrorMessage = "Favor informar um procedimento.")]
        public string NomeProcedimeneto { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [Required(ErrorMessage = "Favor informar um Horário da consulta.")]
        public DateTime HorarioConsulta { get; set; }
        public int PacienteId { get; set; }
        public virtual PacienteEntity Paciente { get; set; }
        public int AnamneseId { get; set; }
        public virtual AnamneseEntity Anamnese { get; set; }
    }
}
