using AgendamentoConsultas.Models.Anamnese;
using AgendamentoConsultas.Models.Pacientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoConsultas.Models.Consultas
{
    public class ConsultaEntity
    {
        public int Id { get; set; }
        public DateTime DataConsulta { get; set; }
        public string NomeProcedimeneto { get; set; }
        public DateTime HorarioConsulta { get; set; }
        public PacienteEntity Paciente { get; set; }
        public AnamneseEntity Anamnese { get; set; }
    }
}
