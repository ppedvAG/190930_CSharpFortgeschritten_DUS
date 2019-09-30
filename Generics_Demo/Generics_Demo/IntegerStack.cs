using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_Demo
{
    public class IntegerStack
    {
        public IntegerStack() : this(4) { } // .NET Framework ist 4 -> Default
        public IntegerStack(int capacity)
        {
            data = new int[capacity];
            index = 0;
        }

        private int[] data;
        private int index;


        public void Push(int item)
        {
            // Wenn voll: vergrößern:
            if (data.Length == index)
            {
                int[] newData = new int[data.Length * 2];
                Array.Copy(data, newData, data.Length);
                data = newData; // Das alte Array wird "irgendwann" vom GC eingesammelt
            }

            data[index] = item;
            index++;
        }

        public int Pop()
        {
            if (index == 0)
                throw new InvalidOperationException("Stack ist bereits leer");

            index--;
            return data[index];
        }
    }
}
