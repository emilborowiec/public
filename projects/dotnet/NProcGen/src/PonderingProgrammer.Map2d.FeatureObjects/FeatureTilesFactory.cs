using System.Collections.Generic;

namespace PonderingProgrammer.Map2d.FeatureObjects
{
    public class FeatureTilesFactory
    {
        private MapGeometryFactory _factory = new MapGeometryFactory();
        
        public List<IFeatureObject> Map2dToFeatureObjects(IMap2d<bool> map, double scale)
        {
            var list = new List<IFeatureObject>();
            foreach (var cell in map.GetCells())
            {
                var fo = new FeatureObject(_factory.MapCellToPolygon(cell, scale),
                    cell.Value ? FeatureType.Open : FeatureType.Solid);
            }
            return list;
        }
    }
}
