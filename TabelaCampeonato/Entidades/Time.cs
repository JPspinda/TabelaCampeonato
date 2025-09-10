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
            return $"{Nome, -15} | Número de Partidas: {NumeroDeJogos, -2} | Gols Feitos: {GolsFeitos, -2} | Gols Tomados: {GolsTomados, -2} | " +
                $"Saldo de Gols: {SaldoDeGols, -2} | Pontuação: {Pontuacao,-2}";
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
