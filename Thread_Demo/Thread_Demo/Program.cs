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

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        static void MachEtwasInEinemThread()
        {
            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(10);
                Console.Write("*");
            }
        }
        static void MachEtwasInEinemThread2()
        {
            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(50);
                Console.Write("#");
            }
        }
    }
}
