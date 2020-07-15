namespace PonderingProgrammer.Map2d
{
    public class Cell<T>
    {
        public Coord Coord { get; }
        public T Value { get; set; }

        public Cell(Coord coord, T value)
        {
            Coord = coord;
            Value = value;
        }
    }
}
