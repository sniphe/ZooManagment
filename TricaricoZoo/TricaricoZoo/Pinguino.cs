using System;

namespace TricaricoZoo
{
    class Pinguino : Animale
    {

        public double TemperaturaAcquaIdeale { get; set; }
        public int NumeroUova { get; set; }
        public Pinguino(string nome, int eta, double peso, DateTime dataArrivo, double temperaturaAcquaIdeale, int numeroUova)
        {
            this.Nome = nome;
            this.Specie = "Pinguino";
            this.Eta = eta;
            this.Peso = peso;
            this.DataArrivo = dataArrivo;
            this.TemperaturaAcquaIdeale = temperaturaAcquaIdeale;
            this.NumeroUova = numeroUova;
            InizializzaPesoIniziale();
        }

        private double _spessoreGrassoSottocutaneoMm, _tempoInAcquaOreGiornaliere;

        private int CalcolaIsolamentoTermico()
        {
            return 0;
        }

        private bool VerificaEsposizioneAcqua()
        {
            return true;
        }

        public override string EmettiVerso()
        {
            return "Squawk squawk!";
        }

        public override double CalcolaCiboDiarioKg()
        {
            Random random = new Random();
            return 1 + random.NextDouble();
        }

        public override double CalcolaCostoGestioneMensile()
        {
            return 250;
        }


        public int VelocitaNuotoKmH()
        {
            Random random = new Random();
            return random.Next(10, 16);
        }

        public override void MostraInformazioni()
        {
            Console.WriteLine("\n=== Scheda Pinguino ===");
            base.MostraInformazioni();
        }
    }
}
