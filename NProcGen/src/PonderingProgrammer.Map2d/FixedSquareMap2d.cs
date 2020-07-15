using System;
using System.Collections.Generic;

namespace PonderingProgrammer.Map2d
{
    public abstract class FixedSquareMap2d<T> : AbstractMap2d<T>
    {
        private readonly Bounds _bounds;
        private readonly List<Cell<T>> _cells;

        public FixedSquareMap2d(int width, int height)
        {
            _bounds = new Bounds(0, 0, width, height);

            _cells = new List<Cell<T>>(width * height);
            for (var y = 0; y < height; y++)
                for (var x = 0; x < width; x++)
                    _cells.Add(new Cell<T>(new Coord(x, y), default));
        }

        public override Bounds GetBounds() => _bounds;

        public override Cell<T> GetCell(int x, int y) => HasCell(x, y) ? _cells[CoordToIndex(x, y)] : null;

        public override IEnumerable<Cell<T>> GetCells() => _cells;

        public override IEnumerable<Cell<T>> GetCellsRowMajor() => _cells;

        public override T GetValueOrDefault(int x, int y) => HasCell(x, y) ? _cells[CoordToIndex(x, y)].Value : default;

        public override bool HasCell(int x, int y)
        {
            return x >= 0 && x < _bounds.width && y >= 0 && y < _bounds.height;
        }

        public override IEnumerable<Cell<T>> FindCells(Predicate<T> predicate) => _cells.FindAll(cell => predicate.Invoke(cell.Value));

        protected int CoordToIndex(int x, int y) => (y * _bounds.width) + x;
    }
}
