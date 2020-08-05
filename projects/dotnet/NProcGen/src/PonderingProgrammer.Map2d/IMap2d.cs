using System;
using System.Collections.Generic;
using PonderingProgrammer.GridMath;

namespace PonderingProgrammer.Map2d
{
    public interface IMap2d<T>
    {
        bool HasCell(int x, int y);
        bool HasCell(IntCoord intCoord);

        Cell<T> GetCell(int x, int y);
        Cell<T> GetCell(IntCoord intCoord);

        T GetValueOrDefault(int x, int y);
        T GetValueOrDefault(IntCoord intCoord);

        IEnumerable<Cell<T>> GetCells();
        IEnumerable<Cell<T>> GetCellsRowMajor();

        GridMath.GridBoundingBox GetBounds();

        IEnumerable<Cell<T>> FindCells(Predicate<Cell<T>> predicate);
        IEnumerable<Cell<T>> FindCellsByValue(Predicate<T> predicate);

        IEnumerable<Cell<T>> FindAdjacentCells(int x, int y);
        IEnumerable<Cell<T>> FindAdjacentCells(IntCoord intCoord);

        CellGraph<T> ToCellGraph();
    }
}
