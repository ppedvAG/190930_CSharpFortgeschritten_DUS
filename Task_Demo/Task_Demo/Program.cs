using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Tasks erstellen
            //Task t1 = new Task(MachEtwas);
            //t1.Start();

            //Task<string> t2 = new Task<string>(BerechneEtwas);
            //t2.Start();

            //// Das Ergebnis von einem Task ausgeben:
            //Console.WriteLine(t2.Result); // wie Thread.Join();
            //// Wenn das Ergebnis noch nicht da ist, wird hier gewartet !!!! 
            #endregion

            #region Auf Tasks warten
            //Task t1 = new Task(MachWas1);
            //t1.Start();

            //Task t2 = Task.Factory.StartNew(MachWas2); // Startet sofort
            //Task t3 = Task.Run(MachWas3); // startet sofort


            ////t1.Wait();
            ////t2.Wait();
            ////t3.Wait();

            ////Task.WaitAll(t1, t2, t3);
            //Task.WaitAny(t1, t2, t3);

            //// Mit einem Task fortsetzen:

            //t2.ContinueWith(MachWas4); // Wenn Task2 fertig ist, geht ein neuer Task mit MachWas4 los  
            #endregion


            Console.WriteLine("---ANFANG---");
            Console.ReadKey();
        }

        public static void MachWas1()
        {
            for (int i = 0; i < 200; i++)
            {
                Thread.Sleep(30);
                Console.Write(1);
            }
        }
        public static void MachWas2()
        {
            for (int i = 0; i < 200; i++)
            {
                Thread.Sleep(60);
                Console.Write(2);
            }
        }
        public static void MachWas3()
        {
            for (int i = 0; i < 200; i++)
            {
                Thread.Sleep(90);
                Console.Write(3);
            }
        }

        public static void MachWas4(Task alterTask)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write(4);
            }
        }

        public static string BerechneEtwas()
        {
            Thread.Sleep(5000);
            return "Hello World";
        }

        public static void MachEtwas()
        {
            for (int i = 0; i < 100; i++)
            {
                // Entweder: --- Variante alt
                Thread.Sleep(100); 

                // Oder:
                // Task.Delay(100);
                Console.Write("#");
            }
        }
    }
}
