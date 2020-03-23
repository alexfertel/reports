using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    class Program
    {
        public static bool IsPrime(int n)
        {
            if (n <= 1)
                return false;

            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }

            return true;
        }

        public static List<int> GetPrimes()
        {
            int i = 1;
            var primes = new List<int>();

            while (true)
            {
                if (IsPrime(i))
                    primes.Add(i);
                i++;
            }

            return primes;
        }

        public static IEnumerable<int> GetPrimesLazy()
        {
            int i = 1;

            while (true)
            {
                if (IsPrime(i))
                    yield return i;
                i++;
            }
        }

        static void Main(string[] args)
        {
            //var primes = GetPrimes().Where(p => p.ToString().StartsWith("2")).Take(10);
            //foreach (var prime in primes)
            //{
            //    Console.WriteLine(prime);
            //}

            var primes_lazy = GetPrimesLazy().Where(p => p.ToString().StartsWith("2")).Take(10);
            foreach (var prime in primes_lazy)
            {
                Console.WriteLine(prime);
            }
        }
    }
}
