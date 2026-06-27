using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_Strategy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SeletorEstrategia seletor = new SeletorEstrategia();
            CalendarioSemana calendario = new CalendarioSemana();

            Console.WriteLine("Exemplo: entrada valida");
            EstrategiaDia estrategiaValida = seletor.Selecionar("quarta-feira");
            ResultadoEstrategia resultadoValido = estrategiaValida.Executar("Implementar relatório");
            ExibirResultado("Ana", "quarta-feira", resultadoValido);

            Console.WriteLine("\nExemplo: entrada invalida / sem estrategia associada");
            EstrategiaDia estrategiaInvalida = seletor.Selecionar("ferias");
            ResultadoEstrategia resultadoInvalido = estrategiaInvalida.Executar("Viagem");
            ExibirResultado("Carlos", "ferias", resultadoInvalido);

            Console.WriteLine("\n\nEstrategia do Dia");
            Console.Write("Informe seu nome: ");
            string nomeUsuario = Console.ReadLine();


            Console.WriteLine("\n1 - Consultar estrategia do dia atual");
            Console.WriteLine("2 - Consultar estrategia de um dia informado manualmente");
            Console.Write("Escolha uma opcao: ");
            string opcao = Console.ReadLine();

            string diaConsultado;

            if (opcao == "2")
            {
                Console.Write("Informe o dia da semana (ex: quarta-feira): ");
                diaConsultado = Console.ReadLine();
            }
            else
            {
                diaConsultado = calendario.ObterDiaAtual();
            }

            Console.Write("Informe a informacao adicional (tarefa pendente, meta semanal, etc): ");
            string informacaoAdicional = Console.ReadLine();

            EstrategiaDia estrategia = seletor.Selecionar(diaConsultado);
            ResultadoEstrategia resultado = estrategia.Executar(informacaoAdicional);

            ExibirResultado(nomeUsuario, diaConsultado, resultado);
        }

        private static void ExibirResultado(string nomeUsuario, string diaConsultado, ResultadoEstrategia resultado)
        {
            
            Console.WriteLine($"\nUsuario: {nomeUsuario}");
            Console.WriteLine($"Dia consultado: {diaConsultado}");
            Console.WriteLine($"Prioridade: {resultado.GetPrioridade()}");
            Console.WriteLine($"Mensagem: {resultado.GetMensagem()}");
        }
    }
}
