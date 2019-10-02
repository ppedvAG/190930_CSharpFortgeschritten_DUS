using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thread_Demo
{
    class Konto
    {
        private int buchungsnummer = 0;
        private object lockObject = new object(); // nur für den Lock()-Block wichtig !
        public decimal Kontostand { get; set; }

        public void Einzahlen(decimal wert)
        {
            lock (lockObject)
            {
                // Hier darf nur 1 Thread hinein
                Console.WriteLine($"[{buchungsnummer}]Kontostand vor dem Einzahlen: {Kontostand}€");
                Console.WriteLine($"[{buchungsnummer}]Betrag zum Einzahlen: {wert}€");
                Kontostand += wert;
                Console.WriteLine($"[{buchungsnummer}]Kontostand nach dem Einzahlen: {Kontostand}€");
                buchungsnummer++;
            }
        }

        public void Abheben(decimal wert)
        {
            lock (lockObject)
            {
                Console.WriteLine($"[{buchungsnummer}]Kontostand vor dem Abheben: {Kontostand}€");
                Console.WriteLine($"[{buchungsnummer}]Betrag zum Abheben: {wert}€");
                Kontostand -= wert;
                Console.WriteLine($"[{buchungsnummer}]Kontostand nach dem Abheben: {Kontostand}€");
                buchungsnummer++;
            }
        }
    }
}
