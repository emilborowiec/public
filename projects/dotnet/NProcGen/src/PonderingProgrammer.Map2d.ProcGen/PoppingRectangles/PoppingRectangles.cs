using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using PonderingProgrammer.GridMath;
using RandomBoxFactory = PonderingProgrammer.Map2d.ProcGen.Randoms.RandomBoxFactory;

namespace PonderingProgrammer.Map2d.ProcGen.PoppingRectangles
{
    public class PoppingRectangles
    {
        public ManhattanFixedSquareGridMap<bool> Generate(PoppingRectanglesGenerationOptions options)
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

            var firstRect = randBoxFactory.RandomSizeBox(options.MinRectSize, options.MaxRectSize);
            firstRect = firstRect.Relate(superBounds, Relation.CenterToCenter(),
                Relation.CenterToCenter());
            map.SetInBounds(true, firstRect);
            var seeds = FindFreeRangeSurfaceCells(map, options.MinRectSize);
            while (seeds.Count > 0)
            {
                var seedIndex = rand.Next(0, seeds.Count);
                var coord = seeds[seedIndex].Coordinates;
                seeds.RemoveAt(seedIndex);
                var newRect = randBoxFactory.RandomSizeBox(options.MinRectSize, options.MaxRectSize);
                newRect = newRect.SetPosition(coord.X, coord.Y, IntervalAnchor.Center, IntervalAnchor.Center);
                if (!superBounds.Contains(newRect))
                {
                    continue;
                }

                seeds = FindFreeRangeSurfaceCells(map, options.MinRectSize);
                map.SetInBounds(true, newRect);
            }

            return map;
        }

        private List<GridMapField> FindFreeRangeSurfaceCells(IGridMap map, int range)
        {
            var minX = map.GetBounds().MinX + range;
            var minY = map.GetBounds().MinY + range;
            var maxX = map.GetBounds().MaxXExcl - range;
            var maxY = map.GetBounds().MaxYExcl - range;
            return FindFreeSurfaceCells(map).Where(c =>
                c.Coordinates.X >= minX && c.Coordinates.Y >= minY && c.Coordinates.X < maxX && c.Coordinates.Y < maxY)
                .ToList();
        }

        private IEnumerable<GridMapField> FindFreeSurfaceCells(IGridMap map)
        {
            return map.FindCellsByValue(v => v)
                .Where(c => map.FindAdjacentFields(c.Coordinates).Any(ac => ac.Value == false));
        }
        
        private ManhattanFixedSquareGridMap<bool> GenerateFixedMap(int width, int height)
        {
            return new ManhattanFixedSquareGridMap<bool>(width, height);
        }
    }
}
