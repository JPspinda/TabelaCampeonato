using System;
using System.Threading.Channels;
using System.Collections.Generic;
using TabelaCampeonato.Entidades;

namespace SistemaDeJogos
{

    class Program
    {
        static void Main()
        {
            List<Time> times = new List<Time>();

            List<Rodada> rodadas = new List<Rodada>();

            Console.Write("Informe a quantidade de times que gostaria de adicionar no campeonato: ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++)
            {
                Console.Write($"Time #{i}: ");
                string nome = Console.ReadLine();
                times.Add(new Time(nome));
            }

            for(int i = 0; i < n - 1; i++)
            {
                rodadas.Add(new Rodada(i + 1));
            }

            if (n % 2 != 0)
            {
                times.Add(new Time("Folga"));
                n++;
            }

            int jogosPorRodada = n / 2;

            List<Jogo> totalDeJogos = new List<Jogo>();

            Console.ReadLine();
            Console.Clear();

            for (int i = 0; i < rodadas.Count; i++)
            {
                Console.WriteLine($"Rodada #{i + 1}:\n");

                for (int jogo = 0; jogo < jogosPorRodada; jogo++)
                {
                    int casa = (i + jogo) % (n - 1);
                    int fora = (n - 1 - jogo + i) % (n - 1);

                    if (jogo == 0)
                    {
                        fora = n - 1; 
                    }

                    Time time1 = times[casa];
                    Time time2 = times[fora];

                    Jogo partida = new Jogo(time1, time2);

                    Console.WriteLine(partida);

                    Console.Write($"Gols do {time1.Nome}: ");
                    int golsTime1 = int.Parse(Console.ReadLine());

                    Console.Write($"Gols do {time2.Nome}: ");
                    int golsTime2 = int.Parse(Console.ReadLine());

                    partida.AlterarPlacar(golsTime1, golsTime2);

                    time1.AtualizarGols(golsTime1, golsTime2);
                    time2.AtualizarGols(golsTime2, golsTime1);

                    time1.IncrementarNumeroDeJogos();
                    time2.IncrementarNumeroDeJogos();

                    partida.GanhouPerdeu(golsTime1, golsTime2);

                    totalDeJogos.Add(partida);

                    rodadas[i].AdicionarJogo(partida);

                    Console.WriteLine();
                }

                Console.WriteLine($"=== TABELA APÓS A #{i + 1} RODADA ===");
                Console.WriteLine();

                ImprimirTabela(times);

                Console.ReadLine();

                Console.Clear();
            }

            foreach(Rodada rodada in rodadas)
            {
                Console.WriteLine($"Rodada #{rodada.Nome}");
                foreach(Jogo jogo in rodada.Jogos)
                {
                    Console.WriteLine(jogo);
                }
                Console.WriteLine();
            }
        }

        static void ImprimirTabela(List<Time> times)
        {
            Console.WriteLine("==============================================================");
            Console.WriteLine($"{"#",-3} {"Time",-15} {"P",3} {"J",3} {"V",3} {"E",3} {"D",3} {"GP",3} {"GC",3} {"SG",3}");
            Console.WriteLine("--------------------------------------------------------------");

            for (int i = 0; i < times.Count; i++)
            {
                var t = times[i];
                Console.WriteLine(
                    $"{i + 1,-3} {t.Nome,-15} {t.Pontuacao,3} {t.NumeroDeJogos,3} {t.NumeroDeVitorias,3} " +
                    $"{t.NumeroDeEmpates,3} {t.NumeroDeDerrotas,3} {t.GolsFeitos,3} {t.GolsTomados,3} {t.SaldoDeGols,3}"
                );
            }

            Console.WriteLine("==============================================================");
        }
    }

}
