using System.Linq;
using PonderingProgrammer.GridMath;
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
            var coord = new IntCoord(1, 1);
            var cell = _map.GetCell(coord);
            Assert.NotNull(cell);
            Assert.Equal(coord, cell.IntCoord);
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
            Assert.Equal(new IntCoord(0, 0), c1.IntCoord);
            Assert.Equal(new IntCoord(1, 0), c2.IntCoord);
        }

        [Fact]
        public void GetBounds()
        {
            var bounds = _map.GetBounds();
            Assert.Equal(6, bounds.Width);
            Assert.Equal(4, bounds.Height);
            Assert.Equal(0, bounds.MinX);
            Assert.Equal(0, bounds.MinY);
            Assert.Equal(6, bounds.MaxXExclusive);
            Assert.Equal(4, bounds.MaxYExclusive);
        }
    }
}
