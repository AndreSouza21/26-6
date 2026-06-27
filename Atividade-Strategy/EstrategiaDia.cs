using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_Strategy
{
    internal interface EstrategiaDia
    {
        ResultadoEstrategia Executar(string informacaoAdicional);
    }
}
