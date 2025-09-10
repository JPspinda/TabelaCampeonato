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

            Console.Write("Informe a quantidade de times que gostaria de adicionar no campeonato: ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++)
            {
                Console.Write($"Time #{i}: ");
                string nome = Console.ReadLine();
                times.Add(new Time(nome));
            }

            if (n % 2 != 0)
            {
                times.Add(new Time("Folga"));
                n++;
            }

            int rodadas = n - 1;
            int jogosPorRodada = n / 2;

            List<Jogo> totalDeJogos = new List<Jogo>();

            for (int rodada = 0; rodada < rodadas; rodada++)
            {
                Console.WriteLine($"\nRodada {rodada + 1}:");

                for (int jogo = 0; jogo < jogosPorRodada; jogo++)
                {
                    int casa = (rodada + jogo) % (n - 1);
                    int fora = (n - 1 - jogo + rodada) % (n - 1);

                    if (jogo == 0)
                    {
                        fora = n - 1; 
                    }

                    Time time1 = times[casa];
                    Time time2 = times[fora];

                    Jogo partida = new Jogo(time1, time2);

                    Console.Write($"Placar de {time1.Nome}: ");
                    int golsTime1 = int.Parse(Console.ReadLine());

                    Console.Write($"Placar de {time2.Nome}: ");
                    int golsTime2 = int.Parse(Console.ReadLine());

                    partida.AlterarPlacar(golsTime1, golsTime2);

                    time1.AtualizarGols(golsTime1, golsTime2);
                    time2.AtualizarGols(golsTime2, golsTime1);

                    partida.GanhouPerdeu(golsTime1, golsTime2);

                    totalDeJogos.Add(partida);

                    Console.WriteLine(partida);

                    Console.WriteLine();
                }
                Console.ReadLine();

                Console.Clear();
            }

            foreach(Jogo jogo in totalDeJogos)
            {
                Console.WriteLine(jogo);
            }
            Console.WriteLine();
            foreach(Time time in times)
            {
                Console.WriteLine(time);
            }
        }
    }

}
