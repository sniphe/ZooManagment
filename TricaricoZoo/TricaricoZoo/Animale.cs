using System;

namespace TricaricoZoo
{
    class Animale
    {
        public enum StatoSalute
        {
            Ottimo,
            Buono,
            Discreto,
            Critico
        }

        public string Nome { get; set; }
        public string Specie { get; set; }
        public int Eta { get; set; }
        public double Peso { get; set; }
        public StatoSalute StatoAttuale { get; set; } = StatoSalute.Buono;
        public DateTime DataArrivo { get; set; }

        private double _pesoIniziale;
        private int _numeroControlliVeterinari;

        public int AnniAlloZoo()
        {
            return 2025 - DataArrivo.Year;
        }

        public void InizializzaPesoIniziale()
        {
            _pesoIniziale = Peso;
        }

        private double CalcolaVariazionePesoPercentuale()
        {
            if (_pesoIniziale <= 0)
                return 0;

            return Math.Abs(((Peso - _pesoIniziale) / _pesoIniziale) * 100);
        }

        private StatoSalute DeterminaStatoSaluteAutomatico()
        {
            return StatoAttuale;
        }

        public virtual double CalcolaCiboDiarioKg()
        {
            return Peso / 20.0;
        }

        public virtual double CalcolaCostoGestioneMensile()
        {
            return 100.0;
        }

        public virtual string EmettiVerso()
        {
            return "L'animale emette un verso.";
        }

        public void AggiornaPeso(double nuovoPeso)
        {
            if (_pesoIniziale == 0)
                _pesoIniziale = nuovoPeso;

            if (nuovoPeso <= 0)
            {
                Console.WriteLine("Peso non valido!");
                return;
            }

            Peso = nuovoPeso;
            StatoAttuale = DeterminaStatoSaluteAutomatico();
        }

        public void EffettuaControlloVeterinario()
        {
            _numeroControlliVeterinari++;
            StatoAttuale = DeterminaStatoSaluteAutomatico();
        }

        public virtual void MostraInformazioni()
        {
            Console.WriteLine($"\n[{Specie}] Nome: {Nome}");
            Console.WriteLine($"Età: {Eta} anni | Anni allo zoo: {AnniAlloZoo()}");
            Console.WriteLine($"Peso: {Peso} kg (Iniziale: {_pesoIniziale} kg, Variazione: {CalcolaVariazionePesoPercentuale():F1}%)");
            Console.WriteLine($"Salute: {StatoAttuale} | Controlli veterinari: {_numeroControlliVeterinari}");
            Console.WriteLine($"Cibo giornaliero: {CalcolaCiboDiarioKg():F2} kg | Costo mensile: {CalcolaCostoGestioneMensile():F2}€");
            Console.WriteLine($"Verso: {EmettiVerso()}");
            Console.WriteLine("\n\n\n\n");
        }
    }
}
