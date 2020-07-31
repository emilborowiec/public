using NetTopologySuite.Geometries;

namespace PonderingProgrammer.Map2d.FeatureObjects
{
    public class FeatureObject : IFeatureObject
    {
        public FeatureObject(Geometry geometry, FeatureType featureType)
        {
            Geometry = geometry;
            FeatureType = featureType;
        }

        public Geometry Geometry { get; }
        public FeatureType FeatureType { get; }
    }
}
