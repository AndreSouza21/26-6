using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_Strategy
{
    internal class EstrategiaSexta : EstrategiaDia
    {
        public ResultadoEstrategia Executar(string informacaoAdicional)
        {
            string mensagem = $"Dia de encerramento: registre o que foi concluído na tarefa \"{informacaoAdicional}\".";
            return new ResultadoEstrategia("ALTA", mensagem);
        }
    }
}
