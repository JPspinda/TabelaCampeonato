namespace TabelaCampeonato.Entidades
{
    class Jogo
    {
        public Time Time1 { get; set; }
        public Time Time2 { get; set; }
        public int PlacarTime1 { get; private set; }
        public int PlacarTime2 { get; private set; }

        public Jogo(Time time1, Time time2)
        {
            Time1 = time1;
            Time2 = time2;
        }

        public void AlterarPlacar(int golsTime1, int golsTime2)
        {
            PlacarTime1 += golsTime1;
            PlacarTime2 += golsTime2;
        }

        public override string ToString()
        {
            return $"{Time1} {PlacarTime1} X {PlacarTime2} {Time2}";
        }
    }
}
