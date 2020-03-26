using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminarioLp
{
    public class Persona
    {
        private string nombre;
        public string Nombre { get => nombre; set => nombre = value; }

        public Persona(string _nombre)
        {
            nombre = _nombre;
        }
        public Persona() { }
    }
}
