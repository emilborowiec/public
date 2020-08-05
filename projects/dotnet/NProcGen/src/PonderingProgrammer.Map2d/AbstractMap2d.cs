using System;
using System.Collections.Generic;
using PonderingProgrammer.GridMath;

namespace PonderingProgrammer.Map2d
{
    public abstract class AbstractMap2d<T> : IMap2d<T>
    {
        public IEnumerable<Cell<T>> FindAdjacentCells(IntCoord intCoord) => FindAdjacentCells(intCoord.X, intCoord.Y);
        public Cell<T> GetCell(IntCoord intCoord) => GetCell(intCoord.X, intCoord.Y);
        public T GetValueOrDefault(IntCoord intCoord) => GetValueOrDefault(intCoord.X, intCoord.Y);
        public bool HasCell(IntCoord intCoord) => HasCell(intCoord.X, intCoord.Y);

        public abstract IEnumerable<Cell<T>> FindAdjacentCells(int x, int y);
        public abstract IEnumerable<Cell<T>> FindCells(Predicate<Cell<T>> predicate);
        public abstract IEnumerable<Cell<T>> FindCellsByValue(Predicate<T> predicate);
        public abstract GridMath.GridBoundingBox GetBounds();
        public abstract Cell<T> GetCell(int x, int y);
        public abstract IEnumerable<Cell<T>> GetCells();
        public abstract IEnumerable<Cell<T>> GetCellsRowMajor();
        public abstract T GetValueOrDefault(int x, int y);
        public abstract bool HasCell(int x, int y);
        public abstract CellGraph<T> ToCellGraph();
    }
}
