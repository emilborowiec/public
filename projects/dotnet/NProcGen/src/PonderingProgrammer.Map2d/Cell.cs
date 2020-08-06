using PonderingProgrammer.GridMath;

namespace PonderingProgrammer.Map2d
{
    public class Cell<T>
    {
        public GridCoordinate GridCoord { get; }
        public T Value { get; set; }

        public Cell(GridCoordinate gridCoord, T value)
        {
            GridCoord = gridCoord;
            Value = value;
        }
    }
}
