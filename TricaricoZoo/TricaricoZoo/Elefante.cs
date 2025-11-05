using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TricaricoZoo
{
    class Elefante : Animale
    {
        public int LunghezzaProboscide { get; set; }
        public double ConsumoDiAcquaLitri { get; set; }

        private int _salutePelle, _frequenzaBagniSettimanali;

        public Elefante(string nome, int eta, double peso, DateTime dataArrivo, int lunghezzaProboscide, double consumoDiAcquaLitri, int salutePelle, int frequenzaBagniSettimanali)
        {
            this.Nome = nome;
            this.Specie = "Elefante";
            this.Eta = eta;
            this.Peso = peso;
            this.DataArrivo = dataArrivo;
            this.LunghezzaProboscide = lunghezzaProboscide;
            this.ConsumoDiAcquaLitri = consumoDiAcquaLitri;
            this._salutePelle = salutePelle;
            this._frequenzaBagniSettimanali = frequenzaBagniSettimanali;
        }

        private string CalcolaSalutePelle()
        {
            bool idratato = ConsumoDiAcquaLitri >= 150;

            if (idratato && _frequenzaBagniSettimanali >= 3)
                return "Ottima";
            else if (idratato || _frequenzaBagniSettimanali >= 2)
                return "Buona";
            else
                return "Scarsa";
        }

        private string VerificaIdratazione()
        {
            return ConsumoDiAcquaLitri >= 150 ? "Si" : "No";
        }

        public override string EmettiVerso()
        {
            return "Burrrrrito!";
        }

        public override double CalcolaCiboDiarioKg()
        {
            Random random = new Random();
            return random.Next(150, 200);
        }

        public override double CalcolaCostoGestioneMensile()
        {
            return 800;
        }
        
        public string CapacitaMemoria()
        {
            return "Si dice che gli elefanti abbiano una memoria incredibile... peccato che non ricordino mai dove hanno parcheggiato il topo!";
        }

        public void RegistraBagno(int g)
        {
            _frequenzaBagniSettimanali += g;
            string statoPelle = CalcolaSalutePelle();
            Console.WriteLine($"Stato della pelle aggiornato: {statoPelle}");
        }

        public override void MostraInformazioni()
        {
            Console.WriteLine($"\n[{Specie}] Nome: {Nome}");
            Console.WriteLine($"Età: {Eta} anni | Anni allo zoo: {AnniAlloZoo()}");
            Console.WriteLine($"Peso: {Peso} kg");
            Console.WriteLine($"Salute pelle: {CalcolaSalutePelle()}");
            Console.WriteLine($"Lunghezza proboscide: {LunghezzaProboscide} cm");
            Console.WriteLine($"Consumo giornaliero di acqua: {ConsumoDiAcquaLitri} litri");
            Console.WriteLine($"Elefante ben idratato: {VerificaIdratazione()}");
            Console.WriteLine($"Frequenza bagni settimanali: {_frequenzaBagniSettimanali}");
            Console.WriteLine($"Cibo giornaliero stimato: {CalcolaCiboDiarioKg():F2} kg");
            Console.WriteLine($"Costo gestione mensile: {CalcolaCostoGestioneMensile():F2}€");
            Console.WriteLine($"Memoria: {CapacitaMemoria()}");
            Console.WriteLine($"Verso: {EmettiVerso()}");
            Console.WriteLine("\n\n");
        }
    }
}
