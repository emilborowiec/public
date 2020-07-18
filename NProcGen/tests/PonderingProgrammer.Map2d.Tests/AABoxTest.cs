using PonderingProgrammer.Map2d;
using System;
using Xunit;

namespace PonderingProgrammer.Map2dTests
{
    public class AABoxTest
    {
        [Fact]
        public void TestMax()
        {
            var bounds = new AABox(1, 2, 3, 4);
            Assert.Equal(3, bounds.MaxX);
            Assert.Equal(5, bounds.MaxY);
        }

        [Theory]
        [InlineData(-1, 1)]
        [InlineData(2, -3)]
        [InlineData(0, 1)]
        [InlineData(2, 0)]
        public void TestSizeAssertions(int width, int height)
        {
            Assert.Throws<ArgumentException>(() => new AABox(0, 0, width, height));
        }
    }
}
