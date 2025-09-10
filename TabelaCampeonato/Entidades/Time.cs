namespace TabelaCampeonato.Entidades
{
    class Time : IComparable
    {
        public string Nome { get; set; }
        public int NumeroDeJogos { get; private set; }
        public int NumeroDeVitorias { get; set; }
        public int NumeroDeEmpates { get; set; }
        public int NumeroDeDerrotas { get; set; }
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

        public void IncrementarNumeroDeJogos()
        {
            NumeroDeJogos += 1;
        }

        public void IncrementarNumeroDeVitorias()
        {
            NumeroDeVitorias += 1;
        }

        public void IncrementarNumeroDeEmpates()
        {
            NumeroDeEmpates += 1;
        }

        public void IncrementarNumeroDeDerrotas()
        {
            NumeroDeDerrotas += 1;
        }

        public override string ToString()
        {
            return $"{Nome, -15} | P: {Pontuacao,-2} | J: {NumeroDeJogos, -2} | V: {NumeroDeVitorias, -2} | E: {NumeroDeEmpates, -2} | " +
                $"D: {NumeroDeDerrotas} | " +
                $"GP: {GolsFeitos, -2} | GC: {GolsTomados, -2} | " +
                $"SG: {SaldoDeGols, -2}";
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

            comparar = outro.NumeroDeVitorias.CompareTo(NumeroDeVitorias);
            if(comparar != 0)
            {
                return comparar;
            }

            return outro.GolsFeitos.CompareTo(GolsFeitos);
        }
    }
}
