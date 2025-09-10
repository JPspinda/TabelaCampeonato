namespace TabelaCampeonato.Entidades
{
    class Time
    {
        public string Nome { get; set; }

        public Time(string nome)
        {
            Nome = nome;
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
