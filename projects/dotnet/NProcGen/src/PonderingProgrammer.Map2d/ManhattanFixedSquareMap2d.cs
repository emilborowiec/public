using System;
using System.Collections.Generic;
using System.Text;

namespace PonderingProgrammer.Map2d
{
    public class ManhattanFixedSquareMap2d<T> : FixedSquareMap2d<T>
    {
        public ManhattanFixedSquareMap2d(int width, int height) : base(width, height)
        {
        }

        public override IEnumerable<Cell<T>> FindAdjacentCells(int x, int y)
        {
            if (GetCell(x, y - 1) is { } top) yield return top;
            if (GetCell(x + 1, y) is { } right) yield return right;
            if (GetCell(x, y + 1) is { } bottom) yield return bottom;
            if (GetCell(x - 1, y) is { } left) yield return left;
        }

        public override CellGraph<T> ToCellGraph()
        {
            var graph = new CellGraph<T>();
            foreach (var cell in GetCells())
            {
                graph.Nodes.Add(cell);
                foreach (var adjacent in FindAdjacentCells(cell.Coord))
                {
                    if (cell == adjacent) continue;
                    graph.Edges.Add(new CellGraphEdge<T>(cell, adjacent));
                }
            }
            return graph;
        }
    }
}
