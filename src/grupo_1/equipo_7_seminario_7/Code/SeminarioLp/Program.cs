using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminarioLp
{
    class Program
    {
        //si este metodo se pude utilizar para imprimir una lista generica de profesores
        //ya que aqui los profesores una clase mas especifica(tipo derivado) es tratada como Persona una clase mas generica (tipo base) por lo que se evidencia la 
        //contravarianza
        public static void PrintPeople(IEnumerable<Persona> people)
        {
            foreach (var item in people)
            {
                Console.WriteLine(item.Nombre);
            }
        }

        public static void PrintStudents(IEnumerable<Estudiante> estudiantes, IComparer<Estudiante> comparer)
        {
            foreach (var item in estudiantes.OrderBy(x => x, comparer))
            {
                Console.WriteLine(item.Nombre);
            }
        }

        //Hay que explicar que ase este metodo
        public void PrintByConsole(Action<Action<Persona>> persona)
        {
            persona(x => Console.WriteLine(x.GetType()));
        }

        //aqui se utiliza el metodo OfType para obtener del Ienumerable de personas otro Ienumerable filtrando por un tipo especifico 
        //en este caso de Estudiantes
        static void PrintStudentsOnly(IEnumerable<object> personas)
        {
            foreach (var item in personas.OfType<Estudiante>())
            {
                Console.WriteLine(item.Nombre);
            }
        }

        static void Main(string[] args)
        {
            Profesor a = new Profesor();
            
        }
    }
}
