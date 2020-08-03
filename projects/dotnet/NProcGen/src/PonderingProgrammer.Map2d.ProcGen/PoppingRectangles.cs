using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;

namespace PonderingProgrammer.Map2d.ProcGen
{
    public class PoppingRectangles
    {
        public ManhattanFixedSquareMap2d<bool> Generate(PoppingRectanglesGenerationOptions options)
        {
            var context = new ValidationContext(options);
            var validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(options, context, validationResults))
            {
                throw new ArgumentException(string.Join(";", validationResults.Select(r => r.ErrorMessage)));
            }
            var rand = new Random();
            var factory = new AABoxFactory();
            var map = GenerateFixedMap(options.Width, options.Height);
            var superBounds = map.GetBounds();
            var category = Aspect.RatioToType(options.Width / options.Height);

            var firstRectSite = ChooseFirstRectSite(factory, superBounds, category);

            var firstRect = factory.CreateRandomWithinBox(firstRectSite, options.MinRectSize, options.MaxRectSize);
            map.SetInBounds(true, firstRect);
            var seeds = FindFreeRangeSurfaceCells(map, options.MinRectSize);
            var rectCount = 1;
            while (rectCount < options.RectCount && seeds.Count > 0)
            {
                var seedIndex = rand.RandRange(0, seeds.Count);
                var coord = seeds[seedIndex].Coord;
                seeds.RemoveAt(seedIndex);
                var newRect = factory.CreateRandom(options.MinRectSize, options.MaxRectSize);
                newRect = newRect.Translate(coord.X - newRect.Width / 2, coord.Y - newRect.Height / 2);
                if (superBounds.Contains(newRect))
                {
                    seeds = FindFreeRangeSurfaceCells(map, options.MinRectSize);
                    map.SetInBounds(true, newRect);
                    rectCount++;
                }
            }

            return map;
        }

        private List<Cell<bool>> FindFreeRangeSurfaceCells(IMap2d<bool> map, int range)
        {
            var minX = map.GetBounds().MinX;
            var minY = map.GetBounds().MinY;
            var maxX = map.GetBounds().MaxXExclusive;
            var maxY = map.GetBounds().MaxYExclusive;
            return FindFreeSurfaceCells(map).Where(c =>
                c.Coord.X >= minX && c.Coord.Y >= minY && c.Coord.X < maxX && c.Coord.Y < maxY)
                .ToList();
        }

        private IEnumerable<Cell<bool>> FindFreeSurfaceCells(IMap2d<bool> map)
        {
            return map.FindCellsByValue(v => v == true)
                .Where(c => map.FindAdjacentCells(c.Coord).Any(ac => ac.Value == false));
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
