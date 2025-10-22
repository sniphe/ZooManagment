using System;

namespace TricaricoZoo
{
    class Animale
    {
        public string Nome { get; set; }
        public string Specie { get; set; }
        public int Eta { get; set; }
        public double Peso { get; set; }
        public string StatoDiSalute { get; set; } = "Buono";
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
            if (_pesoIniziale <= 0) return 0;
            return ((Peso - _pesoIniziale) / _pesoIniziale) * 100;
        }

        private string DeterminaStatoSaluteAutomatico()
        {
            double variazionePeso = CalcolaVariazionePesoPercentuale();

            double sogliaOttimo = Eta < 5 ? 30 : 20;
            double sogliaDiscreto = Eta > 20 ? -5 : -10;
            double sogliaCritico = Eta > 25 ? -10 : -20;

            if (Eta > 25 || variazionePeso < sogliaCritico)
                return "Critico";
            else if (variazionePeso < sogliaDiscreto || _numeroControlliVeterinari > 5)
                return "Discreto";
            else if (variazionePeso > sogliaOttimo)
                return "Ottimo";
            else
                return "Buono";
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
            StatoDiSalute = DeterminaStatoSaluteAutomatico();
        }

        public void EffettuaControlloVeterinario()
        {
            _numeroControlliVeterinari++;
            StatoDiSalute = DeterminaStatoSaluteAutomatico();
        }

        public virtual void MostraInformazioni()
        {
            Console.WriteLine($"\n[{Specie}] Nome: {Nome}");
            Console.WriteLine($"Età: {Eta} anni | Anni allo zoo: {AnniAlloZoo()}");
            Console.WriteLine($"Peso: {Peso} kg (Iniziale: {_pesoIniziale} kg, Variazione: {CalcolaVariazionePesoPercentuale():F1}%)");
            Console.WriteLine($"Salute: {StatoDiSalute} | Controlli veterinari: {_numeroControlliVeterinari}");
            Console.WriteLine($"Cibo giornaliero: {CalcolaCiboDiarioKg():F2} kg | Costo mensile: {CalcolaCostoGestioneMensile():F2}€");
            Console.WriteLine($"Verso: {EmettiVerso()}");
        }
    }
}
