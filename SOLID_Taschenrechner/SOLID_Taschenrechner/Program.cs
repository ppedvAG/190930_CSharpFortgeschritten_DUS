using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Taschenrechner
{
    // 1) Jede Aufgabe (IO/Parsen/Rechnen) bekommt eine eigene Klasse
    // 2) Dependency-Inversion: Konfiguration der App in "Main()" 
    //    ----> Schnittstellen erstellen 

    class Program
    {
        // Bootstrapping: Initialisierung vom Code
        static void Main(string[] args)
        {
            IParser parser = new StringSplitParser();
            IRechner rechner = new SimplerRechner();

            new KonsolenUI(parser,rechner).Start();
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

    public interface IParser
    {
        Formel Parse(string input);
    }
    public class StringSplitParser : IParser
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

    public interface IRechner
    {
        int Berechne(Formel f);
    }
    public class SimplerRechner : IRechner
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
        public KonsolenUI(IParser parser, IRechner rechner)
        {
            this.parser = parser;
            this.rechner = rechner;
        }
        private IParser parser;
        private IRechner rechner;

        // Workflow -> Aufruf der Aufgaben in der richtigen Reihenfolge
        public void Start()
        {
            // Ein/Ausgabe
            Console.WriteLine("Bitte geben Sie die Formel ein:");
            string eingabe = Console.ReadLine(); // "2 + 2"

            // Parsen
            Formel f = parser.Parse(eingabe);

            // Rechnen
            int ergebnis = rechner.Berechne(f);

            Console.WriteLine($"Das Ergebnis ist {ergebnis}");

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }

}
