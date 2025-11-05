using System;
using TricaricoZoo;

class Program
{
    static void Main()
    {
        Animale entity1 = new Animale();

        entity1.Nome = "Alessio";
        entity1.Specie = "Piagnone (Sotto famiglia dei piccioni urbani)";
        entity1.Eta = 55;
        entity1.Peso = 104;

        entity1.StatoAttuale = Animale.StatoSalute.Buono;

        entity1.DataArrivo = new DateTime(2020, 10, 24);

        entity1.MostraInformazioni();

        //Pinguino
        Pinguino entity2 = new Pinguino("Skipper", 8, 14.2, new DateTime(2018, 3, 10), 3, 4, 5, 0.5);

        entity2.MostraInformazioni();

        entity2.AggiornaPeso(13.0);
        entity2.EffettuaControlloVeterinario();

        Console.WriteLine("\nDopo aggiornamenti:");
        entity2.MostraInformazioni();
    }
}
