using System;
using System.Collections.Generic;

namespace PonderingProgrammer.Map2d
{
    public abstract class FixedSquareMap2d<T> : AbstractMap2d<T>
    {
        private readonly AABox _bounds;
        private readonly List<Cell<T>> _cells;

        public FixedSquareMap2d(int width, int height)
        {
            _bounds = new AABox(0, 0, width, height);

            _cells = new List<Cell<T>>(width * height);
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    _cells.Add(new Cell<T>(new Coord(x, y), default));
                }
            }
        }

        public override AABox GetBounds() => _bounds;

        public override Cell<T> GetCell(int x, int y) => HasCell(x, y) ? _cells[CoordToIndex(x, y)] : null;

        public override IEnumerable<Cell<T>> GetCells() => _cells;

        public override IEnumerable<Cell<T>> GetCellsRowMajor() => _cells;

        public override T GetValueOrDefault(int x, int y) => HasCell(x, y) ? _cells[CoordToIndex(x, y)].Value : default;

        public override bool HasCell(int x, int y)
        {
            return x >= 0 && x < _bounds.Width && y >= 0 && y < _bounds.Height;
        }

        public override IEnumerable<Cell<T>> FindCells(Predicate<Cell<T>> predicate) => _cells.FindAll(predicate);

        public override IEnumerable<Cell<T>> FindCellsByValue(Predicate<T> predicate) => _cells.FindAll(cell => predicate.Invoke(cell.Value));

        public IEnumerable<Cell<T>> FindCellsInBox(AABox box)
        {
            return FindCells((Cell<T> cell) => box.Contains(cell.Coord));
        }

        public void SetInBounds(T value, AABox bounds)
        {
            foreach (var cell in FindCellsInBox(bounds))
            {
                cell.Value = value;
            }
        }

        protected int CoordToIndex(int x, int y) => (y * _bounds.Width) + x;
    }
}
