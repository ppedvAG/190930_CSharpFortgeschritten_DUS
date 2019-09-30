using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ObjectStack
            //// Problemstellung:
            ////object[] data = new object[5];
            ////data[0] = "12";
            ////data[1] = "abcde";
            ////data[2] = new StringBuilder();

            ////int zahl1 = (int) data[0];

            //// Eigene "Liste" erfinden

            //ObjectStack os = new ObjectStack();

            //os.Push(12);
            //os.Push(44);
            //os.Push("Hallo Welt");
            //os.Push(12312312);

            //os.Push(8765);

            //Console.WriteLine(os.Pop());
            //Console.WriteLine(os.Pop());
            //Console.WriteLine(os.Pop());
            //Console.WriteLine(os.Pop());
            //Console.WriteLine(os.Pop());

            //// Console.WriteLine(os.Pop()); // Exception wenn der Stack leer ist 
            #endregion

            #region Generics
            ////GenericStack<string> intStack = new GenericStack<string>();

            ////intStack.Push("asdasd");
            ////intStack.Pop();

            ////MachEtwas("Hallo Welt");
            ////MachEtwas(12);
            ////MachEtwas(new ObjectStack());

            //// Iterator-Pattern
            ////IList<Tier> meineTiere = new List<Tier>();
            ////List<Hund> meineHunde = new List<Hund>();

            ////// Normale Polymorphie
            ////meineTiere.Add(new Hund()); // weil der Hund ein Tier ist
            ////// meineHunde.Add(new Tier()); // geht nicht ...

            ////meineTiere = meineHunde; // Geht als List<T> nicht, da die List<T> auch elemente entgegennimmt 
            #endregion


            // Erklärung: Indexer:
            Dokument doc = new Dokument();
            doc.Satz = "Das ist ein langer Satz";

            // Idee: Gibt mir das erste/zweite/Nte Wort
            Console.WriteLine(doc[1]);
            doc[2] = "kein";
            Console.WriteLine(doc.Satz);

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        public static void VerarbeiteDieListe(IEnumerable<Tier> meineListe)
        {
            // datenverarbeitungslogik
        }

        public static void MachEtwas<T>(T item) where T : new()
        {
            Console.WriteLine($"Ich mache etwas mit: {item}");
        }

    }
}
