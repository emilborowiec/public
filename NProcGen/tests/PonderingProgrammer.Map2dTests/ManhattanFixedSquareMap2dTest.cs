using PonderingProgrammer.Map2d;
using System.Linq;
using Xunit;

namespace PonderingProgrammer.Map2dTests
{
    public class ManhattanFixedSquareMap2dTest
    {
        [Fact]
        public void FindAdjacentCells()
        {
            var map = new ManhattanFixedSquareMap2d<bool>(9, 9);

            Assert.Equal(4, map.FindAdjacentCells(1, 1).Count());
            Assert.Equal(2, map.FindAdjacentCells(0, 0).Count());
            Assert.Equal(3, map.FindAdjacentCells(1, 0).Count());
        }

        [Fact]
        public void ToGraph()
        {
            var map = new ManhattanFixedSquareMap2d<bool>(2, 2);
            var graph = map.ToCellGraph();

            Assert.Equal(4, graph.Nodes.Count);
            Assert.Equal(4, graph.Edges.Count);
        }
    }
}
