using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrumpTaschenrechner
{
    [Export(typeof(IRechenart))]
    public class TrumpRechner : IRechenart
    {
        public int Berechne(int z1, int z2)
        {
            return z1 + z2 + 100;
        }
    }
}
