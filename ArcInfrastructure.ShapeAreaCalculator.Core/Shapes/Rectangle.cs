using System;

namespace ArcInfrastructure.ShapeAreaCalculator.Core.Shapes
{
    public class Rectangle : IShape
    {
        private double _length;
        private double _width;

        public Rectangle(double length, double width)
        {
            if (length < 0.0 || width < 0.0)
            {
                throw new ArgumentException("Dimensions cannot be negative");
            }

            _length = length;
            _width = width;
        }

        public double Area()
        {
            return _length * _width;
        }
    }
}
