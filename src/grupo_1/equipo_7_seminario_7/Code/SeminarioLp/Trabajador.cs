using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminarioLp
{
    public class Trabajador : Persona, IcobradorSalario
    {
        public Trabajador(string nombre) : base(nombre) { }
        public Trabajador() { }
        public void CobrarSalario()
        {
            throw new NotImplementedException();
        }
    }
}
