using System.Collections.Generic;

namespace ArcInfrastructure.ShapeAreaCalculator.Core
{
    public interface IShapeFactory
    {
        void RegisterShape(ShapeRegistration registration);

        IReadOnlyList<string> GetShapes();

        IShape CreateShape(string shapeKey, IDictionary<string, double> dimensions);

        IReadOnlyList<string> GetDimensionKeys(string shapeKey);
    }
}
