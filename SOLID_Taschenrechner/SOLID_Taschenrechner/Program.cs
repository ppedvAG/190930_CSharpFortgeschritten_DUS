using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Taschenrechner
{
    // 1) Jede Aufgabe (IO/Parsen/Rechnen) bekommt eine eigene Klasse

    class Program
    {
        // Bootstrapping: Initialisierung vom Code
        static void Main(string[] args)
        {
            new KonsolenUI().Start();
        }
    }

    public class Formel
    {
        public Formel(int operand1, int operand2, string rechenoperator)
        {
            Operand1 = operand1;
            Operand2 = operand2;
            Rechenoperator = rechenoperator;
        }

        public int Operand1 { get; set; }
        public int Operand2 { get; set; }
        public string Rechenoperator { get; set; }
    }
    public class StringSplitParser
    {
        public Formel Parse(string input)
        {
            string[] teile = input.Split();
            int zahl1 = Convert.ToInt32(teile[0]);
            int zahl2 = Convert.ToInt32(teile[2]);
            string rechenoperator = teile[1];

            return new Formel(zahl1, zahl2, rechenoperator);
        }
    }
    public class IFRechner
    {
        public int Berechne(Formel formel)
        {
            if (formel.Rechenoperator == "+")
                return formel.Operand1 + formel.Operand2;
            else if (formel.Rechenoperator == "-")
                return formel.Operand1 - formel.Operand2;
            else
                throw new ArgumentException($"Operator {formel.Rechenoperator} ist unbekannt");
        }
    }

    public class KonsolenUI
    {
        public void Start()
        {
            // Ein/Ausgabe
            Console.WriteLine("Bitte geben Sie die Formel ein:");
            string eingabe = Console.ReadLine(); // "2 + 2"

            // Parsen
            StringSplitParser parser = new StringSplitParser();
            Formel f = parser.Parse(eingabe);

            // Rechnen
            IFRechner rechner = new IFRechner();
            int ergebnis = rechner.Berechne(f);

            Console.WriteLine($"Das Ergebnis ist {ergebnis}");

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }

}
