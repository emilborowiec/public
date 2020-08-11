using PonderingProgrammer.GridMath;

namespace PonderingProgrammer.Map2d
{
    public class Cell<T>
    {
        public GridCoordinatePair GridCoord { get; }
        public T Value { get; set; }

        public Cell(GridCoordinatePair gridCoord, T value)
        {
            GridCoord = gridCoord;
            Value = value;
        }
    }
}
