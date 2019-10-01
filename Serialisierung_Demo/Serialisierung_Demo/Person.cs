using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialisierung_Demo
{
    // [Serializable] // Benötigt für BinaryFormatter !
    public class Person
    {
        [XmlAttribute]
        public string Vorname { get; set; }
        [XmlAttribute]
        public string Nachname { get; set; }
        public byte Alter { get; set; }
        public decimal Kontostand { get; set; }
    }
}
