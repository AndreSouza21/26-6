using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_Strategy
{
    internal class SeletorEstrategia
    {
        private readonly Dictionary<string, EstrategiaDia> estrategias;
        private readonly EstrategiaDia estrategiaPadrao;

        public SeletorEstrategia()
        {
            estrategiaPadrao = new EstrategiaPadrao();

            estrategias = new Dictionary<string, EstrategiaDia>
            {
                { "segunda-feira", new EstrategiaSegunda() },
                { "terca-feira",   new EstrategiaTerca()   },
                { "quarta-feira",  new EstrategiaQuarta()  },
                { "quinta-feira",  new EstrategiaQuinta()  },
                { "sexta-feira",   new EstrategiaSexta()   },
                { "sabado",        new EstrategiaSabado()  },
                { "domingo",       new EstrategiaDomingo() },
            };
        }

        public EstrategiaDia Selecionar(string nomeDia)
        {
            if (string.IsNullOrWhiteSpace(nomeDia))
            {
                return estrategiaPadrao;
            }

            string chave = NormalizarNomeDia(nomeDia);

            if (estrategias.TryGetValue(chave, out EstrategiaDia estrategia))
            {
                return estrategia;
            }

            return estrategiaPadrao;
        }

        private string NormalizarNomeDia(string nomeDia)
        {
            string normalizado = nomeDia.Trim().ToLower();

            normalizado = normalizado
                .Replace("á", "a").Replace("ã", "a").Replace("â", "a")
                .Replace("é", "e").Replace("ê", "e")
                .Replace("í", "i")
                .Replace("ó", "o").Replace("ô", "o").Replace("õ", "o")
                .Replace("ú", "u")
                .Replace("ç", "c");

            return normalizado;
        }
    }
}
