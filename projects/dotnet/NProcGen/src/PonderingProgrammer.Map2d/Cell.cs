using PonderingProgrammer.GridMath;

namespace PonderingProgrammer.Map2d
{
    public class Cell<T>
    {
        public IntCoord IntCoord { get; }
        public T Value { get; set; }

        public Cell(IntCoord intCoord, T value)
        {
            IntCoord = intCoord;
            Value = value;
        }
    }
}
