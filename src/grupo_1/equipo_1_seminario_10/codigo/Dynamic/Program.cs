using System;
using System.Collections.Generic;

namespace Dynamic
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            dynamic parte1 = new Prototype();
            parte1.MetodoA = (Action<dynamic>) ((self) => { Console.WriteLine("MétodoA dice '{0}'", self.frase); });
            
            dynamic parte2 = new Prototype();
            parte2.MetodoB = (Action<dynamic>) ((self) => { Console.WriteLine("MétodoB dice '{0}'", self.frase); });
                    
            var obj = parte1.BlendWith(parte2);
     
            obj.frase = "Hello World!";
            obj.MetodoA();
            obj.MetodoB();

            var obj2 = obj.Clone();
            obj2.MetodoA();
            obj2.MetodoB();

            Console.WriteLine(obj.MetodoA == obj2.MetodoA);
            Console.WriteLine(obj.MetodoB == obj2.MetodoB);

            var dynamics = new List<dynamic> {1, "Hola"};
            Console.WriteLine(dynamics[0] == 1);
            Console.WriteLine(dynamics[1].ToLower());
        }
    }
}