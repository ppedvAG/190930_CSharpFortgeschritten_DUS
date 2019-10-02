using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_Demo
{
    class Program
    {
        static CancellationTokenSource cts = new CancellationTokenSource();
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

            #region Tasks beenden/abbrechen
            //Task t1 = Task.Run(SehrLangeAufgabe);

            //// nach 5 sek möchte ich abbrechen:
            //Thread.Sleep(5000);

            //cts.Cancel(); // ich möchte canceln :) 
            #endregion

            #region Exceptions im Task
            //try
            //{
            //    Task t1 = Task.Run(Fehler1);
            //    Task t2 = Task.Run(Fehler2);
            //    Task t3 = Task.Run(Fehler3);

            //    // lösung: Warten oder Result abfragen
            //    Task.WaitAll(t1, t2, t3);
            //}
            //catch (AggregateException ex) // AggregateException ist der Standard-Task Fehler
            //{
            //    Console.WriteLine(ex.Message);
            //    Console.WriteLine("Und zwar:");
            //    foreach (var item in ex.InnerExceptions)
            //    {
            //        switch (item)
            //        {
            //            case DivideByZeroException e1:
            //                Console.WriteLine("Dividier nicht durch null, du depp !");
            //                break;
            //            case FormatException e2:
            //                Console.WriteLine("Gib was ordentliches ein, du depp !");
            //                break;
            //            //case StackOverflowException e2:
            //            //    Console.WriteLine("Wie hast du das überhaupt geschafft?, du depp !");
            //            //    break;
            //            default:
            //                Console.WriteLine("Fehler kenne ich nicht mal, was könnte es sein ... ....");
            //                Console.WriteLine(item.Message);
            //                Console.WriteLine(item.StackTrace);
            //                Console.WriteLine(item.Source);
            //                break;
            //        }
            //    }
            //} 
            #endregion

            // normale For-Schleife:
            Stopwatch watch = new Stopwatch();

            double[] erg = new double[10_000_000];

            watch.Start();
            for (int i = 0; i < 10_000_000; i++)
            {
                // irgendeine berechnung die lange dauert ...
                erg[i] = Math.Log10(Math.Pow((Math.Sqrt(i) * Math.Cos(i * 2) +  Math.PI), i) * Math.Sqrt(Math.PI * Math.Acos(i)) / Math.Exp(i)); // Irgendeine Berechnung damit der Prozessor was zum Arbeiten hat ;)
            }
            watch.Stop();

            Console.WriteLine($"For-Schleife normal: {watch.ElapsedMilliseconds}ms");

            // Parallel.For

            double[] erg2 = new double[10_000_000];

            watch.Restart();
            Parallel.For(0, 10_000_000, i =>
            //Parallel.For(0, 10_000_000,new ParallelOptions { MaxDegreeOfParallelism = 2 }, i =>
            {
                 erg2[i] = Math.Log10(Math.Pow((Math.Sqrt(i) * Math.Cos(i * 2) + Math.PI), i) * Math.Sqrt(Math.PI * Math.Acos(i)) / Math.Exp(i)); // Irgendeine Berechnung damit der Prozessor was zum Arbeiten hat ;)
            });
            watch.Stop();

            Console.WriteLine($"Parallel.For: {watch.ElapsedMilliseconds}ms");

            // --------------------------

            //Parallel.ForEach(erg2, item =>
            //{
            //    Console.WriteLine(item);
            //});

            Console.WriteLine("---ANFANG---");
            Console.ReadKey();
        }

        public static void Fehler1()
        {
            Thread.Sleep(2000);
            int zero = 0;
            int demo = 5 / zero;
        }
        public static void Fehler2()
        {
            Thread.Sleep(5000);
            throw new StackOverflowException();
        }
        public static void Fehler3()
        {
            Thread.Sleep(8000);
            throw new FormatException();
        }

        public static void SehrLangeAufgabe()
        {
            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(50);
                if (cts.IsCancellationRequested) // Wenn Main() sagt, dass wir canceln solln
                    break; // schleife beenden

                Console.Write("#");
            }
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
