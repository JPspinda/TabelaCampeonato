namespace TabelaCampeonato.Entidades
{
    class Time : IComparable
    {
        public string Nome { get; set; }
        public int NumeroDeJogos { get; private set; }
        public int GolsFeitos { get; private set; }
        public int GolsTomados { get; private set; }
        public int SaldoDeGols { get; private set; }
        public int Pontuacao { get; private set; }

        public Time(string nome)
        {
            Nome = nome;
        }

        public void AtualizarGols(int golsFeitos, int golsTomados)
        {
            GolsFeitos += golsFeitos;
            GolsTomados += golsTomados;
            SaldoDeGols += golsFeitos - golsTomados;
        }

        public void SomarPontuacao(int pontuacao)
        {
            Pontuacao += pontuacao;
        }

        public override string ToString()
        {
            return $"{Nome} | Número de Partidas: {NumeroDeJogos} | Gols Feitos: {GolsFeitos} | Gols Tomados: {GolsTomados} | " +
                $"Saldo de Gols: {SaldoDeGols} | Pontuação: {Pontuacao}";
        }

        public int CompareTo(object? obj)
        {
            if (!(obj is Time))
            {
                throw new ArgumentException("Comparing error: argument is not an employee");
            }
            Time outro = obj as Time;

            int comparar = outro.Pontuacao.CompareTo(Pontuacao); ;
            if(comparar != 0)
            {
                return comparar;
            }

            comparar = outro.SaldoDeGols.CompareTo(SaldoDeGols); ;
            if (comparar != 0)
            {
                return comparar;
            }

            return outro.GolsFeitos.CompareTo(GolsFeitos);
        }
    }
}
