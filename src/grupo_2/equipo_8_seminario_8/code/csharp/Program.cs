using System;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLineBlue("Running Basic DSL tests:");
            Console.WriteLine();
            BasicDSL.Tests.Run();
            Console.WriteLine();

            WriteLineBlue("Running Dynamic DSL tests:");
            Console.WriteLine();
            DynamicDSL.Tests.Run();
            Console.WriteLine();

            WriteLineBlue("Running Dynamic and Reflection DSL tests:");
            Console.WriteLine();
            DynamicReflectionDSL.Tests.Run();
            Console.WriteLine();
        }

        static void WriteLineWithColor(object obj, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(obj);
            Console.ResetColor();
        }

        static void WriteLineBlue(object obj)
        {
            WriteLineWithColor(obj, ConsoleColor.Blue);
        }
    }
}
