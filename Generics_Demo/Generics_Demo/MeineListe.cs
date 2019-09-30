using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_Demo
{
    class MeineListe<T> where T : struct
    {
        public MeineListe()
        {
            data = new T[4];
        }
        private T[] data;
        private int index = 0;

        public void Add(T item)
        {
            if (data.Length == index)
            {
                T[] newData = new T[data.Length * 2];
                Array.Copy(data, newData, data.Length);
                data = newData; // Das alte Array wird "irgendwann" vom GC eingesammelt
            }

            data[index] = item;
            index++;
        }

        public T this[int index]
        {
            get 
            {
                return data[index]; // 1:1 auslesen
            }
            set // demo[1] = 99; // ===> 99 steht in "value" drinnen 
            {
                data[index] = value; // 1:1 speichern
            }
        }

    }
}
