using System;

namespace TricaricoZoo
{
    class Pinguino : Animale
    {
        public Pinguino(string nome, int eta, double peso, DateTime dataArrivo)
        {
            Nome = nome;
            Specie = "Pinguino";
            Eta = eta;
            Peso = peso;
            DataArrivo = dataArrivo;
            InizializzaPesoIniziale();
        }

        public override string EmettiVerso()
        {
            return "Squawk! (verso del pinguino)";
        }

        public override double CalcolaCiboDiarioKg()
        {
            Random random = new Random();
            return Peso * (0.1 + random.NextDouble() * (1.5 - 0.1));
        }

        public override double CalcolaCostoGestioneMensile()
        {
            return 150.0;
        }

        public override void MostraInformazioni()
        {
            Console.WriteLine("\n=== Scheda Pinguino ===");
            base.MostraInformazioni();
        }
    }
}
