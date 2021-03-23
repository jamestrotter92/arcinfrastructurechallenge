using ArcInfrastructure.ShapeAreaCalculator.Core.Shapes;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ArcInfrastructure.ShapeAreaCalculator.Core.Tests.Shapes
{
    public class RectangleTests
    {
        [Fact]
        public void Calculates_Correct_Area()
        {
            var sut = new Rectangle(2.5, 3.5);

            var area = sut.Area();

            area.ShouldBe(8.75, TestConstants.AreaTolerance);
        }

        [Fact]
        public void Throws_Exception_When_Instantiating_With_Negative_Width()
        {
            Func<Rectangle> func = () => new Rectangle(1.0, -1.0);

            func.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Throws_Exception_When_Instantiating_With_Negative_Length()
        {
            Func<Rectangle> func = () => new Rectangle(-1.0, 1.0);

            func.ShouldThrow<ArgumentException>();
        }
    }
}
