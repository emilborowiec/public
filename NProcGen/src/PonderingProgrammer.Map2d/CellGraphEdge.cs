using System;

namespace PonderingProgrammer.Map2d
{
    public class CellGraphEdge<T>
    {
        public Cell<T> C1 { get; }
        public Cell<T> C2 { get; }
        public bool Directional { get; }
        public double Weight { get; set; }

        public CellGraphEdge(Cell<T> c1, Cell<T> c2)
        {
            if (c1 == c2) throw new ArgumentException("Edges pointing to the same cell are illegal in this graph");
            C1 = c1 ?? throw new ArgumentNullException(nameof(c1));
            C2 = c2 ?? throw new ArgumentNullException(nameof(c2));
        }

        public CellGraphEdge(Cell<T> c1, Cell<T> c2, bool directional) : this(c1, c2)
        {
            Directional = directional;
        }

        public CellGraphEdge(Cell<T> c1, Cell<T> c2, bool directional, double weight) : this(c1, c2, directional)
        {
            Weight = weight;
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj is CellGraphEdge<T> edge)
            {
                if (Directional != edge.Directional) return false;
                bool sameSame = C1.Equals(edge.C1) && C2.Equals(edge.C2);
                bool sameReverse = C1.Equals(edge.C2) && C2.Equals(edge.C1);
                if (Directional)
                {
                    return sameSame;
                }
                return sameSame || sameReverse;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Directional ? HashCode.Combine(C1, C2) : C1.GetHashCode() + C2.GetHashCode();
        }
    }
}
