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

            Console.WriteLine();

            for (int i = 0; i < rodadas.Count; i++)
            {
                Console.WriteLine($"Rodada {i + 1}:\n");

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

                times.Sort();
                for (int j = 1; j <= n; j++)
                {
                    Console.WriteLine($"{j,-2} | {times[j - 1]}");
                }

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
    }

}
