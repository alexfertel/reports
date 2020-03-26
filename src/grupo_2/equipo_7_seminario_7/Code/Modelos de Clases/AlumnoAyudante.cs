using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelos_de_Clases
{
    public class AlumnoAyudante : Estudiante, IImpartirClases
    {
        public AlumnoAyudante(string nombre): base(nombre)
        {

        }
        public void ImpartirClases()
        {
            Console.WriteLine(Nombre + " impartiendo clases");
        }
    }
}