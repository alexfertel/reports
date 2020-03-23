using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelos_de_Clases
{
    public class Persona
    {
        public Persona(string nombre)
        {
            Nombre = nombre;
        }
        public string Nombre { get; set; }
    }
}