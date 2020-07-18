using System;

namespace PonderingProgrammer.Map2d
{
    public struct AABox
    {
        public readonly int MinX;
        public readonly int MinY;
        public readonly int Width;
        public readonly int Height;
        public readonly int MaxX;
        public readonly int MaxY;
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
            MaxX = minX + width - 1;
            MaxY = minY + height - 1;
            CenterX = MinX + (Width / 2d);
            CenterY = MinY + (Height / 2d);
            Corners = new Coord[4];
            Corners[0] = new Coord(MinX, MinY);
            Corners[1] = new Coord(MaxX, MinY);
            Corners[2] = new Coord(MaxX, MaxY);
            Corners[3] = new Coord(MinX, MaxY);
        }

        public bool Contains(int x, int y)
        {
            return x >= MinX && x <= MaxX && y >= MinY && y <= MaxY;
        }

        public bool Contains(Coord coord)
        {
            return Contains(coord.X, coord.Y);
        }

        public bool Contains(AABox box)
        {
            return MinX <= box.MinX && MaxX >= box.MaxX && MinY <= box.MinY && MaxY >= box.MaxY;
        }

        public AABox Translate(int x, int y)
        {
            return new AABox(MinX + x, MinY + y, Width, Height);
        }
    }
}
