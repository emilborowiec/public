using System;
using System.Collections.Generic;
using PonderingProgrammer.GridMath;

namespace PonderingProgrammer.Map2d
{
    public interface IMap2d<T>
    {
        bool HasCell(int x, int y);
        bool HasCell(GridCoordinatePair gridCoord);

        Cell<T> GetCell(int x, int y);
        Cell<T> GetCell(GridCoordinatePair gridCoord);

        T GetValueOrDefault(int x, int y);
        T GetValueOrDefault(GridCoordinatePair gridCoord);

        IEnumerable<Cell<T>> GetCells();
        IEnumerable<Cell<T>> GetCellsRowMajor();

        GridMath.GridBoundingBox GetBounds();

        IEnumerable<Cell<T>> FindCells(Predicate<Cell<T>> predicate);
        IEnumerable<Cell<T>> FindCellsByValue(Predicate<T> predicate);

        IEnumerable<Cell<T>> FindAdjacentCells(int x, int y);
        IEnumerable<Cell<T>> FindAdjacentCells(GridCoordinatePair gridCoord);

        CellGraph<T> ToCellGraph();
    }
}
