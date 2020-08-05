using System;

namespace PonderingProgrammer.GridMath
{
    /// <summary>
    /// Axis-Aligned Box.
    /// Min/Max values follow [min,max) convention. Argument: www.cs.utexas.edu/~EWD/ewd08xx/EWD831.PDF 
    /// </summary>
    public readonly struct GridBoundingBox
    {
        public readonly GridInterval XInterval;
        public readonly GridInterval YInterval;
        public readonly IntCoord TopLeft;
        public readonly IntCoord TopRight;
        public readonly IntCoord BottomRight;
        public readonly IntCoord BottomLeft;

        public static GridBoundingBox FromMinMax(int minX, int minY, int maxX, int maxY)
        {
            if (maxX <= minX || maxY <= minY) throw new ArgumentException($"Max is exclusive and must be greater than Min");
            var xInterval = new GridInterval(minX, maxX);
            var yInterval = new GridInterval(minY, maxY);
            return new GridBoundingBox(xInterval, yInterval);             
        }

        public static GridBoundingBox FromSize(int minX, int minY, int width, int height)
        {
            if (width < 1 || height < 1) throw new ArgumentException($"Size must be greater than 0");
            var xInterval = new GridInterval(minX, minX + width);
            var yInterval = new GridInterval(minY, minY + height);
            return new GridBoundingBox(xInterval, yInterval);
        }
        
        public GridBoundingBox(GridInterval xInterval, GridInterval yInterval)
        {
            XInterval = xInterval;
            YInterval = yInterval;
            TopLeft = new IntCoord(XInterval.Min, YInterval.Min);
            TopRight = new IntCoord(XInterval.MaxExcl - 1, YInterval.Min);
            BottomRight = new IntCoord(XInterval.MaxExcl - 1, YInterval.MaxExcl - 1);
            BottomLeft = new IntCoord(XInterval.Min, YInterval.MaxExcl - 1);
        }

        public int MinX => XInterval.Min;
        public int MinY => YInterval.Min;
        public int Width => XInterval.Range;
        public int Height => YInterval.Range;
        public int MaxXExclusive => XInterval.MaxExcl;
        public int MaxYExclusive => YInterval.MaxExcl;

        public bool Contains(int x, int y)
        {
            return XInterval.Contains(x) && YInterval.Contains(y);
        }

        public bool Contains(IntCoord coord)
        {
            return Contains(coord.X, coord.Y);
        }

        public bool Contains(GridBoundingBox box)
        {
            return XInterval.Contains(box.XInterval) && YInterval.Contains(box.YInterval);
        }

        public bool Overlaps(GridBoundingBox other)
        {
            return XInterval.Overlaps(other.XInterval) && YInterval.Overlaps(other.YInterval);
        }

        public bool Touches(GridBoundingBox other)
        {
            return (XInterval.Touches(other.XInterval) && YInterval.Overlaps(other.YInterval)) 
                   || (YInterval.Touches(other.YInterval) && XInterval.Overlaps(other.XInterval));
        }

        public GridBoundingBox Translate(int x, int y)
        {
            return new GridBoundingBox(XInterval.Translate(x), YInterval.Translate(y));
        }

        public GridBoundingBox SetPosition(int x, int y, IntervalAnchor xAnchor, IntervalAnchor yAnchor, int xOffset = 0,
            int yOffset = 0)
        {
            return new GridBoundingBox(XInterval.SetPosition(x, xAnchor, xOffset), YInterval.SetPosition(y, yAnchor, yOffset));
        }

        public GridBoundingBox SetMinX(int value)
        {
            return new GridBoundingBox(XInterval.SetMin(value), YInterval);
        }

        public GridBoundingBox SetMaxX(int value)
        {
            return new GridBoundingBox(XInterval.SetMaxExcl(value), YInterval);
        }

        public GridBoundingBox SetMinY(int value)
        {
            return new GridBoundingBox(XInterval, YInterval.SetMin(value));
        }

        public GridBoundingBox SetMaxY(int value)
        {
            return new GridBoundingBox(XInterval, YInterval.SetMaxExcl(value));
        }

        public GridBoundingBox Relate(GridBoundingBox other, Relation xRelation, Relation yRelation, int xOffset = 0,
            int yOffset = 0)
        {
            return new GridBoundingBox(XInterval.Relate(other.XInterval, xRelation, xOffset), YInterval.Relate(other.YInterval, yRelation, yOffset));
        }
    }
}
