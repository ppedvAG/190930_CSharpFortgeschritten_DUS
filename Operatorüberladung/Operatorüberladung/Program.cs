using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operatorüberladung
{
    class Program
    {
        static void Main(string[] args)
        {
            Bruch b1 = new Bruch(1, 2);
            Bruch b2 = new Bruch(1, 4);
            Bruch b3 = new Bruch(1, 8);


            Bruch erg = b1 * (b2 * b3);

            Console.WriteLine($"{erg.Zähler}/{erg.Nenner}");

            erg = b2 * 3;
            Console.WriteLine($"{erg.Zähler}/{erg.Nenner}");


            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
