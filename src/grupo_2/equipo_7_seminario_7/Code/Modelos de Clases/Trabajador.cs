using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelos_de_Clases
{
    public class Trabajador : Persona, ICobrarSalario
    {
        public Trabajador(string nombre): base(nombre)
        {

        }

        public void CobrarSalario()
        {
            Console.WriteLine(Nombre + " cobro salario");
        }
    }
}