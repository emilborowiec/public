using PonderingProgrammer.GridMath;
using PonderingProgrammer.GridMath.Shapes;
using PonderingProgrammer.Map2d.FeatureObjects;

namespace PonderingProgrammer.Map2d
{
    public class GridPointFeature : IGridFeatureObject
    {
        public GridPointFeature(FeatureType featureType)
        {
            Shape = new GridPoint(new GridCoordinatePair());
            FeatureType = featureType;
        }

        public IGridShape Shape { get; }
        public FeatureType FeatureType { get; }
    }
}
