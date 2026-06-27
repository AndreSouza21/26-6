using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_Strategy
{
    internal class EstrategiaQuarta : EstrategiaDia
    {
        public ResultadoEstrategia Executar(string informacaoAdicional)
        {
            string mensagem = $"Dia de revisão: verifique o andamento da atividade \"{informacaoAdicional}\".";
            return new ResultadoEstrategia("MEDIA", mensagem);
        }
    }
}
