using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos_de_Clases;

namespace Seminario_1_LP_Equipo_7
{
    class Program
    {
        

        static void Main(string[] args)
        {
            
            List<string> nombres = new List<string> { "Rosa", "Jose", "Pedro", "Marta", "Antonio"  };

            List<Persona> list_personas = new List<Persona> { new Trabajador("Pepe"),
                new Persona("Maria"), new Estudiante("Pedro"), new Profesor("Josefina"),
                new Estudiante("Gabriela"), new AlumnoAyudante("Luis")};

            //inciso b
            Console.WriteLine("Inciso b");
            List<Profesor> list_profesores = new List<Profesor>();
            for (int i = 0; i < nombres.Count; i++)
            {
                list_profesores.Add(new Profesor("Profesor " + nombres[i]));
            }
            
            List<Estudiante> list_estudiantes = new List<Estudiante>();

            Inciso_b.PrintPeople_For(list_profesores);
            Console.WriteLine("\n");

            //inciso c
            Console.WriteLine("Inciso c");
            for (int i = 0; i < nombres.Count; i++)
            {
                list_estudiantes.Add(new Estudiante("Estudiante " + nombres[i]));
            }
            IComparer<Persona> comp_personas = new Comparador();
            Inciso_c.PrintStudents(list_estudiantes, comp_personas);
            Console.WriteLine('\n');
            Inciso_c.PrintPersonas(list_personas, comp_personas);
            Console.WriteLine("\n");

            
            //inciso d
            Console.WriteLine("Inciso d");

            Action<Action<Estudiante>> aaf = Meta;
            Action<Estudiante> af = DoSomething;


            Inciso_d.PrintByConsole(aaf);
            Inciso_d.PrintByConsole(x => x(new Estudiante("Pedro")));
            //Inciso_d.PrintByConsole(x => x(new Estudiante("Pedro")));


            Console.WriteLine('\n');

            //inciso e
            Console.WriteLine("Inciso e");
            foreach (var item in list_personas)
            {
                Console.WriteLine(item.GetType().Name + " " + item.Nombre);
            }

            Console.WriteLine('\n');

            Inciso_e.PrintStudentsOnly(list_personas);
        }

        static void Meta(Action<Estudiante> action)
        {
            action(new Estudiante("Pedro"));
        }

        static void DoSomething(Estudiante estudiante)
        {
            Console.WriteLine(estudiante.Nombre);
        }
    }

    
    public static class Inciso_b
    {
        public static void PrintPeople_Foreach(IEnumerable<Persona> people)
        {
            foreach (var p in people)
            {
                Console.WriteLine(p.Nombre);
            }
        }
        public static void PrintPeople_For(IEnumerable<Persona> people)
        {
            for (int i = 0; i < people.Count(); i++)
            {
                Console.WriteLine(people.ElementAt(i).Nombre);
            }
        }
    }

    
    public static class Inciso_c
    {
        public static void PrintStudents(IEnumerable<Estudiante> students, IComparer<Estudiante> comparer)
        {
            foreach (var student in students.OrderBy(x => x, comparer))
                Console.WriteLine(student.Nombre);
        }

        public static void PrintPersonas(IEnumerable<Persona> people, IComparer<Persona> comparer)
        {
            foreach (var person in people.OrderBy(x => x, comparer))
                Console.WriteLine(person.Nombre);
        }
    }

    public class Comparador : IComparer<Persona>
    {
        public int Compare(Persona x, Persona y)
        {
            return x.Nombre.CompareTo(y.Nombre);
        }
    }
    public static class Inciso_d
    {
        public static void PrintByConsole(Action<Action<Persona>> person)
        {
            person(x => Console.WriteLine(x.Nombre));
        }
    }
    public static class Inciso_e
    {
        public static void PrintStudentsOnly(IEnumerable<Persona> people)
        {
            foreach (var student in people.OfType<Estudiante>())
                Console.WriteLine(student.Nombre);
        }
    }
}
