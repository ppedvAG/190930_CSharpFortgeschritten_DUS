using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Serialisierung_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person
            {
                Vorname = "Tom",
                Nachname = "Ate",
                Alter = 10,
                Kontostand = 100
            };

            // Binär:
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream("Person.bin", FileMode.Create);
            formatter.Serialize(stream, p1);
            stream.Close();

            // Deserialisieren:
            stream = new FileStream("Person.bin", FileMode.Open);
            //object geladenePerson = formatter.Deserialize(stream);
            Person geladenePerson = (Person)formatter.Deserialize(stream);
            stream.Close();

            Console.WriteLine(geladenePerson.Vorname);
            Console.WriteLine(geladenePerson.Nachname);

            Console.WriteLine("---Anfang---");
            Console.ReadKey();
        }
    }
}
