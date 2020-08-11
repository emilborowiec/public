using System;
using System.Collections.Generic;
using PonderingProgrammer.GridMath;

namespace PonderingProgrammer.Map2d
{
    public abstract class AbstractMap2d<T> : IMap2d<T>
    {
        public IEnumerable<Cell<T>> FindAdjacentCells(GridCoordinatePair gridCoord) => FindAdjacentCells(gridCoord.X, gridCoord.Y);
        public Cell<T> GetCell(GridCoordinatePair gridCoord) => GetCell(gridCoord.X, gridCoord.Y);
        public T GetValueOrDefault(GridCoordinatePair gridCoord) => GetValueOrDefault(gridCoord.X, gridCoord.Y);
        public bool HasCell(GridCoordinatePair gridCoord) => HasCell(gridCoord.X, gridCoord.Y);

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
