using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_Demo
{
    class Dokument
    {
        public string Satz { get; set; }

        // Indexer automatisch erstellen mit:
        // indexer + TAB + TAB

        public string this[int index]
        {
            get 
            {
                return Satz.Split()[index];
            }
            set 
            {
                string[] teile = Satz.Split();
                teile[index] = value; // der neue Wert
                Satz = string.Join(" ", teile);
            }
        }
    }
}
