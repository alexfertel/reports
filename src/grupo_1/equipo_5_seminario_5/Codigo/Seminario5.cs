using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario5
{
    class Program
    {
        static void Main(string[] args)
        {
            Action independent = () => { Console.WriteLine("HOLA"); };

            var actions = new Action[10];
            for (int x = 0; x < actions.Length; x++)
            {
                int y = x;
                actions[x] = () =>
                {
                    int z = x;
                    Console.WriteLine("{0}, {1}, {2}", x, y, z);
                };

            }

            foreach (var action in actions)
            {
                action();
            }

            var actions = new List<Action>();
            string[] urls = {
                "http://www.url.com",
                "http://www.someurl.com",
                "http://www.someotherurl.com",
                "http://www.yetanotherurl.com"
            };
            for (int i = 0; i < urls.Length; i++)
            {
                actions.Add(() => Console.WriteLine(urls[i]));
            }

            foreach (var action in actions)
            {
                action();
            }



            int test = 1;
            Action func = delegate { test++; };
            func();
            Console.WriteLine(test);








        }
    }
}
