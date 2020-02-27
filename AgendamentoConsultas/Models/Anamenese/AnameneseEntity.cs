using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoConsultas.Models.Anamenese
{
    public class AnameneseEntity
    {
        public string Sintomas { get; set; }
        public string DoencasPreExistentes { get; set; }
        public List<PartedoCorpoEntity> partesdoCorpo = new List<PartedoCorpoEntity>()
        {
            new PartedoCorpoEntity{partesdoCorpo="cabeça"},
            new PartedoCorpoEntity{partesdoCorpo="abdomem"},
            new PartedoCorpoEntity{partesdoCorpo="membros superiores"},
            new PartedoCorpoEntity{partesdoCorpo="membros inferiores"},
        };
    }
}
