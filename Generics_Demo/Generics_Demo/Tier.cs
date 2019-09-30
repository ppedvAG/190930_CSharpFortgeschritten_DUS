using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_Demo
{
    class Tier
    {
        public string Name { get; set; }
        public int Alter { get; set; }
    }

    class Hund : Tier
    {
        public string Rasse { get; set; }
    }
}
