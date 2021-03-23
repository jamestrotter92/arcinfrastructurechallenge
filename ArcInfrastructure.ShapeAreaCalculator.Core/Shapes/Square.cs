namespace ArcInfrastructure.ShapeAreaCalculator.Core.Shapes
{
    public class Square : IShape
    {
        private Rectangle _rect;

        public Square(double length)
        {
            _rect = new Rectangle(length, length);
        }

        public double Area()
        {
            return _rect.Area();
        }
    }
}
