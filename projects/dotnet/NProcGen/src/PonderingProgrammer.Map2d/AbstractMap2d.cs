using System;
using System.Collections.Generic;

namespace PonderingProgrammer.Map2d
{
    public abstract class AbstractMap2d<T> : IMap2d<T>
    {
        public IEnumerable<Cell<T>> FindAdjacentCells(Coord coord) => FindAdjacentCells(coord.X, coord.Y);
        public Cell<T> GetCell(Coord coord) => GetCell(coord.X, coord.Y);
        public T GetValueOrDefault(Coord coord) => GetValueOrDefault(coord.X, coord.Y);
        public bool HasCell(Coord coord) => HasCell(coord.X, coord.Y);

        public abstract IEnumerable<Cell<T>> FindAdjacentCells(int x, int y);
        public abstract IEnumerable<Cell<T>> FindCells(Predicate<Cell<T>> predicate);
        public abstract IEnumerable<Cell<T>> FindCellsByValue(Predicate<T> predicate);
        public abstract AABox GetBounds();
        public abstract Cell<T> GetCell(int x, int y);
        public abstract IEnumerable<Cell<T>> GetCells();
        public abstract IEnumerable<Cell<T>> GetCellsRowMajor();
        public abstract T GetValueOrDefault(int x, int y);
        public abstract bool HasCell(int x, int y);
        public abstract CellGraph<T> ToCellGraph();
    }
}
