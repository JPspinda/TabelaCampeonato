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

        public void GanhouPerdeu(int golsTime1, int golsTime2)
        {
            if(golsTime1 > golsTime2)
            {
                Time1.SomarPontuacao(3);
            }
            else if(golsTime1 < golsTime2)
            {
                Time2.SomarPontuacao(3);
            }
            else
            {
                Time1.SomarPontuacao(1);
                Time2.SomarPontuacao(1);
            }
        }

        public override string ToString()
        {
            return $"{Time1.Nome} {PlacarTime1} X {PlacarTime2} {Time2.Nome}";
        }
    }
}
