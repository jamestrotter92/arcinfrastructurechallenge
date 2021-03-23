using System;

namespace ArcInfrastructure.ShapeAreaCalculator.Core.Shapes
{
    public class Circle : IShape
    {
        private double _radius;

        public Circle(double radius)
        {
            if (radius < 0.0)
            {
                throw new ArgumentException("Radius of circle cannot be negative");
            }

            _radius = radius;
        }

        public double Area()
        {
            return Math.PI * Math.Pow(_radius, 2);
        }
    }
}
