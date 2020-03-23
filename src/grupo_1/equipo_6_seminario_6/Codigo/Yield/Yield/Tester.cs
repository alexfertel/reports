using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yield
{
    class Tester
    {
        public static void Fibonacci()
        {
            // fibonacci sin yield, nunca termina
            //IEnumerable<int> fib = Utils.Fibonacci();

            // fibonacci con yield
            IEnumerable<int> fib_lazy = Utils.FibonacciLazy();
            Utils.PrintEnumerable(fib_lazy.Take(5));

            // fibonacci simulando yield, maquinaria move next
            FibonacciSimulandoYield fib = new FibonacciSimulandoYield();
            Utils.PrintEnumerable(fib.Take(8));
        }

        static void Main(string[] args)
        {
            Fibonacci();
        }
    }
}
