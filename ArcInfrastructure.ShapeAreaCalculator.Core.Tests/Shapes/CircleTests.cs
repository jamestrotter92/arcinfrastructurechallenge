using ArcInfrastructure.ShapeAreaCalculator.Core.Shapes;
using Shouldly;
using System;
using Xunit;

namespace ArcInfrastructure.ShapeAreaCalculator.Core.Tests.Shapes
{
    public class CircleTests
    {
        [Fact]
        public void Calculates_Correct_Area()
        {
            var sut = new Circle(1.0);

            var area = sut.Area();

            area.ShouldBe(3.1415926535, TestConstants.AreaTolerance);
        }

        [Fact]
        public void Throws_Exception_When_Instantiating_With_Negative_Radius()
        {
            Func<Circle> func = () => new Circle(-1.0);

            func.ShouldThrow<ArgumentException>();
        }
    }
}
