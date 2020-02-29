using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoConsultas.Models.Anamnese
{
    public class AnamneseEntity
    {
        public int Id { get; set; }
        public string Sintomas { get; set; }
        public string DoencasPreExistentes { get; set; }
        public int ParteDoCorpoId { get; set; }
        public virtual ParteDoCorpoEntity ParteDoCorpo { get; set; }
    }
}
