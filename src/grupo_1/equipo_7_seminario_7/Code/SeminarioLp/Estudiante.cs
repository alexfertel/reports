using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminarioLp
{
    public class Estudiante : Persona, IrecibidorClases
    {
        public Estudiante(string nombre) : base(nombre)
        {
        }
        public Estudiante() { }

        public void RecibirClases()
        {
        }
    }
}
