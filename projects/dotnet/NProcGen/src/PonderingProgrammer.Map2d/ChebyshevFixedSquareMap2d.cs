using System.Collections.Generic;

namespace PonderingProgrammer.Map2d
{
    public class ChebyshevFixedSquareMap2d<T> : FixedSquareMap2d<T>
    {
        public ChebyshevFixedSquareMap2d(int width, int height) : base(width, height)
        {
        }

        public override IEnumerable<Cell<T>> FindAdjacentCells(int x, int y)
        {
            if (GetCell(x, y - 1) is { } top) yield return top;
            if (GetCell(x + 1, y - 1) is { } topRight) yield return topRight;
            if (GetCell(x + 1, y) is { } right) yield return right;
            if (GetCell(x + 1, y + 1) is { } bottomRight) yield return bottomRight;
            if (GetCell(x, y + 1) is { } bottom) yield return bottom;
            if (GetCell(x - 1, y + 1) is { } bottomLeft) yield return bottomLeft;
            if (GetCell(x - 1, y) is { } left) yield return left;
            if (GetCell(x - 1, y - 1) is { } topLeft) yield return topLeft;
        }

        public override CellGraph<T> ToCellGraph()
        {
            var graph = new CellGraph<T>();
            foreach(var cell in GetCells())
            {
                graph.Nodes.Add(cell);
                foreach(var adjacent in FindAdjacentCells(cell.GridCoord))
                {
                    if (cell == adjacent) continue;
                    graph.Edges.Add(new CellGraphEdge<T>(cell, adjacent));
                }
            }
            return graph;
        }
    }
}
