using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_Strategy
{
    internal class EstrategiaQuinta : EstrategiaDia
    {
        public ResultadoEstrategia Executar(string informacaoAdicional)
        {
            string mensagem = $"Dia de colaboração, {informacaoAdicional}: colabore com alguém da equipe.";
            return new ResultadoEstrategia("MEDIA", mensagem);
        }
    }
}
