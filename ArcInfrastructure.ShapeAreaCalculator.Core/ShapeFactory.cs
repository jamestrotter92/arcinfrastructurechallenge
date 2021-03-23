using System;
using System.Collections.Generic;
using System.Linq;

namespace ArcInfrastructure.ShapeAreaCalculator.Core
{
    public class ShapeFactory : IShapeFactory
    {
        private List<ShapeRegistration> _registrations = new List<ShapeRegistration>();

        public void RegisterShape(ShapeRegistration registration)
        {
            _registrations.Add(registration);
        }

        public IReadOnlyList<string> GetShapes()
        {
            return _registrations.Select(r => r.Key).ToList();
        }

        public IShape CreateShape(string shapeKey, IDictionary<string, double> dimensions)
        {
            var registration = _registrations.Single(r => r.Key == shapeKey);

            return registration.Generator(dimensions);
        }

        public IReadOnlyList<string> GetDimensionKeys(string shapeKey)
        {
            return _registrations.Single(r => r.Key == shapeKey).DimensionKeys;
        }
    }
}
