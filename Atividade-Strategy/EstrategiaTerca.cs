using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_Strategy
{
    internal class EstrategiaTerca : EstrategiaDia
    {
        public ResultadoEstrategia Executar(string informacaoAdicional)
        {
            string mensagem = $"Dia de execução, {informacaoAdicional}: avance nas tarefas pendentes.";
            return new ResultadoEstrategia("ALTA", mensagem);
        }
    }
}
