using ArcInfrastructure.ShapeAreaCalculator.Core.Shapes;
using Shouldly;
using System;
using Xunit;

namespace ArcInfrastructure.ShapeAreaCalculator.Core.Tests.Shapes
{
    public class SquareTests
    {
        [Fact]
        public void Calculates_Correct_Area()
        {
            var sut = new Square(2.5);

            var area = sut.Area();

            area.ShouldBe(6.25, TestConstants.AreaTolerance);
        }

        [Fact]
        public void Throws_Exception_When_Instantiating_With_Negative_Length()
        {
            Func<Square> func = () => new Square(-1.0);

            func.ShouldThrow<ArgumentException>();
        }
    }
}
