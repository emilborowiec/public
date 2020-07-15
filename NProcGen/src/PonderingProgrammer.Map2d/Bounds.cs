using System;

namespace PonderingProgrammer.Map2d
{
    public struct Bounds
    {
        public readonly int minX;
        public readonly int minY;
        public readonly int width;
        public readonly int height;
        public readonly int maxX;
        public readonly int maxY;

        public Bounds(int minX, int minY, int width, int height)
        {
            if (width < 1 || height < 1) throw new ArgumentException($"Zero or negative size is illegal (width: {width}, height: {height}");
            this.minX = minX;
            this.minY = minY;
            this.width = width;
            this.height = height;
            maxX = minX + width - 1;
            maxY = minY + height - 1;
        }
    }
}
