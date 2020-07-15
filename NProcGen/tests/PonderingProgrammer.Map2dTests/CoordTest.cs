using PonderingProgrammer.Map2d;
using Xunit;

namespace PonderingProgrammer.Map2dTests
{
    public class CoordTest
    {
        [Fact]
        public void TestEquality()
        {
            var c1 = new Coord(2, 2);
            var c2 = new Coord(2, 2);
            var c3 = new Coord();
            var c4 = new Coord();
            Assert.Equal(c1, c2);
            Assert.Equal(c3, c4);
            Assert.NotEqual(c1, c3);
        }
    }
}
