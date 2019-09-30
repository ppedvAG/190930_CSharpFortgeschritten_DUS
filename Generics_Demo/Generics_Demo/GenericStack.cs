using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_Demo
{
    public class GenericStack<T>
    {
        public GenericStack() : this(4) { } // .NET Framework ist 4 -> Default
        public GenericStack(int capacity)
        {
            data = new T[capacity];
            index = 0;
        }

        private T[] data;
        private int index;


        public void Push(T item)
        {
            // Wenn voll: vergrößern:
            if (data.Length == index)
            {
                T[] newData = new T[data.Length * 2];
                Array.Copy(data, newData, data.Length);
                data = newData; // Das alte Array wird "irgendwann" vom GC eingesammelt
            }

            data[index] = item;
            index++;
        }

        public T Pop()
        {
            if (index == 0)
                throw new InvalidOperationException("Stack ist bereits leer");

            index--;
            return data[index];
        }
    }
}
