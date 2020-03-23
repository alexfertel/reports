using System;

namespace CSharp.DynamicReflectionDSL
{
    class Tests
    {
        public static void Run()
        {
            Console.WriteLine("Testing direct access:");
            TestDirectAccess();
            Console.WriteLine("----------------------");

            Console.WriteLine("Testing dictionary like access:");
            TestDictionaryAccess();
            Console.WriteLine("----------------------");

            Console.WriteLine("Testing JSON syntax:");
            TestJsonSyntax();
            Console.WriteLine("----------------------");

            Console.WriteLine("Testing Fluent Api:");
            TestFluent();
            Console.WriteLine("----------------------");

            Console.WriteLine("Testing any type in execution:");
            TestAnyType();
            Console.WriteLine("----------------------");
        }

        public static void TestDirectAccess()
        {
            var person = Factory.New.Person;

            person.FirstName = "Louis";
            person.LastName = "Dejardin";

            Console.WriteLine(person);
        }

        public static void TestDictionaryAccess()
        {
            var person = Factory.New.Person;

            person["FirstName"] = "Louis";
            person["LastName"] = "Dejardin";

            Console.WriteLine(person);
        }

        public static void TestJsonSyntax()
        {
            var person = Factory.New.Person(
                FirstName: "Louis",
                LastName: "Dejardin",
                Manager: Factory.New.Person(
                    FirstName: "Bertrand",
                    LastName: "Le Roy"
                )
            );

            Console.WriteLine(person);
        }


        public static void TestFluent()
        {
            var person = Factory.New.Person
            .FirstName("Louis")
            .LastName("Dejardin");

            Console.WriteLine(person);
        }

        public static void TestAnyType()
        {
            var animal = Factory.New.Animal;
            Console.WriteLine(animal);
        }
    }
}