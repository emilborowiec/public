using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using PonderingProgrammer.GridMath;

namespace PonderingProgrammer.Map2d.ProcGen.PoppingRectangles
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
            var randBoxFactory = new RandomBoxFactory();
            var map = GenerateFixedMap(options.Width, options.Height);
            var superBounds = map.GetBounds();
            var category = Aspect.RatioToType(options.Width / options.Height);

            var firstRect = randBoxFactory.RandomSizeBox(options.MinRectSize, options.MaxRectSize);
            firstRect = firstRect.Relate(superBounds, Relation.CenterOrLowerToCenterOrLower(),
                Relation.CenterOrLowerToCenterOrLower());
            map.SetInBounds(true, firstRect);
            var seeds = FindFreeRangeSurfaceCells(map, options.MinRectSize);
            var rectCount = 1;
            while (rectCount < options.RectCount && seeds.Count > 0)
            {
                var seedIndex = rand.RandRange(0, seeds.Count);
                var coord = seeds[seedIndex].IntCoord;
                seeds.RemoveAt(seedIndex);
                var newRect = randBoxFactory.RandomSizeBox(options.MinRectSize, options.MaxRectSize);
                newRect = newRect.SetPosition(coord.X, coord.Y, IntervalAnchor.CenterOrLower, IntervalAnchor.CenterOrLower);
                if (!superBounds.Contains(newRect))
                {
                    continue;
                }

                seeds = FindFreeRangeSurfaceCells(map, options.MinRectSize);
                map.SetInBounds(true, newRect);
                rectCount++;
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
                c.IntCoord.X >= minX && c.IntCoord.Y >= minY && c.IntCoord.X < maxX && c.IntCoord.Y < maxY)
                .ToList();
        }

        private IEnumerable<Cell<bool>> FindFreeSurfaceCells(IMap2d<bool> map)
        {
            return map.FindCellsByValue(v => v == true)
                .Where(c => map.FindAdjacentCells(c.IntCoord).Any(ac => ac.Value == false));
        }
        
        private ManhattanFixedSquareMap2d<bool> GenerateFixedMap(int width, int height)
        {
            return new ManhattanFixedSquareMap2d<bool>(width, height);
        }
    }
}
