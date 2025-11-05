using System;

namespace TricaricoZoo
{
    class Pinguino : Animale
    {

        public double TemperaturaAcquaIdeale { get; set; }
        public int NumeroUova { get; set; }


        private double _spessoreGrassoSottocutaneoMm, _tempoInAcquaOreGiornaliere;


        public Pinguino(string nome, int eta, double peso, DateTime dataArrivo, double temperaturaAcquaIdeale, int numeroUova, double tempoInAcquaOreGiornaliere, double spessoreGrassoSottocutaneoMm)
        {
            this.Nome = nome;
            this.Specie = "Pinguino";
            this.Eta = eta;
            this.Peso = peso;
            this.DataArrivo = dataArrivo;
            this.TemperaturaAcquaIdeale = temperaturaAcquaIdeale;
            this.NumeroUova = numeroUova;
            this._tempoInAcquaOreGiornaliere = tempoInAcquaOreGiornaliere;
            this._spessoreGrassoSottocutaneoMm = spessoreGrassoSottocutaneoMm;
            InizializzaPesoIniziale();
        }

        private double CalcolaIsolamentoTermico()
        {
            double v = _spessoreGrassoSottocutaneoMm * 5;
            return v;
        }

        private bool VerificaEsposizioneAcqua()
        {
            return _tempoInAcquaOreGiornaliere >= 4;
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
            Console.WriteLine($"\n[{Specie}] Nome: {Nome}");
            Console.WriteLine($"Età: {Eta} anni | Anni allo zoo: {AnniAlloZoo()}");
            Console.WriteLine($"Peso: {Peso} kg");
            Console.WriteLine($"Salute: {StatoAttuale}");
            Console.WriteLine($"Temperatura ideale dell'acqua: {TemperaturaAcquaIdeale} °C");
            Console.WriteLine($"Numero di uova deposte quest'anno: {NumeroUova}");
            Console.WriteLine($"Spessore grasso sottocutaneo: {_spessoreGrassoSottocutaneoMm} mm");
            Console.WriteLine($"Isolamento termico stimato: {CalcolaIsolamentoTermico():F2}");
            Console.WriteLine($"Tempo in acqua giornaliero: {_tempoInAcquaOreGiornaliere} ore");
            Console.WriteLine($"Ha passato abbastanza tempo in acqua: {(VerificaEsposizioneAcqua() ? "Sì" : "No")}");
            Console.WriteLine($"Cibo giornaliero: {CalcolaCiboDiarioKg():F2} kg | Costo mensile: {CalcolaCostoGestioneMensile():F2}€");
            Console.WriteLine($"Velocità media di nuoto: {VelocitaNuotoKmH()} km/h");
            Console.WriteLine($"Verso: {EmettiVerso()}");
            Console.WriteLine("\n\n\n\n");
        }
    }
}
