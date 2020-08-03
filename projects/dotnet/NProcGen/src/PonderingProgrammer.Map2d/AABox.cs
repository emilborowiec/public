using System;

namespace PonderingProgrammer.Map2d
{
    /// <summary>
    /// Axis-Aligned Box.
    /// Min/Max values follow [min,max) convention. Argument: www.cs.utexas.edu/~EWD/ewd08xx/EWD831.PDF 
    /// </summary>
    public struct AABox
    {
        public readonly int MinX;
        public readonly int MinY;
        public readonly int Width;
        public readonly int Height;
        public readonly int MaxXExclusive;
        public readonly int MaxYExclusive;
        public readonly double CenterX;
        public readonly double CenterY;
        public readonly Coord[] Corners;

        public AABox(int minX, int minY, int width, int height)
        {
            if (width < 1 || height < 1) throw new ArgumentException($"Zero or negative size is illegal (width: {width}, height: {height}");
            this.MinX = minX;
            this.MinY = minY;
            this.Width = width;
            this.Height = height;
            MaxXExclusive = minX + width;
            MaxYExclusive = minY + height;
            CenterX = MinX + (Width / 2d);
            CenterY = MinY + (Height / 2d);
            Corners = new Coord[4];
            Corners[0] = new Coord(MinX, MinY);
            Corners[1] = new Coord(MaxXExclusive-1, MinY);
            Corners[2] = new Coord(MaxXExclusive-1, MaxYExclusive-1);
            Corners[3] = new Coord(MinX, MaxYExclusive);
        }

        public bool Contains(int x, int y)
        {
            return x >= MinX && x < MaxXExclusive && y >= MinY && y < MaxYExclusive;
        }

        public bool Contains(Coord coord)
        {
            return Contains(coord.X, coord.Y);
        }

        public bool Contains(AABox box)
        {
            return MinX <= box.MinX && MaxXExclusive >= box.MaxXExclusive && MinY <= box.MinY && MaxYExclusive >= box.MaxYExclusive;
        }

        public AABox Translate(int x, int y)
        {
            return new AABox(MinX + x, MinY + y, Width, Height);
        }
    }
}
