using PonderingProgrammer.Map2d;
using System;
using Xunit;

namespace PonderingProgrammer.Map2dTests
{
    public class BoundsTest
    {
        [Fact]
        public void TestMax()
        {
            var bounds = new Bounds(1, 2, 3, 4);
            Assert.Equal(3, bounds.maxX);
            Assert.Equal(5, bounds.maxY);
        }

        [Theory]
        [InlineData(-1, 1)]
        [InlineData(2, -3)]
        [InlineData(0, 1)]
        [InlineData(2, 0)]
        public void TestSizeAssertions(int width, int height)
        {
            Assert.Throws<ArgumentException>(() => new Bounds(0, 0, width, height));
        }
    }
}
