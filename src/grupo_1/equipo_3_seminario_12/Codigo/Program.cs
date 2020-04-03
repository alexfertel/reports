using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Code__Seminario_12_
{
    class Program
    {
        static void Main(string[] args)
        {
           
           

        }

        #region 1.B 1.C

        public class Person 
        {
            public Person(string name, int age) 
            {
                Name = name ?? throw new ArgumentException();
                Age = age;
            }

            public string Name { get; }
            public int Age { get; set; }
            public Pet Pet { get; set; }

            public override string ToString() => $"Name: {Name}, Age: {Age} years old";
            public void SayHi() => Console.WriteLine($"Hi, my name is {Name}");

        }

        public class Pet 
        {
            public Pet(string name, string specie) 
            {
                Name = name;
                Specie = specie;

            }
            public string Name { get; }
            public string Specie { get; }

            public override string ToString() => $"Hello my name is {Name} and i'm a {Specie}";
       
        }

        public class Location
        {
            private string locationName;
            public Location(string name) => locationName = name;

            public string Name => locationName;

            //code for previous versions of c#
           
        }

        public static void Run1BC()
        {
            var numbers = new Dictionary<int, string>
            {
                [7] = "seven",
                [9] = "nine",
                [13] = "thirteen"
            };

            var moreNumbers = new Dictionary<int, string>
            {
                {19, "nineteen" },
                {23, "twenty-three" },
                {42, "forty-two" }
            };


            Person[] persons = new Person[] {
                null,
                new Person("Alberto", 21),
                new Person("Carlos", 21) { Pet = new Pet("Floppy", "dog") },
            };

            Console.WriteLine(persons.Any(p => p?.Pet?.Specie == "dog")); //prints true
            Console.WriteLine(persons.Any(p => p != null && p.Pet != null && p.Pet.Specie == "dog"));

        }


        static double SumNumbers(List<double[]> setsOfNumbers, int indexOfSetToSum)
        {
            return setsOfNumbers?[indexOfSetToSum]?.Sum() ?? double.NaN;
        }

        public class Document 
        {
            public string Title { get; set; } = "Untitled";
        }

        #endregion

        #region 1.D 1.E 1.F
        public class Vegetable
        {

            public Vegetable(string name) => Name = name;
            public string Name { get; }
            //public override string ToString() => Name; 
        }
        public enum Unit { item, kilogram, gram, dozen };
        public static void Run1DEF()
        {
            //String Interpolation

            //Ejemplo 1
            var name = "Claudia";
            Console.WriteLine($"Hello, {name}. It's a pleasure to meet you!");

            //Ejemplo 2
            var item = new Vegetable("eggplant");
            var date = DateTime.Now;
            var price = 1.99m;
            var unit = Unit.item;
            Console.WriteLine($"On {date}, the price of {item} was {price} per {unit}.");

            //Ejemplo 3
            Console.WriteLine($"Note los espacios{"<--Aqui",15}");

            //Ejemplo 4
            var d = new DateTime(1731, 11, 25);
            Console.WriteLine($"On {date:dddd, MMMM dd, yyyy} Leonhard Euler introduced the letter e to denote {Math.E:F5} in a letter to Christian Goldbach.");


            //EXCEPTION FILTERS

            //Ejemplo 1
            Random random = new Random();
            var randomException = random.Next(400, 405);
            Console.WriteLine("Generated Exception: " + randomException);
            Console.WriteLine("Exception type: ");

            //Before
            try
            {
                throw new Exception(randomException.ToString());
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("400"))
                    Console.Write("Bad Request");
                else if (ex.Message.Equals("401"))
                    Console.Write("Unauthorized");
                else if (ex.Message.Equals("402"))
                    Console.Write("Payment Required");
                else if (ex.Message.Equals("403"))
                    Console.Write("Forbidden");
                else if (ex.Message.Equals("404"))
                    Console.Write("Not Found");
            }


            ////Now
            try
            {
                throw new Exception(randomException.ToString());
            }
            catch (Exception ex) when (ex.Message.Equals("400"))
            {
                Console.WriteLine("Bad Request");
            }
            catch (Exception ex) when (ex.Message.Equals("401"))
            {
                Console.WriteLine("Unauthorized");
            }
            catch (Exception ex) when (ex.Message.Equals("401"))
            {
                Console.WriteLine("Payment Required");
            }
            catch (Exception ex) when (ex.Message.Equals("401"))
            {
                Console.WriteLine("Not Found");
            }

            //Ejemplo 2
            try
            {
                DoSomethingThatFails();
            }
            catch (Exception ex)
            {
                if (ex.Message == "error")
                    Console.WriteLine("Error");
                else
                    throw;
            }

            try
            {
                DoSomethingThatFails();
            }
            catch (Exception ex) when (ex.Message.Equals("error"))
            {
                Console.WriteLine("Error");
            }




        }

        public static void DoSomethingThatFails()
        {
            throw new Exception("exception");
        }


        #endregion


        #region 1.G 1.H

        enum MyEnum {  FooBar = 7 }
        public static void Run1GH() 
        {
            Console.WriteLine(nameof(System.Collections.Generic)); //output: Generic
            Console.WriteLine(nameof(List<int>));                 // output: List
            Console.WriteLine(nameof(List<int>.Count));           // output: Count
            Console.WriteLine(nameof(List<int>.Add));             // output: Add

            var numbers = new List<int> { 1, 2, 3 };
            Console.WriteLine(nameof(numbers));                   //output: numbers
            Console.WriteLine(nameof(numbers.Count));             //output: Count
            Console.WriteLine(nameof(numbers.Add));               //output: Add
            Console.WriteLine(MyEnum.FooBar.ToString());

            //Code6
            Console.WriteLine(nameof(MyEnum.FooBar));

            //Code7
            BigInteger bigIntFromDouble = new BigInteger(179032.6541);
            Console.WriteLine(bigIntFromDouble);                        //output: 179032
            BigInteger bigIntFromInt64 = new BigInteger(934157136952);
            Console.WriteLine(bigIntFromInt64);                         //output: 934157136952

            //Code8
            long longValue = 6315489358112;
            BigInteger assignedFromLong = longValue;
            Console.WriteLine(assignedFromLong);  //output: 6315489358112

            //Code9
            BigInteger assignedFromDouble = (BigInteger)179032.6541;
            Console.WriteLine(assignedFromDouble);   //output: 179032
            BigInteger assignedFromDecimal = (BigInteger)64312.65m;
            Console.WriteLine(assignedFromDecimal);  //output: 64312

            //Code10
            byte[] byteArray = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            BigInteger newBigInt = new BigInteger(byteArray);
            Console.WriteLine("The value of newBigInt is {0} (or 0x{0:x}).", newBigInt);
            //output: The value of newBigInt is 477275222530853130 (or 0x102030405060708090a).

            //Code11
            string positiveString = "91389681247993671255432112000000";
            string negativeString = "-90315837410896312071002088037140000";
            BigInteger posBigInt = 0;
            BigInteger negBigInt = 0;

            try
            {
                posBigInt = BigInteger.Parse(positiveString);
                Console.WriteLine(posBigInt);
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to convert the string '{0}' to a BigInteger value.",
                                  positiveString);
            }

            if (BigInteger.TryParse(negativeString, out negBigInt))
                Console.WriteLine(negBigInt);
            else
                Console.WriteLine("Unable to convert the string '{0}' to a BigInteger value.",
                                   negativeString);

            /* output: 9.1389681247993671255432112E+31
                       -9.0315837410896312071002088037E+34 */

            //Code12
            BigInteger number = BigInteger.Pow(UInt64.MaxValue, 3);
            Console.WriteLine(number);  //output: 6277101735386680762814942322444851025767571854389858533375

            //Code13
            number = BigInteger.Multiply(Int64.MaxValue, 3);
            number++;
            Console.WriteLine(number);

            Console.WriteLine(Fibonacci(1000));
            //output: 43466557686937456435688527675040625802564660517371780402481729089536555417949051890403879840079255169295922593080322634775209689623239873322471161642996440906533187938298969649928516003704476137795166849228875

        }

        //Code14
        static BigInteger Fibonacci(int n)
        {
            if (n == 0)
                return 0;
            BigInteger a = 0;
            BigInteger b = 1;
            n--;

            while (n > 0)
            {
                BigInteger c = a + b;
                a = b;
                b = c;
                n--;
            }
            return b;
        }
     

        #endregion

        #region 2.A 2.B

        public struct Point
        {
            int x, y;
            public void GetCoordinates(out int x, out int y)
            {
                x = this.x;
                y = this.y;
            }
        };

        //C# 7
        public void PrintCoordinates(Point p)
        {
            p.GetCoordinates(out var x, out var y);
            Console.WriteLine($"({x}, {y})");
        }
        //public void PrintCoordinates(Point p)
        //{
        //    int num;
        //    int num2;
        //    p.GetCoordinates(out num, out num2);
        //    Console.WriteLine($"({num}, {num2})");
        //}

        public void PrintStars(string s)
        {
            if (int.TryParse(s, out var i)) Console.WriteLine(new string('*', i));
            else Console.WriteLine("Cloudy - no stars tonight");
        }

        public void PrintStars(object o)
        {
            if (o is null) return;
            if (!(o is int i)) return;
            else
                Console.WriteLine(new string('*', i));
        }

        //public void PrintStars(object o)
        //{
        //    if (o != null)
        //    {
        //        int num;
        //        bool flag1;
        //        if (o is int)
        //        {
        //            num = (int)o;
        //            flag1 = 1 == 0;
        //        }
        //        else
        //        {
        //            flag1 = true;
        //        }
        //        if (!flag1)
        //        {
        //            Console.WriteLine(new string('*', num));
        //        }
        //    }
        //}

        public class Figure { }
        public class Circle : Figure { public int Radius; }
        public class Rectangle : Figure { public int Lenght, Height; }
        public void Code(Figure shape, object o)
        {
            switch (shape)
            {
                case Circle c:
                    Console.WriteLine($"circle with radius {c.Radius}");
                    break;
                case Rectangle t when (t.Lenght == t.Height):
                    Console.WriteLine($"{t.Lenght} x {t.Height} square");
                    break;
                case Rectangle r:
                    Console.WriteLine($"{r.Lenght} x {r.Height} rectangle");
                    break;
                default:
                    Console.WriteLine("<unknown shape");
                    break;
                case null:
                    throw new ArgumentNullException(nameof(shape));
            }
            //Figure figure = shape;
            //    Circle circle = figure as Circle;
            //    if (circle != null)
            //    {
            //        Console.WriteLine($"circle with radius {circle.Radius}");
            //    }
            //    else
            //    {
            //        Rectangle rectangle = figure as Rectangle;
            //        if (rectangle == null)
            //        {
            //            if (figure == null)
            //            {
            //                throw new ArgumentNullException("shape");
            //            }
            //            Console.WriteLine("<unknown shape");
            //        }
            //        else if (rectangle.Lenght == rectangle.Height)
            //        {
            //            Console.WriteLine($"{rectangle.Lenght} x {rectangle.Height} square");
            //        }
            //        else
            //        {
            //            Rectangle rectangle2 = rectangle;
            //            Console.WriteLine($"{rectangle2.Lenght} x {rectangle2.Height} rectangle");
            //        }
            //    }


            if (o is int i || (o is string s && int.TryParse(s, out i))) { /*use i*/}

            //int num;
            //bool flag1;
            //if (o is int)
            //{
            //    num = (int)o;
            //    flag1 = true;
            //}
            //else
            //{
            //    string s = o as string;
            //    flag1 = (s != null) && int.TryParse(s, out num);
            //}
            //if (flag1)
            //{
            //}

        }
        #endregion
    }
}
