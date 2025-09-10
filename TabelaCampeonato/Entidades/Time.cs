namespace TabelaCampeonato.Entidades
{
    class Time
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

        public override string ToString()
        {
            return $"{Nome} | Número de Partidas: {NumeroDeJogos} | Gols Feitos: {GolsFeitos} | Gols Tomados: {GolsTomados} | " +
                $"Saldo de Gols: {SaldoDeGols} | Pontuação: {Pontuacao}";
        }
    }
}
