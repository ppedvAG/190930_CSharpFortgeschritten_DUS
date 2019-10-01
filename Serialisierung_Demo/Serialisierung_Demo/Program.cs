using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialisierung_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Person p1 = new Person
            //{
            //    Vorname = "Tom",
            //    Nachname = "Ate",
            //    Alter = 10,
            //    Kontostand = 100
            //};

            List<Person> personen = new List<Person>
            {
                new Person{Vorname="Tom",Nachname="Ate",Alter=10,Kontostand=100},
                new Person{Vorname="Anna",Nachname="Nass",Alter=20,Kontostand=200},
                new Person{Vorname="Peter",Nachname="Silie",Alter=30,Kontostand=300},
                new Person{Vorname="Franz",Nachname="Ose",Alter=40,Kontostand=400},
                new Person{Vorname="Martha",Nachname="Pfahl",Alter=50,Kontostand=-500},
            };


            #region Binär
            //BinaryFormatter formatter = new BinaryFormatter();
            //FileStream stream = new FileStream("Person.bin", FileMode.Create);
            //formatter.Serialize(stream, p1);
            //stream.Close();

            //// Deserialisieren:
            //stream = new FileStream("Person.bin", FileMode.Open);
            ////object geladenePerson = formatter.Deserialize(stream);
            //Person geladenePerson = (Person)formatter.Deserialize(stream);
            //stream.Close();

            //Console.WriteLine(geladenePerson.Vorname);
            //Console.WriteLine(geladenePerson.Nachname); 
            #endregion

            #region XML
            //// Limitierungen: Klasse muss Public sein, unterstützte Member ebenfalls !

            //XmlSerializer formatter = new XmlSerializer(typeof(Person));
            //FileStream stream = new FileStream("Person.xml", FileMode.Create);
            //formatter.Serialize(stream, p1);
            //stream.Close();

            //// Deserialisieren
            //stream = new FileStream("Person.xml", FileMode.Open);
            //Person geladenePerson = (Person)formatter.Deserialize(stream);
            //stream.Close();

            //Console.WriteLine(geladenePerson.Vorname);
            //Console.WriteLine(geladenePerson.Nachname); 
            #endregion

            // JSON
            // -> NuGet: Newtonsoft.JSON

            string json = JsonConvert.SerializeObject(personen);

            Console.WriteLine(json);

            // Deserialisieren:
            Person[] geladenePerson = JsonConvert.DeserializeObject<Person[]>(json);

            Console.WriteLine(geladenePerson[0].Vorname);
            Console.WriteLine(geladenePerson[0].Nachname);

            Console.WriteLine("---Anfang---");
            Console.ReadKey();
        }
    }
}
