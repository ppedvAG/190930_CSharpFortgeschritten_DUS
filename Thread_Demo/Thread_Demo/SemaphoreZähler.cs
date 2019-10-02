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
        public int Zähler { get; set; }
        private Semaphore semaphore = new Semaphore(3,3); // Maximal 3

        public void MachWas()
        {
            semaphore.WaitOne();
            Zähler++;
            Console.WriteLine(Zähler);
            Zähler--;
            semaphore.Release();
        }
    }
}
