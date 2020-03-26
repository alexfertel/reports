using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yield
{
    public static class Utils
    {
        public static IEnumerable<int> Fibonacci()
        {
            int fibonacci = 0;
            int primer_fibonacci = 1;
            int segundo_fibonacci = 0;
            List<int> list_fibonacci = new List<int>();

            while (true)
            {
                fibonacci = primer_fibonacci + segundo_fibonacci;
                primer_fibonacci = segundo_fibonacci;
                segundo_fibonacci = fibonacci;
                list_fibonacci.Add(fibonacci);
            }
            return list_fibonacci;
        }

        public static IEnumerable<int> FibonacciLazy()
        {
            int fibonacci = 0;
            int primer_fibonacci = 1;
            int segundo_fibonacci = 0;

            while (true)
            {
                fibonacci = primer_fibonacci + segundo_fibonacci;
                primer_fibonacci = segundo_fibonacci;
                segundo_fibonacci = fibonacci;
                yield return fibonacci;
            }
        }

        public static void PrintEnumerable<T>(IEnumerable<T> e)
        {
            foreach (var item in e)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
        }
    }
}
