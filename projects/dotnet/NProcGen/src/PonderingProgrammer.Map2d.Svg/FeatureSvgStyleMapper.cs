using System.Drawing;
using PonderingProgrammer.Map2d.FeatureObjects;
using Svg;

namespace PonderingProgrammer.Map2d.Svg
{
    public class FeatureSvgStyleMapper
    {
        public void StyleThis(SvgElement element, IFeatureObject feature)
        {
            element.Stroke = new SvgColourServer(Color.Black);
            element.Fill = new SvgColourServer(feature.FeatureType == FeatureType.Open ? Color.Bisque : Color.DarkSlateGray);
            element.StrokeWidth = new SvgUnit(1);
        }
    }
}
