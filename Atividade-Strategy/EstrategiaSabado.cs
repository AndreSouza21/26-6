using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_Strategy
{
    internal class EstrategiaSabado : EstrategiaDia
    {
        public ResultadoEstrategia Executar(string informacaoAdicional)
        {
            string mensagem = $"Dia de descanso, {informacaoAdicional}: realize estudo livre ou descanso.";
            return new ResultadoEstrategia("BAIXA", mensagem);
        }
    }
}
