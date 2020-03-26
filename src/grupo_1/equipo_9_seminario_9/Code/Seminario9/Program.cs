using System;

namespace Seminario9 {
    interface IA {
        int A { get; set; }
    }

    interface IB {
        int B { get; set; }
    }

    class C : IA, IB {
        public int A { get; set; }
        public int B { get; set; }
    }

    static class Methods {
        public static void M1(this IA ia) {
            Console.WriteLine(ia.A);
        }

        public static void M2(this IB ib) {
            Console.WriteLine(ib.B);
        }
    }

    class Program {
        static void Main(string[] args) {
            var bt = new BinaryTree<int>(5);
            bt.Insert(4);
            bt.Insert(7);
            bt.Insert(1);
            foreach (var value in bt.PreOrder())
                Console.WriteLine(value);
            Console.WriteLine("Heigth = {0}", bt.Heigth());
        }
    }
}