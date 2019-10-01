using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEF_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1) Container erstellen

            Container meinRechencontainer = new Container();

            // 2) Catalog -> Angabe, "von wo MEF sich die Daten holen soll"
            DirectoryCatalog catalog = new DirectoryCatalog("."); // im selben Ordner
            CompositionContainer mef = new CompositionContainer(catalog);

            mef.ComposeParts(meinRechencontainer); // MEF baut sich das nun zusammen

            if(meinRechencontainer.MeineRechenart.Length > 1) // Wenn ich mehr als 1 Möglihckeit finde -> User fragen
            {
                Console.WriteLine("Welche DLL wollen Sie verwenden?");
                int index = 0;
                foreach (var item in meinRechencontainer.MeineRechenart)
                {
                    Console.WriteLine($"{index}: {item.GetType()}");
                    index++;
                }
                string eingabe = Console.ReadLine();
                int gewählteDLL = Convert.ToInt32(eingabe);
                Console.WriteLine(meinRechencontainer.MeineRechenart[gewählteDLL].Berechne(2, 2));

            }
            else
                Console.WriteLine(meinRechencontainer.MeineRechenart[0].Berechne(2,2));

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }

    class Container
    {
        [ImportMany(typeof(IRechenart))]
        public IRechenart[] MeineRechenart { get; set; }
    }

}
