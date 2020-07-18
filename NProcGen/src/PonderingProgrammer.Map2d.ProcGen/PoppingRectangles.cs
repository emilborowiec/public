using System;
using System.Collections.Generic;

namespace PonderingProgrammer.Map2d.ProcGen
{
    public class PoppingRectangles
    {
        public ManhattanFixedSquareMap2d<bool> Generate(PoppingRectanglesParams options)
        {
            if (options.GetValidationErrors() is { } errors)
            {
                throw new ArgumentException(string.Join(";", errors));
            }
            var rand = new Random();
            var factory = new AABoxFactory();
            var map = GenerateFixedMap(options.Width, options.Height);
            var superBounds = map.GetBounds();
            var category = Aspect.RatioToType(options.Width / options.Height);

            var firstRectSite = ChooseFirstRectSite(factory, superBounds, category);

            var firstRect = factory.CreateRandomWithinBox(firstRectSite, options.MinRectSize, options.MaxRectSize);
            map.SetInBounds(true, firstRect);
            var corners = new List<Coord>(firstRect.Corners);
            var rectCount = 1;
            while (rectCount < options.RectCount)
            {
                var cornerIndex = rand.RandRange(0, corners.Count);
                var coord = corners[cornerIndex];
                corners.RemoveAt(cornerIndex);
                var newRect = factory.CreateRandom(options.MinRectSize, options.MaxRectSize);
                newRect = newRect.Translate(coord.X - newRect.Width / 2, coord.Y - newRect.Height / 2);
                if (superBounds.Contains(newRect))
                {
                    corners.AddRange(newRect.Corners);
                    map.SetInBounds(true, newRect);
                    rectCount++;
                }
            }

            return map;
        }

        private AABox ChooseFirstRectSite(AABoxFactory factory, AABox box, AspectType aspectType)
        {
            return aspectType switch
            {
                AspectType.SQUARE => factory.CreateSubBox(box, Alignment.CENTER, 0.5f, 0.5f),
                AspectType.LANDSCAPE => factory.CreateSubBox(box, Alignment.BOTTOM_LEFT, 0.3f, 0.5f),
                AspectType.PORTAIT => factory.CreateSubBox(box, Alignment.BOTTOM_LEFT, 0.5f, 0.3f),
                AspectType.LONG_HORIZONTAL => factory.CreateSubBox(box, Alignment.LEFT, 0.2f, 1f),
                AspectType.LONG_VERTICAL => factory.CreateSubBox(box, Alignment.BOTTOM, 1f, 0.2f),
                _ => factory.CreateSubBox(box, Alignment.BOTTOM, 1f, 0.2f),
            };
        }

        private ManhattanFixedSquareMap2d<bool> GenerateFixedMap(int width, int height)
        {
            return new ManhattanFixedSquareMap2d<bool>(width, height);
        }
    }
}
