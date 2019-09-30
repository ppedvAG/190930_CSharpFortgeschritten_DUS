using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatenUndEreignisse
{
    class Program
    {
        // 1)

        // .NET 1.0
        // Signatur: [public/private...] delegate [rückgabetyp] [Name] ([parameter])
        public delegate void MeinErsterDelegat();
        public delegate void MeinZweiterDelegat(int x);
        // mit ergebnis:
        public delegate int Rechenart(int z1, int z2);
        // -> Delegate für ALLES was "void" ist und "keine Parameter" hat

        static void Main(string[] args)
        {
            #region Erklärung: Delegate
            // Direkter Aufruf:
            // A();
            // B();
            // C(12);

            // Aufruf per Variable (delegate):
            // 1) Delegate-Type
            // 2) Delegate-Instanz
            // 3) Auf der Instanz die ".Invoke()" - Methode aufrufen

            // 2)
            // MeinErsterDelegat del = new MeinErsterDelegat(B); // Ohne Klammern für A !!!!

            // 3)
            // del.Invoke(); 
            #endregion

            #region Abkürzungen
            // 2) Kürzere Schreibweise
            // Anstelle von .... = new MeinErsterDelegat(B);
            // MeinErsterDelegat del = B;

            // 3) Kürzerer Aufruf
            // Anstelle von ... del.Invoke();
            // del(); 
            #endregion

            #region Delegat mit Parameter
            //MeinZweiterDelegat del = C;

            //del.Invoke(1234);
            //del(999); 
            #endregion

            #region Verketten von Delegaten
            // += und -=
            //MeinErsterDelegat del = A;
            //del += B; // Direkt nach A auch B machen

            //del(); 
            #endregion

            #region Action<T> und Func<T>
            //// Action<T> für alles, was VOID ist (maximal 16 Parameter)
            //Action meineAction = A;
            //Action<int> meineC_Action = C;

            //// Func<T> für alles mit Rückgabewert (max 16 Parameter)
            //Func<int, int, int> rechner = Summe;
            //// Das letzte "T" steht für die Ausgabe  
            #endregion

            // Anwendungsfall

            Button b1 = new Button();

            // Das schreibt WindowsForms für euch beim Doppelklick!!!!
            b1.KlickLogik += Speichern; // Bei jedem Klick, mach diese Methode !!!

            b1.MachDenKlick();
            b1.MachDenKlick();
            //b1.KlickLogik = null; // absolut verboten

            b1.MachDenKlick();
            b1.MachDenKlick();
            b1.MachDenKlick();

            //b1.KlickLogik.Invoke(); // verboten
            //b1.KlickLogik.Invoke();

            // Event
            // Events sind sozusagen das "Property" für Delegaten

            b1.Click += B1_Click;

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        private static void B1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public static void Speichern()
        {
            Console.WriteLine("Ich speichere");
        }

        public static void Meinbutton_Click()
        {
            Console.Beep();
            Console.WriteLine("*click*");
        }

        static int Summe(int z1, int z2)
        {
            return z1 + z2;
        }
        static void A()
        {
            Console.WriteLine("A");
        }
        static void B()
        {
            Console.WriteLine("B");
        }
        static void C(int zahl)
        {
            Console.WriteLine($"C{zahl}");
        }
    }
}
