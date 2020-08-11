using System.Linq;
using Xunit;

namespace PonderingProgrammer.Map2d.Tests
{
    public class ChebyshevFixedSquareMap2dTest
    {
        [Fact]
        public void FindAdjacentCells()
        {
            var map = new ChebyshevFixedSquareMap2d<bool>(9, 9);

            Assert.Equal(8, map.FindAdjacentCells(1, 1).Count());
            Assert.Equal(3, map.FindAdjacentCells(0, 0).Count());
            Assert.Equal(5, map.FindAdjacentCells(1, 0).Count());
        }

        [Fact]
        public void ToGraph()
        {
            var map = new ChebyshevFixedSquareMap2d<bool>(2, 2);
            var graph = map.ToCellGraph();

            Assert.Equal(4, graph.Nodes.Count);
            Assert.Equal(6, graph.Edges.Count);
        }
    }
}
