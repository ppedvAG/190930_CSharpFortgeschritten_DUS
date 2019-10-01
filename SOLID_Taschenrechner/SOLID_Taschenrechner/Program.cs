using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Taschenrechner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bitte geben Sie die Formel ein:");
            string eingabe = Console.ReadLine(); // "2 + 2"

            string[] teile = eingabe.Split();
            int zahl1 = Convert.ToInt32(teile[0]);
            int zahl2 = Convert.ToInt32(teile[2]);
            string rechenoperator = teile[1];

            int ergebnis = 0;
            if (rechenoperator == "+")
                ergebnis = zahl1 + zahl2;
            else if (rechenoperator == "-")
                ergebnis = zahl1 - zahl2;
            // ....

            Console.WriteLine($"Das Ergebnis ist {ergebnis}");

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
