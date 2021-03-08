using System;
using System.Collections.Generic;


namespace NoStaticDirectives
{
    class Circle
    {
        public List<double> Points { get; }
        public double Radius { get; }
        public Circle(double radius)
        {
            Radius = radius;
        }

        //Añadir una coleccion de puntos si y solo si cumplen que x^2 + y^2 == radio y guardar en Points solo las x ya que las y son facilmente calculables.
        public Circle(double radius, IEnumerable<Tuple<double,double>> points)
        {
            Radius = radius;
            System.Linq.Enumerable.All(points, x => Math.Pow(x.Item1, 2) + Math.Pow(x.Item2, 2) == radius);
            Points.AddRange(System.Linq.Enumerable.Select(points, x => x.Item1));
        }

        public double Diameter
        {
            get { return 2 * Radius; }
        }

        public double Circumference
        {
            get { return 2 * Radius * Math.PI; }
        }

        public double Area
        {
            get { return Math.PI * Math.Pow(Radius, 2); }
        }

    }
}
