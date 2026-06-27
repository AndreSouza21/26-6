using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_Strategy
{
    internal class CalendarioSemana
    {
        private static readonly Dictionary<DayOfWeek, string> nomesDias = new Dictionary<DayOfWeek, string>
        {
            { DayOfWeek.Monday,    "segunda-feira" },
            { DayOfWeek.Tuesday,   "terca-feira"   },
            { DayOfWeek.Wednesday, "quarta-feira"  },
            { DayOfWeek.Thursday,  "quinta-feira"  },
            { DayOfWeek.Friday,    "sexta-feira"   },
            { DayOfWeek.Saturday,  "sabado"        },
            { DayOfWeek.Sunday,    "domingo"       },
        };

        public string ObterDiaAtual()
        {
            DayOfWeek diaAtual = DateTime.Now.DayOfWeek;
            return nomesDias[diaAtual];
        }
    }
}
