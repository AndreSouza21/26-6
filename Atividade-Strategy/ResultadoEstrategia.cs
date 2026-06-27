using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_Strategy
{
    internal class ResultadoEstrategia
    {
        private string prioridade;
        private string mensagem;

        public ResultadoEstrategia(string prioridade, string mensagem)
        {
            this.prioridade = prioridade;
            this.mensagem = mensagem;
        }

        public string GetPrioridade()
        {
            return prioridade;
        }

        public string GetMensagem()
        {
            return mensagem;
        }
    }
}
