using System;
using System.Collections.Generic;

namespace ArcInfrastructure.ShapeAreaCalculator.Core
{
    public class ShapeRegistration
    {
        // Identifier for shape (also serves as display name)
        public string Key { get; set; }

        // List of dimensions that must be provided to create shape
        public IReadOnlyList<string> DimensionKeys { get; set; }

        // Function for generating an instance of the shape
        public Func<IDictionary<string, double>, IShape> Generator { get; set; }
    }
}
