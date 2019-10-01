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

            #region Erklärung Indexer
            //Dokument doc = new Dokument();
            //doc.Satz = "Das ist ein langer Satz";

            //// Idee: Gibt mir das erste/zweite/Nte Wort
            //Console.WriteLine(doc[1]);
            //doc[2] = "kein";
            //Console.WriteLine(doc.Satz); 
            #endregion

            MeineListe<int> demo = new MeineListe<int>();

            demo.Add(12);
            demo.Add(34);
            demo.Add(56);

            Console.WriteLine(demo[1]); // "34"
            demo[1] = 99;
            Console.WriteLine(demo[1]); // "99"

            int z1 = 5;
            int z2 = 10;
            int z3 = 15;

            Reihenfolge(z1, z2, z3); // so wie man es "immer" macht
            Reihenfolge(Zahl1: z1, Zahl2: z2, Zahl3: z3); // benannte Argumente
            Reihenfolge(Zahl3: z3, Zahl1: z1, Zahl2: z1); // Reihenfolge vertauscht

            // Variante Alt:

            Reihenfolge(z1, Zahl3: z3, Zahl2: z2); // sobald man einmal was bennent -> IMMER bennen

            // Variante Neu:
            Reihenfolge(z1, Zahl2: 123456, z3);
            // Will man Vertauschen: alles hinschreiben


            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        public void UnsafeClosureDemo()
        {
            int bitteÄndereMich = 12;

            unsafe
            {
                bitteÄndereMich = 99;
            }
        }


        public static void Reihenfolge(int Zahl1, int Zahl2, int Zahl3)
        {
            // ...
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
