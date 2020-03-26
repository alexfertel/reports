using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cortocircuito
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Yenli", "Yunior", "Jotica", "Carlos", "Ariel" };

            if (names[0] == "Yenli" || names[5] == "Jotica")
                Console.WriteLine("TRUE");
            else
                Console.WriteLine("FALSE");

            if (names[0] == "Yenli" | names[5] == "Jotica")
                Console.WriteLine("TRUE");
            else
                Console.WriteLine("FALSE");
        }
    }
}
