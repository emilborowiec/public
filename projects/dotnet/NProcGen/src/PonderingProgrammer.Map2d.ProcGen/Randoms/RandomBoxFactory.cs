using System;
using PonderingProgrammer.GridMath;
using PonderingProgrammer.Map2d.ProcGen.BuddingRectangles;

namespace PonderingProgrammer.Map2d.ProcGen.Randoms
{
    public class RandomBoxFactory
    {
        private static void ValidateSizeLimits(int minSize, int maxSize)
        {
            if (minSize < 1)
            {
                throw new ArgumentException("size must be > 0");
            }
            if (maxSize < minSize)
            {
                throw new ArgumentException("maxSize must be >= minSize");
            }
        }
        
        private readonly Random _rand = new Random();
        
        public GridBoundingBox RandomSizeBox(int minSize, int maxSize)
        {
            ValidateSizeLimits(minSize, maxSize);

            return GridBoundingBox.FromSize(0, 0, _rand.Next(minSize, maxSize + 1), _rand.Next(minSize, maxSize + 1));
        }

        public GridBoundingBox RandomSizeBoxWithinBounds(GridBoundingBox bounds, int minSize, int maxSize)
        {
            ValidateSizeLimits(minSize, maxSize);
            var width = Math.Min(_rand.Next(minSize, maxSize + 1), bounds.Width);
            var height = Math.Min(_rand.Next(minSize, maxSize + 1), bounds.Height);
            
            var minX = _rand.Next(bounds.MinX, bounds.MaxXExcl - width + 1);
            var minY = _rand.Next(bounds.MinY, bounds.MaxYExcl - height + 1);

            return GridBoundingBox.FromSize(minX, minY, width, height);
        }
    }
}
