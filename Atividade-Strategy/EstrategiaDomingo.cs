using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_Strategy
{
    internal class EstrategiaDomingo : EstrategiaDia
    {
        public ResultadoEstrategia Executar(string informacaoAdicional)
        {
            string mensagem = $"Dia de planejamento, {informacaoAdicional}: planeje a próxima semana e defina sua meta semanal.";
            return new ResultadoEstrategia("BAIXA", mensagem);
        }
    }
}
