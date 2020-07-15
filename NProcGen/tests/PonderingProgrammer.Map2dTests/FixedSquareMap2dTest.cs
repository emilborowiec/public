using PonderingProgrammer.Map2d;
using System.Linq;
using Xunit;

namespace PonderingProgrammer.Map2dTests
{
    public class FixedSquareMap2dTest
    {
        private readonly ConcreteFixedSquareMap2d _map;

        public FixedSquareMap2dTest()
        {
            _map = new ConcreteFixedSquareMap2d(6, 4);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(2, 2)]
        [InlineData(5, 0)]
        [InlineData(0, 3)]
        public void HasCellPositive(int x, int y)
        {
            Assert.True(_map.HasCell(x, y));
            Assert.False(_map.HasCell(-1, 0));
            Assert.False(_map.HasCell(-1, 0));
            Assert.False(_map.HasCell(6, 0));
            Assert.False(_map.HasCell(0, 4));
            Assert.False(_map.HasCell(10, 10));
        }

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        [InlineData(6, 0)]
        [InlineData(0, 4)]
        [InlineData(10, 10)]
        public void HasCellNegative(int x, int y)
        {
            Assert.False(_map.HasCell(x, y));
        }

        [Fact]
        public void GetCell()
        {
            var coord = new Coord(1, 1);
            var cell = _map.GetCell(coord);
            Assert.NotNull(cell);
            Assert.Equal(coord, cell.Coord);
            Assert.Null(_map.GetCell(10, 10));
        }

        [Fact]
        public void GetCells()
        {
            var cells = _map.GetCells();
            Assert.Equal(6 * 4, cells.Count());
        }

        [Fact]
        public void GetCellsRowMajor()
        {
            var cells = _map.GetCellsRowMajor();
            var c1 = cells.ElementAt(0);
            var c2 = cells.ElementAt(1);
            Assert.Equal(new Coord(0, 0), c1.Coord);
            Assert.Equal(new Coord(1, 0), c2.Coord);
        }

        [Fact]
        public void GetBounds()
        {
            var bounds = _map.GetBounds();
            Assert.Equal(6, bounds.width);
            Assert.Equal(4, bounds.height);
            Assert.Equal(0, bounds.minX);
            Assert.Equal(0, bounds.minY);
            Assert.Equal(5, bounds.maxX);
            Assert.Equal(3, bounds.maxY);
        }
    }
}
