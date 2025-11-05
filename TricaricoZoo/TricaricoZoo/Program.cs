using System;
using TricaricoZoo;

class Program
{
    static void Main()
    {
        //Pinguino
        Pinguino entity0 = new Pinguino("Skipper", 8, 14.2, new DateTime(2018, 3, 10), 3, 4, 5, 0.5);

        entity0.MostraInformazioni();

        //Elefante
        Elefante entity1 = new Elefante("Anchali", 13, 160, new DateTime(2012, 8, 12), 200, 200, 88, 3);
        entity1.MostraInformazioni();
    }
}
