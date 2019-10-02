using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operatorüberladung
{
    class Bruch
    {
        public Bruch(int zähler, int nenner)
        {
            Zähler = zähler;
            Nenner = nenner;
        }

        public int Zähler { get; set; }
        public int Nenner { get; set; }


        // Operatorüberladung:
        // Arithm:
        // +,-,*,/,%
        // Binär:
        // &,|,^,<<,>>
        // Vergleichs:
        // ==, !=, <,>,<=,>=
        // ----> Paarweise (wenn ==, dann muss auch !=)

        // Cast (implizit)
        public static Bruch operator *(Bruch left, Bruch right)
        {
            return new Bruch(left.Zähler * right.Zähler, left.Nenner * right.Nenner);
        }
        public static Bruch operator *(Bruch left,int right)
        {
            return new Bruch(left.Zähler * right, left.Nenner);
        }

        public static bool operator ==(Bruch left, Bruch right)
        {
            return true;
        }
        public static bool operator !=(Bruch left, Bruch right)
        {
            return false;
        }
    }
}
