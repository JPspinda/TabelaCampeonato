using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabelaCampeonato.Entidades
{
    internal class Rodada
    {
        public int Nome { get; set; }
        public List<Jogo> Jogos = new List<Jogo>();

        public Rodada(int nome)
        {
            Nome = nome;
        }

        public void AdicionarJogo(Jogo jogo)
        {
            Jogos.Add(jogo);
        }
    }
}
