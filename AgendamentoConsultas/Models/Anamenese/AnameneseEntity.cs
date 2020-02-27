using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoConsultas.Models.Anamenese
{
    public class AnameneseEntity
    {
        public int Id { get; set; }
        public string Sintomas { get; set; }
        public string DoencasPreExistentes { get; set; }
        public List<PartedoCorpoEntity> PartesdoCorpo = new List<PartedoCorpoEntity>()
        {
            new PartedoCorpoEntity{PartesdoCorpo="cabeça"},
            new PartedoCorpoEntity{PartesdoCorpo="abdomem"},
            new PartedoCorpoEntity{PartesdoCorpo="membros superiores"},
            new PartedoCorpoEntity{PartesdoCorpo="membros inferiores"},
        };
    }
}
