using Xunit;
using PonderingProgrammer.Map2d;

namespace PonderingProgrammer.Map2dTests
{
    public class CellGraphEdgeTest
    {
        [Fact]
        public void TestEquals()
        {
            var c1 = new Cell<int>(new Coord(1, 1), 1);
            var c2 = new Cell<int>(new Coord(2, 2), 2);
            var c3 = new Cell<int>(new Coord(3, 3), 3);
            var c4 = new Cell<int>(new Coord(4, 4), 4);

            var c1c2 = new CellGraphEdge<int>(c1, c2);
            var c1c2Clone = new CellGraphEdge<int>(c1, c2);
            var c1c2Dir = new CellGraphEdge<int>(c1, c2, true);
            var c1c2DirClone = new CellGraphEdge<int>(c1, c2, true);

            var c2c1 = new CellGraphEdge<int>(c2, c1);
            var c2c1Dir = new CellGraphEdge<int>(c2, c1, true);

            var c3c4 = new CellGraphEdge<int>(c1, c2);
            var c3c4Dir = new CellGraphEdge<int>(c1, c2, true);

            Assert.Equal(c1c2, c1c2Clone);
            Assert.Equal(c1c2, c2c1);
            Assert.Equal(c1c2Dir, c1c2DirClone);
            Assert.NotEqual(c1c2, c1c2Dir);
            Assert.NotEqual(c1c2Dir, c2c1Dir);
        }
    }
}
