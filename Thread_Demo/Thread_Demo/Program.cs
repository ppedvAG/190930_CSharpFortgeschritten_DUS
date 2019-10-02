using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Grundlagen Threads
            //// Action a = new Action(MachEtwasInEinemThread);
            //// Action b = MachEtwasInEinemThread; 


            //Thread t1 = new Thread(MachEtwasInEinemThread);
            ////  Thread t1 = new Thread(new ParameterizedThreadStart(MachEtwasInEinemThread));

            //Thread t2 = new Thread(MachEtwasInEinemThread2);

            //t1.Start();
            //t2.Start();

            ////Thread.Sleep(5000);
            //// Nach 5 sek: Thread beenden
            ////t1.Abort();
            ////t2.Abort();

            //// Auf einen Thread warten:
            //t1.Join();
            //t2.Join();
            #endregion

            #region Threadpool und Einstellungen
            //ThreadPool.QueueUserWorkItem(MachEtwasInEinemThread,12);
            //ThreadPool.QueueUserWorkItem(MachEtwasInEinemThread2,99);

            //// Einstellmöglichkeiten für Threads
            //Thread t1 = new Thread(MachEtwasInEinemThread);
            //t1.IsBackground = true;
            //t1.Priority = ThreadPriority.Normal;

            //t1.Start(42); 
            #endregion

            #region Monitor
            //Console.OutputEncoding = Encoding.Unicode;

            //Konto meinKonto = new Konto();

            //for (int i = 0; i < 100; i++)
            //{
            //    ThreadPool.QueueUserWorkItem(ZufälligesKontoupdate, meinKonto);
            //} 
            #endregion

            #region Mutex
            //Mutex mutex = new Mutex(false, "MeinMutex");

            //for (int i = 0; i < 100; i++)
            //{
            //    mutex.WaitOne();
            //    // hier darf wieder nur einer rein
            //    Thread.Sleep(100);
            //    Console.WriteLine(i);

            //    mutex.ReleaseMutex();
            //} 
            #endregion

            #region Mit Mutex verhindern, dass die App mehrfach geöffnet wird
            //Mutex mutex = new Mutex(false, "MeinMutex");

            //var offen = mutex.WaitOne(100,false);

            //if(offen)
            //{
            //    // logik
            //    for (int i = 0; i < 1000; i++)
            //    {
            //        Console.Write("#");
            //        Thread.Sleep(100);
            //    }
            //}
            //else
            //{
            //    // beenden
            //    Console.WriteLine("Applikation ist bereits offen, beendet sich selbst in 5 sec");
            //    Thread.Sleep(5000);
            //    return;
            //}
            //mutex.ReleaseMutex(); 
            #endregion

            #region Semaphore
            //SemaphoreZähler sz = new SemaphoreZähler();

            //for (int i = 0; i < 500; i++)
            //{
            //    Thread t1 = new Thread(sz.MachWas);
            //    t1.Start();
            //} 
            #endregion

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        public static void ZufälligesKontoupdate(object state) // <-- für Threadpool
        {
            Konto meinKonto = (Konto)state;
            Random generator = new Random();
            for (int i = 0; i < 10; i++)
            {
                int betrag = generator.Next(1, 100);
                if (generator.Next(0, 2) % 2 == 0) // gerade zahl
                    meinKonto.Einzahlen(betrag);
                else
                    meinKonto.Abheben(betrag);
            }
        }


        static void MachEtwasInEinemThread(object state)
        {
            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(10);
                Console.Write("*");
            }
        }
        static void MachEtwasInEinemThread2(object state)
        {
            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(50);
                Console.Write("#");
            }
        }
    }
}
