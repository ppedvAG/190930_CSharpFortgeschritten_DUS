using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatenUndEreignisse
{
    class Button
    {
        // Variante "Lang"

        //private Action klickLogik; // hier kann ich Speichern(); Abbrechen();
        //public event Action KlickLogik
        //{
        //    add
        //    {
        //        klickLogik += value;
        //    }
        //    remove
        //    {
        //        klickLogik -= value;
        //    }
        //}

        // Variante "Kurz"
        public event Action KlickLogik;
        // Der Compiler macht aus der Variante "Kurz" die lange Variante

        public event EventHandler Click;

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
        private string name;
        public string Name 
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public byte Alter { get; private set; }



    }
}