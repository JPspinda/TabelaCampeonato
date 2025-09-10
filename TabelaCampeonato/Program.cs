using System;
using System.Threading.Channels;

namespace SistemaDeJogos
{

    class Program
    {
        static void Main()
        {
            // Lista de times
            List<string> times = new List<string>
        {
            "Time1", "Time2", "Time3", "Time4", "Time5",
            "Time6", "Time7", "Time8", "Time9", "Time10"
        };

            int n = times.Count;

            if (n % 2 != 0)
            {
                times.Add("Folga"); // Caso fosse ímpar
                n++;
            }

            int rodadas = n - 1;
            int jogosPorRodada = n / 2;

            // Geração das rodadas
            for (int rodada = 0; rodada < rodadas; rodada++)
            {
                Console.WriteLine($"\nRodada {rodada + 1}:");

                for (int jogo = 0; jogo < jogosPorRodada; jogo++)
                {
                    int casa = (rodada + jogo) % (n - 1);
                    int fora = (n - 1 - jogo + rodada) % (n - 1);

                    if (jogo == 0)
                    {
                        fora = n - 1; // último time fixo
                    }

                    Console.WriteLine($"{times[casa]} x {times[fora]}");
                }
            }
        }
    }

}
