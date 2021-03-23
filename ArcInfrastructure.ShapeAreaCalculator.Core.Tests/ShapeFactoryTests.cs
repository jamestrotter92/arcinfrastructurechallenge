using ArcInfrastructure.ShapeAreaCalculator.Core.Shapes;
using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;

namespace ArcInfrastructure.ShapeAreaCalculator.Core.Tests
{
    public class ShapeFactoryTests
    {
        private ShapeFactory _sut;

        public ShapeFactoryTests()
        {
            _sut = new ShapeFactory();

            _sut.RegisterShape(new ShapeRegistration
            {
                Key = "Circle",
                DimensionKeys = new List<string> { "Radius" },
                Generator = (IDictionary<string, double> dimensions) => new Circle(dimensions["Radius"])
            });

            _sut.RegisterShape(new ShapeRegistration
            {
                Key = "Rectangle",
                DimensionKeys = new List<string> { "Length", "Width" },
                Generator = (IDictionary<string, double> dimensions) => new Rectangle(dimensions["Length"], dimensions["Width"]),
            });

        }

        [Fact]
        public void Creates_A_Registered_Shape()
        {
            var shape = _sut.CreateShape("Circle", new Dictionary<string, double> { { "Radius", 1.0 } });

            shape.ShouldNotBeNull();
            shape.ShouldBeOfType<Circle>();
        }

        [Fact]
        public void Throws_When_Creating_Unregistered_Shape()
        {
            Func<IShape> func = () => _sut.CreateShape("Square", new Dictionary<string, double> { { "Length", 1.0 } });

            func.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Returns_List_Of_Registerd_Shapes()
        {
            var shapes = _sut.GetShapes();

            shapes.ShouldBe(new List<string> { "Circle", "Rectangle" }, ignoreOrder: true);
        }

        [Fact]
        public void Returns_List_Of_Dimension_Keys_For_Registered_Shape()
        {
            var dimensions = _sut.GetDimensionKeys("Rectangle");

            dimensions.ShouldBe(new List<string> { "Length", "Width" }, ignoreOrder: true);
        }


        [Fact]
        public void Throws_When_Querying_Dimension_Keys_For_Unregistered_Shape()
        {
            Func<IReadOnlyList<string>> func = () => _sut.GetDimensionKeys("Square");

            func.ShouldThrow<InvalidOperationException>();
        }
    }
}
