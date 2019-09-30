using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Problemstellung:
            //object[] data = new object[5];
            //data[0] = "12";
            //data[1] = "abcde";
            //data[2] = new StringBuilder();

            //int zahl1 = (int) data[0];

            // Eigene "Liste" erfinden

            ObjectStack os = new ObjectStack();

            os.Push(12);
            os.Push(44);
            os.Push("Hallo Welt");
            os.Push(12312312);

            os.Push(8765);

            Console.WriteLine(os.Pop());
            Console.WriteLine(os.Pop());
            Console.WriteLine(os.Pop());
            Console.WriteLine(os.Pop());
            Console.WriteLine(os.Pop());

            // Console.WriteLine(os.Pop()); // Exception wenn der Stack leer ist


            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
