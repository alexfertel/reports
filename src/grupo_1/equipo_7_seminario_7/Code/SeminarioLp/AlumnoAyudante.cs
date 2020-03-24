using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminarioLp
{
    class AlumnoAyudante : Estudiante, IimpartidorClases, IcobradorSalario
    {
        public AlumnoAyudante(string nombre) : base(nombre) { }
        public AlumnoAyudante() { }
        public void CobrarSalario()
        {
            throw new NotImplementedException();
        }

        public void ImpartirClases()
        {
            throw new NotImplementedException();
        }
    }
}
