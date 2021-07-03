using System;
using System.Diagnostics;
using ClienteCompraCenario;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var cenarioSimulado = new CenarioSimulado();

            const string separador = "==================";
            Console.WriteLine(separador);

            Console.WriteLine("Começando o cenário otimizado");
            var stopwatch = Stopwatch.StartNew();

            var resultadoTotal = cenarioSimulado.AlgoritmoOtimizado();

            Console.WriteLine($"Finalizado o cenário otimizado após {stopwatch.Elapsed.TotalSeconds}s");
            Console.WriteLine($"Resultado Total: {resultadoTotal}");

            Console.WriteLine(separador);
            Console.WriteLine(separador);
            Console.WriteLine("Começando o cenário não otimizado");
            var stopwatch2 = Stopwatch.StartNew();

            var resultadoTotal2 = cenarioSimulado.AlgoritmoNaoOtimizado();

            Console.WriteLine($"Finalizado o cenário não otimizado após {stopwatch2.Elapsed.TotalSeconds}s");
            Console.WriteLine($"Resultado Total: {resultadoTotal2}");
        }
    }
}
