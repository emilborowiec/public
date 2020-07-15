using System;
using System.Collections.Generic;

namespace PonderingProgrammer.Map2d
{
    public abstract class AbstractMap2d<T> : IMap2d<T>
    {
        public IEnumerable<Cell<T>> FindAdjacentCells(Coord coord) => FindAdjacentCells(coord.x, coord.y);
        public Cell<T> GetCell(Coord coord) => GetCell(coord.x, coord.y);
        public T GetValueOrDefault(Coord coord) => GetValueOrDefault(coord.x, coord.y);
        public bool HasCell(Coord coord) => HasCell(coord.x, coord.y);

        public abstract IEnumerable<Cell<T>> FindAdjacentCells(int x, int y);
        public abstract IEnumerable<Cell<T>> FindCells(Predicate<T> predicate);
        public abstract Bounds GetBounds();
        public abstract Cell<T> GetCell(int x, int y);
        public abstract IEnumerable<Cell<T>> GetCells();
        public abstract IEnumerable<Cell<T>> GetCellsRowMajor();
        public abstract T GetValueOrDefault(int x, int y);
        public abstract bool HasCell(int x, int y);
        public abstract CellGraph<T> ToCellGraph();
    }
}
