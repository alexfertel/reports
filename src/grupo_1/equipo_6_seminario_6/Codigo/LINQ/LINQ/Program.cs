using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class Student
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public int Group { get; private set; }
        public int Age { get; private set; }

        public Student(string name, string last_name, int group, int age)
        {
            Name = name;
            LastName = last_name;
            Group = group;
            Age = age;
        }

        public override string ToString()
        {
            return "Mi nombre es " + Name + " " + LastName + ", soy del grupo C-" + Group + " y tengo " + Age + " años.";
        }
    }

    public delegate double Matematica(double valor);

    class Program
    {
        static void Main(string[] args)
        {
            Student[] equipo6 =
            {
                new Student("Yenli", "Gil", 412, 22),
                new Student("Yunior", "Tejeda", 412, 24),
                new Student("Jotica", "Lopez", 311, 22),
                new Student("Carlos", "Martinez", 411, 23),
                new Student("Ariel", "Plasencia", 311, 23)
            };

            var consulta1 = from est in equipo6
                            orderby est.Age descending
                            select new { Nombre = est.Name,Edad = est.Age };
            equipo6.OrderByDescending(est => est.Age).Select(est => new { Nombre = est.Name, Edad = est.Age }).ToList().ForEach(est => Console.WriteLine("{0} {1}", est.Nombre, est.Edad));

            foreach (var e in consulta1)
            {
                Console.WriteLine("{0} {1}", e.Nombre, e.Edad);
            }
            Console.WriteLine();

            var consulta2 = from est in equipo6
                            group est by est.Age into groups
                            orderby groups.Key ascending
                            select groups;
            var q = equipo6.GroupBy(est => est.Age).OrderBy(est => est.Key).Select(est => est);
            foreach (var group in q)
            {
                Console.WriteLine("Con {0} años", group.Key.ToString());
                foreach (var est in group)
                    Console.WriteLine("  " + est.Name);
            }
            foreach (var group in consulta2)
            {
                Console.WriteLine("Con {0} años", group.Key.ToString());
                foreach (var est in group)
                    Console.WriteLine("  " + est.Name);
            }
            Console.WriteLine();

            var jovenes1 = from estudiante in equipo6
                           where estudiante.Age < 30
                           select estudiante;
            foreach (var item in jovenes1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var jovenes2 = equipo6.Where(e => e.Age < 30);
            foreach (var item in jovenes2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            string[] words = { "hello", "wonderful", "linq", "beautiful", "world" };
            var grupos = from word in words
                         orderby word ascending
                         group word by word.Length into lengthGroups
                         orderby lengthGroups.Key descending
                         select new { Length = lengthGroups.Key, Words = lengthGroups };
            foreach (var item in grupos)
            {
                Console.WriteLine("Palabras de longitud " + item.Length);
                foreach (var item1 in item.Words)
                {
                    Console.WriteLine("    " + item1);
                }
            }
            Console.WriteLine();

            int[] num = { 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            num.OrderBy(i => i).Where(i => i % 2 == 0).OrderByDescending(i => i % 3 == 0).ToList().ForEach((i) => Console.WriteLine(i));
            Console.WriteLine();

            Matematica Cuadrado = delegate (double valor) { return Math.Pow(valor, 2); };
            Matematica Raiz = delegate (double valor) { return Math.Sqrt(valor); };

            double a = Cuadrado(9);
            double b = Raiz(9);

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(a == b);
            Console.WriteLine();

            double c = Cuadrado(1);
            double d = Raiz(1);
            Console.WriteLine(c);
            Console.WriteLine(d);
            Console.WriteLine(c == d);
        }
    }
}
