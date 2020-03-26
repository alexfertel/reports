using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haskell
{
    class Program
    {
        static void Main(string[] args)
        {
            // Four :: Integer -> Integer
            // Four x = 4
            Func<Func<int>, int> Four = (function) => 4;

            // Infinity :: Integer
            // Infinity = 1 + Infinity
            Func<int> Infinity = null;
            Infinity = () => Infinity() + 1;

            // Stack Overflow Exception
            //Console.WriteLine(Infinity());
            Console.WriteLine(Four(Infinity));
        }
    }
}
