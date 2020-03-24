using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminarioLp
{
    public class Profesor : Trabajador, IimpartidorClases
    {

        public Profesor(string nombre) : base(nombre)
        { }
        public Profesor() { }

        public void ImpartirClases()
        {
            throw new NotImplementedException();
        }
    }
}
