using System;
using System.Collections.Generic;
using System.Text;



namespace Example1
{

    public class Person
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public Person(string fname, string mname, string lname,
                      string cityName, string stateName)
        {
            FirstName = fname;
            MiddleName = mname;
            LastName = lname;
            City = cityName;
            State = stateName;
        }

        // Return the first and last name.
        public void Deconstruct(out string fname, out string lname)
        {
            fname = FirstName;
            lname = LastName;
        }
        void Deconstruct(out string fname, out string mname, out string lname)
        {
            fname = FirstName;
            mname = MiddleName;
            lname = LastName;
        }

        public void Deconstruct(out string fname, out string lname,
                                out string city, out string state)
        {
            fname = FirstName;
            lname = LastName;
            city = City;
            state = State;
        }
    }
    class Program
    {
        public struct Point
        {
            public int X, Y, Z;
            public override string ToString() => $"({X}, {Y}, {Z})";
        }

        public static (string, double, int, int, int, int) QueryCityDataForYears(string name, int year1, int year2)
        {
            int population1 = 0, population2 = 0;
            double area = 0;

            if (name == "New York City")
            {
                area = 468.48;
                if (year1 == 1960)
                {
                    population1 = 7781984;
                }
                if (year2 == 2010)
                {
                    population2 = 8175133;
                }
                return (name, area, year1, population1, year2, population2);
            }

            return ("", 0, 0, 0, 0, 0);
        }
        public static (string, int, double) QueryCityData(string name)
        {
            if (name == "New York City")
                return (name, 8175133, 468.48);

            return ("", 0, 0);
        }
        static void Drift(ref Point point, int steps)
        {
            var rnd = new Random();
            for (int i = 0; i < steps; i++)
            {
                point.X += rnd.Next(-5, 6);
                point.Y += rnd.Next(-5, 6);
                point.Z += rnd.Next(-5, 6);
            }
        }
        static void Drift2(ref Point point, int steps)
        {
            ref Point p = ref point;
            var rnd = new Random();
            for (int i = 0; i < steps; i++)
            {
                p.X += rnd.Next(-5, 6);
                p.Y += rnd.Next(-5, 6);
                p.Z += rnd.Next(-5, 6);
            }
        }
        static void Run()
        {
            #region inc ii
            //Create Tuple
            var person = ("Alejandro", 34);
            Console.WriteLine(person.Item1);//Alejandro
            Console.WriteLine(person.Item2);//34

            //Create Tuple
            var person1 = (name: "Alejandro", age: 34);
            Console.WriteLine(person1.name);//Alejandro
            Console.WriteLine(person1.age);//34
            #endregion
            #region inc iii


            // use of tuples with dictionaries before C#7
            var number = new Dictionary<Tuple<int, int>, string>
            {
                [new Tuple<int, int>(7, 2)] = "seven",
                [new Tuple<int, int>(9, 2)] = "nine",
                [new Tuple<int, int>(7, 2)] = "thirteen"
            };

            // use of tuples with dictionaries after C#7
            var numbers = new Dictionary<(int, int), string>
            {
                [(7, 2)] = "seven",
                [(9, 2)] = "nine",
                [(2, 3)] = "thirteen"
            };


            // use of tuples with lists before C#7
            List<Tuple<int, int>> list = new List<Tuple<int, int>>
            {
                new Tuple<int,int>(1,1),
                new Tuple<int,int>(1,2),
                new Tuple<int,int>(1,3),
            };

            // use of tuples with lists after C#7
            List<(int, int)> list1 = new List<(int, int)>
            {
                (1, 1),
                (1, 2),
                (1, 3),
            };
            #endregion
            #region inc iv
            // manera 1
            (string city, int population, double area) = QueryCityData("New York City");
            Console.WriteLine(city, population, area);

            //manera2
            //var (city, population, area) = QueryCityData("New York City");
            //Console.WriteLine(city, population, area);

            ////manera3
            //string city = "Raleigh";
            //int population = 458880;
            //double area = 144.8;
            //(city, population, area) = QueryCityData("New York City");

            #endregion
            #region inc v


            var p = new Person("John", "Quincy", "Adams", "Boston", "MA");

            // Deconstruct the person object.
            //var (fName, lName, city, state) = p;
            //Console.WriteLine($"Hello {fName} {lName} of {city}, {state}!");
            //#endregion
            //#region inc vi
            //var (_, _, _, pop1, _, pop2) = QueryCityDataForYears("New York City", 1960, 2010);

            //Console.WriteLine($"Population change, 1960 to 2010: {pop2 - pop1:N0}");
            //#endregion
            //#region inc d
            //Point p = new Point { X = 0, Y = 0, Z = 0 };
            //Drift(ref p, 100);
            //Console.WriteLine(p);
            //Drift(ref p, 100);
            //Console.WriteLine(p);
            #endregion
        }
    }
}

