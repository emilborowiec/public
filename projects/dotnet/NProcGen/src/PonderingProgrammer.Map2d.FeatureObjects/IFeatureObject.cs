using System;
using NetTopologySuite.Geometries;

namespace PonderingProgrammer.Map2d.FeatureObjects
{
    public interface IFeatureObject
    {
        Geometry Geometry { get; }
        FeatureType FeatureType { get; }
    }
}
