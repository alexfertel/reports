using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelos_de_Clases
{
    public class Profesor : Trabajador, IImpartirClases
    {
        public Profesor(string nombre): base(nombre)
        {

        }
        public void ImpartirClases()
        {
            Console.WriteLine(Nombre + " impartiendo clases");
        }
    }
}