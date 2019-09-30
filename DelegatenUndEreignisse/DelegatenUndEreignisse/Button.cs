using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatenUndEreignisse
{
    class Button
    {
        public Action KlickLogik; // hier kann ich Speichern(); Abbrechen();

        public void MachDenKlick()
        {
            // ich will das hier was passiert, weiß aber nicht was
            // ich brauche die möglichkeit, dass mir wer anderer sagen kann, was ich hier machen soll

            if (KlickLogik != null) // Exception wenn "sich keiner dafür interessiert"
                KlickLogik.Invoke(); // die hinterlegte logik (meinbutton_click in der Klasse Program.cs)
        }
    }


    class Person
    {
        // Feld
        private decimal Kontostand; // private -> keiner darf von draussen drauf zugreifen

        // Property
        public string Name { get; set; }
    }
}