﻿using PonderingProgrammer.GridMath;
using PonderingProgrammer.GridMath.Shapes;
using PonderingProgrammer.Map2d.FeatureObjects;

namespace PonderingProgrammer.Map2d
{
    public class GridPointFeature : IGridFeatureObject
    {
        public GridPointFeature(FeatureType featureType, GridCoordinatePair coordinates)
        {
            FeatureType = featureType;
            Shape = new GridPoint(coordinates);
        }

        public IGridShape Shape { get; }
        public FeatureType FeatureType { get; }
    }
}
