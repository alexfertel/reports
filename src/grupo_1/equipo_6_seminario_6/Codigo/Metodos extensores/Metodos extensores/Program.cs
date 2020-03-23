using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodos_extensores
{
    public static class ExtendiendoA
    {
        public static void M(this A a)
        {
            Console.WriteLine("Soy M como metodo extensor de A");
        }
    }

    public class A
    {
        public void F()
        {
            Console.WriteLine("Soy F en A");
        }
    }

    public class B : A
    {
        public void M()
        {
            Console.WriteLine("Soy M en B");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            A a = new B();
            a.M();  // no compila sin hacer un metodo extensor
            
        }
    }
}
