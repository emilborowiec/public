using System.Collections.Generic;

namespace PonderingProgrammer.Map2d
{
    public class CellGraph<T>
    {
        public HashSet<Cell<T>> Nodes { get; } = new HashSet<Cell<T>>();
        public HashSet<CellGraphEdge<T>> Edges { get; } = new HashSet<CellGraphEdge<T>>();
    }
}
