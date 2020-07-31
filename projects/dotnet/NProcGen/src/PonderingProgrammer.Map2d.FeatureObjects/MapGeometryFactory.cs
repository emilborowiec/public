using NetTopologySuite.Geometries;

namespace PonderingProgrammer.Map2d.FeatureObjects
{
    public class MapGeometryFactory
    {
        private GeometryFactory _factory = new GeometryFactory();
        
        public Polygon MapCellToPolygon<T>(Cell<T> cell, double scale)
        {
            return _factory.CreatePolygon(CellCorners(cell, scale));
        }

        private Coordinate[] CellCorners<T>(Cell<T> cell, double scale)
        {
            return new[]
            {
                new Coordinate(cell.Coord.X * scale, cell.Coord.Y * scale),
                new Coordinate((cell.Coord.X + 1) * scale, cell.Coord.Y * scale),
                new Coordinate((cell.Coord.X + 1) * scale, (cell.Coord.Y + 1) * scale),
                new Coordinate(cell.Coord.X * scale, (cell.Coord.Y + 1) * scale),
                new Coordinate(cell.Coord.X * scale, cell.Coord.Y * scale),
            };
        }
    }
}
