using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelos_de_Clases
{
    public class Estudiante : Persona, IRecibirClases
    {
        public Estudiante(string nombre) : base(nombre)
        {

        }
        public void RecibirClases()
        {
            Console.WriteLine(Nombre + " recibiendo clases");
        }
    }
}