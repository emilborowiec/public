using System;
using System.Collections.Generic;

namespace PonderingProgrammer.Map2d
{
    public interface IMap2d<T>
    {
        bool HasCell(int x, int y);
        bool HasCell(Coord coord);

        Cell<T> GetCell(int x, int y);
        Cell<T> GetCell(Coord coord);

        T GetValueOrDefault(int x, int y);
        T GetValueOrDefault(Coord coord);

        IEnumerable<Cell<T>> GetCells();
        IEnumerable<Cell<T>> GetCellsRowMajor();

        AABox GetBounds();

        IEnumerable<Cell<T>> FindCells(Predicate<Cell<T>> predicate);
        IEnumerable<Cell<T>> FindCellsByValue(Predicate<T> predicate);

        IEnumerable<Cell<T>> FindAdjacentCells(int x, int y);
        IEnumerable<Cell<T>> FindAdjacentCells(Coord coord);

        CellGraph<T> ToCellGraph();
    }
}
