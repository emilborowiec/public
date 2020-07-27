using System;

namespace PonderingProgrammer.Map2d.ProcGen
{
    public class AABoxFactory
    {
        private readonly Random _rand = new Random();

        public AABox CreateRandom(int minSize, int maxSize)
        {
            if (minSize < 1)
            {
                throw new ArgumentException("size must be > 0");
            }

            if (maxSize >= minSize)
            {
                throw new ArgumentException("maxSize must be >= minSize");
            }

            return new AABox(0, 0, _rand.RandRange(minSize, maxSize + 1), _rand.RandRange(minSize, maxSize + 1));
        }

        public AABox CreateRandomWithinBox(AABox box, int minSize, int maxSize)
        {
            if (minSize < 1)
            {
                throw new ArgumentException("size must be > 0");
            }

            if (maxSize >= minSize)
            {
                throw new ArgumentException("maxSize must be >= minSize");
            }

            if (maxSize > box.Width)
            {
                throw new ArgumentException("maxSize greater than box width");
            }

            if (maxSize > box.Height)
            {
                throw new ArgumentException("maxSize greater than box height");
            }

            var width = _rand.RandRange(minSize, maxSize + 1);
            var height = _rand.RandRange(minSize, maxSize + 1);

            var minX = _rand.RandRange(box.MinX, box.MaxX - width + 1);
            var minY = _rand.RandRange(box.MinY, box.MaxY - height + 1);

            return new AABox(minX, minY, width, height);
        }

        public AABox CreateSubBox(AABox superBox, Alignment alignment, double widthFraction, double heightFraction, bool roundUp = false)
        {
            var w = superBox.Width * widthFraction;
            var h = superBox.Height * heightFraction;
            var width = (int)(roundUp ? Math.Ceiling(w) : Math.Floor(w));
            var height = (int)(roundUp ? Math.Ceiling(h) : Math.Floor(h));
            if (width < 1 || height < 1) throw new ArgumentException("resulting width or height is < 1");
            var minX = 0;
            var minY = 0;
            switch (alignment)
            {
                case Alignment.CENTER:
                    minX = (int)Math.Floor(superBox.CenterX - (w / 2));
                    minY = (int)Math.Floor(superBox.CenterY - (h / 2));
                    break;
                case Alignment.TOP:
                    minX = (int)Math.Floor(superBox.CenterX - (w / 2));
                    minY = superBox.MinY;
                    break;
                case Alignment.TOP_RIGHT:
                    minX = (superBox.MaxX - width + 1);
                    minY = superBox.MinY;
                    break;
                case Alignment.RIGHT:
                    minX = superBox.MaxX - width + 1;
                    minY = (int)Math.Floor(superBox.CenterY - (h / 2));
                    break;
                case Alignment.BOTTOM_RIGHT:
                    minX = superBox.MaxX - width + 1;
                    minY = superBox.MaxY - height + 1;
                    break;
                case Alignment.BOTTOM:
                    minX = (int)Math.Floor(superBox.CenterX - (w / 2));
                    minY = superBox.MaxY - height + 1;
                    break;
                case Alignment.BOTTOM_LEFT:
                    minX = superBox.MinX;
                    minY = superBox.MaxY - height + 1;
                    break;
                case Alignment.LEFT:
                    minX = superBox.MinX;
                    minY = (int)Math.Floor(superBox.CenterY - (h / 2));
                    break;
                case Alignment.TOP_LEFT:
                    minX = superBox.MinX;
                    minY = superBox.MinY;
                    break;
            }
            return new AABox(minX, minY, width, height);
        }
    }
}
