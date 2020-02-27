using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoConsultas.Models.PlanoSaude
{
    public class PlanoSaudeEntity
    {
        public List<string> planoSaude = new List<string>()
             {
                new PlanoSaudeEntity {"OUTROS"},
                new PlanoSaudeEntity {"UNIMED" },
                new PlanoSaudeEntity {"AMIL"},
                new PlanoSaudeEntity {"SAUDE SERVIDOR"},
                new PlanoSaudeEntity {"BRADESCO"}
             };

       

    }
}
