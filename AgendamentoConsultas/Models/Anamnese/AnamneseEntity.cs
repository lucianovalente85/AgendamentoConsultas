using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoConsultas.Models.Anamnese
{
    public class AnamneseEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Favor informar um sintoma.")]
        public string Sintomas { get; set; }
        [Required(ErrorMessage = "Favor informar uma doença pre existente.")]
        public string DoencasPreExistentes { get; set; }
        public int ParteDoCorpoId { get; set; }
        public virtual ParteDoCorpoEntity ParteDoCorpo { get; set; }
    }
}
