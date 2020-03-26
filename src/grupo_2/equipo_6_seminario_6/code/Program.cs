using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario6_Lp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student("Amalia", 312),
                new Student("Gabriela",312),
                new Student("Sandra",311),
                new Student("Paula",311)
            };

            var groups = students.MyGroupBy(e => e.Group);

            foreach (var group in groups)
            {
                Console.WriteLine($"Estudiantes del grupo {group.Key}:");
                foreach (var student in group)
                {
                    Console.WriteLine(student.Name);
                }
            }
            //Output
            //Esudiantes del grupo 312:
            //Amalia
            //Gabriela
            //Esudiantes del grupo 311:
            //Sandra
            //Paula

            var keywords = new CSharpBuiltInTypes();
            foreach (string keyword in keywords)
            {
                Console.WriteLine(keyword);
            }
            //El código anterior retorna la siguiente sequencia:

            //object
            //byte
            //uint
            //ulong
            //float
            //char
            //bool
            //ushort
            //decimal
            //int
            //sbyte
            //short
            //long
            //void
            //double
            //string
        }
    }
}
