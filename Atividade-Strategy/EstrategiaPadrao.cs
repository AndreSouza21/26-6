using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_Strategy
{
    internal class EstrategiaPadrao : EstrategiaDia
    {
        public ResultadoEstrategia Executar(string informacaoAdicional)
        {
            string mensagem = $"Não há estratégia cadastrada para o dia informado, {informacaoAdicional}. Nenhuma ação foi executada.";
            return new ResultadoEstrategia("BAIXA", mensagem);
        }
    }
}
