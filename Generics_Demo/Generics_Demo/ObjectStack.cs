using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_Demo
{
    public class ObjectStack
    {
        public ObjectStack() : this(4) { } // .NET Framework ist 4 -> Default
        public ObjectStack(int capacity)
        {
            data = new object[capacity];
            index = 0;
        }

        private object[] data;
        private int index;


        public void Push(object item)
        {
            // Wenn voll: vergrößern:
            if(data.Length == index)
            {
                object[] newData = new object[data.Length * 2];
                Array.Copy(data, newData,data.Length);
                data = newData; // Das alte Array wird "irgendwann" vom GC eingesammelt
            }

            data[index] = item;
            index++;
        }

        public object Pop()
        {
            if (index == 0)
                throw new InvalidOperationException("Stack ist bereits leer");

            index--;
            return data[index];
        }


    }
}
