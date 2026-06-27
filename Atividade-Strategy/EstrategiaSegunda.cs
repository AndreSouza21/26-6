using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_Strategy
{
    internal class EstrategiaSegunda : EstrategiaDia
    {
        public ResultadoEstrategia Executar(string informacaoAdicional)
        {
            string mensagem = $"Dia de planejamento, {informacaoAdicional}: organize suas prioridades para a semana.";
            return new ResultadoEstrategia("ALTA", mensagem);
        }
    }
}
