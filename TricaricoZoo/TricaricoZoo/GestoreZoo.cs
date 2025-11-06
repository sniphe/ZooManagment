using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TricaricoZoo
{
    internal class GestoreZoo
    {
        public string NomeZoo { get; set; }
        public double BudgetMensile { get; set; }
        public int NumeroVisitatoriMensili { get; set; }

        private List<Animale> _animali = new List<Animale>();
        private decimal _costoTotaleAccumulato;
        private List<string> _registroEventi;

        private void AggiungiLog(string evento)
        {
            string voce = $"[{DateTime.Now}] {evento}";
            _registroEventi.Add(voce);
        }

        private bool VerificaBudget()
        {
            double costoTotale = CalcolaCostoTotaleMensile();
            return costoTotale <= BudgetMensile;
        }


        public GestoreZoo(string NomeZoo, double BudgetMensile, int NumeroVisitatoriMensili)
        {
            this.NomeZoo = NomeZoo;
            this.BudgetMensile = BudgetMensile;
            this.NumeroVisitatoriMensili = NumeroVisitatoriMensili;
        }

        public int NumeroAnimali { get { return _animali.Count; } }

        public void AggiungiAnimale(Animale a)
        {
            _animali.Add(a);

            if(_costoTotaleAccumulato > (decimal)BudgetMensile)
            {
                AggiungiLog($"Si è aggiunto l'/il {a.Specie} di nome {a.Nome}, che ha un costo mensile di {a.CalcolaCostoGestioneMensile()}, e incide sullo sforamento del budget mensile di: {_costoTotaleAccumulato - (decimal)BudgetMensile}");
            }
            else
            {
                AggiungiLog($"Si è aggiunto l'/il {a.Specie} di nome {a.Nome}, che ha un costo mensile di {a.CalcolaCostoGestioneMensile()}");
            }

            return;
        }

        public void RimuoviAnimale(string nome)
        {

            foreach (Animale a in _animali) 
            {
                if (a.Nome.ToLower() == nome.ToLower() && a != null)
                {
                    _animali.Remove(a);
                    AggiungiLog("Animale '" + nome + "' rimosso (trasferito o adottato).");
                    break;
                }
                else
                {
                    Console.WriteLine("Nessun animale trovato con il nome '" + nome + "'.");
                }
            }

            return;
        }

        public Animale TrovaAnimale(string nome)
        {
            foreach (Animale a in _animali)
            {
                if (a.Nome.ToLower() == nome.ToLower())
                {
                    return a;
                }
                else
                {
                    Console.WriteLine("Nessun animale trovato con il nome '" + nome + "'.");
                }
            }

            return null;
        }

        public void MostraAnimali()
        {
            if (_animali.Count == 0)
            {
                Console.WriteLine("Non ci sono animali nello zoo.");
            }
            else
            {
                for (int i = 0; i < _animali.Count; i++)
                {
                    Animale a = _animali[i];
                    Console.WriteLine($"- {a.MostraInformazioni}");
                }
            }
            return;
        }

        public double CalcolaCostoTotaleMensile()
        {
            double totale = 0;

            for (int i = 0; i < _animali.Count; i++)
            {
                totale += _animali[i].CalcolaCostoGestioneMensile();
            }

            _costoTotaleAccumulato = (decimal)totale;
            return totale;
        }

        public List<Animale> FiltraPerSpecie(string specie)
        {
            List<Animale> listSpecie = new List<Animale>();

            foreach (Animale animale in _animali) 
            {
                if (animale.Specie.ToLower() == specie.ToLower())
                {
                    listSpecie.Add(animale);
                    return listSpecie;
                }
            }

            return null;
        }

        public List<Animale> FiltraPerStatoSalute(string stato)
        {
            List<Animale> listaFiltrata = new List<Animale>();

            Animale.StatoSalute statoDaCercare;

            bool conversione = Enum.TryParse(stato, true, out statoDaCercare);

            if (conversione == false)
            {
                Console.WriteLine("Valore di stato di salute non valido: " + stato);
                return listaFiltrata;
            }

            for (int i = 0; i < _animali.Count; i++)
            {
                Animale a = _animali[i];

                if (a.StatoAttuale == statoDaCercare)
                {
                    listaFiltrata.Add(a);
                }
            }

            AggiungiLog("Filtrati animali per stato di salute: " +
                        statoDaCercare.ToString() +
                        " (" + listaFiltrata.Count + " trovati).");

            return listaFiltrata;
        }

        public List<Animale> AnimaliInOrdineEta()
        {
            List<Animale> listEtà = new List<Animale>();

            for (int i = 0; i < _animali.Count; i++)
            {
                listEtà.Add(_animali[i]);
            }

            // Bubble Sort
            for (int i = 0; i < listEtà.Count - 1; i++)
            {
                for (int j = 0; j < listEtà.Count - i - 1; j++)
                {
                    if (listEtà[j].Eta > listEtà[j + 1].Eta)
                    {
                        Animale temp = listEtà[j];
                        listEtà[j] = listEtà[j + 1];
                        listEtà[j + 1] = temp;
                    }
                }
            }

            AggiungiLog("Visualizzata lista animali ordinata per età.");

            return listEtà;
        }

        public void ConcertoDiVersi()
        {
            Console.WriteLine("Inizia il concerto degli animali!");
            for (int i = 0; i < _animali.Count; i++)
            {
                Animale a = _animali[i];
                Console.WriteLine(a.Nome + ": " + a.EmettiVerso());
                a.EmettiVerso();
            }

            AggiungiLog("Eseguito concerto dei versi degli animali.");
        }

        public void MostraRegistroEventi()
        {
            Console.WriteLine("=== Registro Eventi Zoo ===");
            for (int i = 0; i < _registroEventi.Count; i++)
            {
                Console.WriteLine(_registroEventi[i]);
            }
        }
    }
}
