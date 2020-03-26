using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminarioLp
{
    public class CompararPorNombre : IComparer<Persona>
    {
        public int Compare(Persona x, Persona y)
        {
            return x.Nombre.CompareTo(y.Nombre);
        }
    }
}
