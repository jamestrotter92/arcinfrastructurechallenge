using System.Collections.Generic;
using System.Linq;

namespace ArcInfrastructure.ShapeAreaCalculator.Core.Shapes
{
    public static class DefaultRegistrations
    {
        public static IReadOnlyList<ShapeRegistration> AllDefaults => new List<ShapeRegistration>
        {
            new ShapeRegistration
            {
                Key = "Circle",
                DimensionKeys = CreateList("Radius"),
                Generator = (IDictionary<string, double> dimensions) => new Circle(dimensions["Radius"]),
            },
            new ShapeRegistration
            {
                Key = "Rectangle",
                DimensionKeys = CreateList("Length", "Width"),
                Generator = (IDictionary<string, double> dimensions) => new Rectangle(dimensions["Length"], dimensions["Width"]),
            },
            new ShapeRegistration
            {
                Key = "Square",
                DimensionKeys = CreateList("Length"),
                Generator = (IDictionary<string, double> dimensions) => new Square(dimensions["Length"]),
            },
        };

        private static List<string> CreateList(params string[] elements) => elements.ToList();
    }
}
