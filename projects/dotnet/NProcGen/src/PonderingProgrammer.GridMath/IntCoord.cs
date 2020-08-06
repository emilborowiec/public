namespace PonderingProgrammer.GridMath
{
    /// <summary>
    /// An IntCoord is a coordinate on a 2-dimensional, integer space.
    /// </summary>
    public struct IntCoord
    {
        public readonly int X;
        public readonly int Y;

        public IntCoord(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
