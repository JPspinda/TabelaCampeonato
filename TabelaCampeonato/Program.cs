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

                    Console.WriteLine($"{times[casa]} x {times[fora]}");
                }
            }
        }
    }

}
