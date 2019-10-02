using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Demo
{
    class SemaphoreZähler
    {
        public int Zähler = 0;
        private Semaphore semaphore = new Semaphore(3,3); // Maximal 3

        public void MachWas()
        {
            semaphore.WaitOne();
            //Zähler++;
            Interlocked.Increment(ref Zähler);
            Console.WriteLine(Zähler);
            //Zähler--;
            Interlocked.Decrement(ref Zähler);
            semaphore.Release();
        }
    }
}
