using System;

namespace PonderingProgrammer.GridMath
{
    public readonly struct GridInterval
    {
        public readonly int Min;
        public readonly int Max;
        public readonly int MaxExcl;
        public readonly int Range;

        public static GridInterval FromMinMax(int min, int maxExcl)
        {
            if (maxExcl <= min) throw new ArgumentException("MaxExcl is exclusive and must be greater than Min");
            return new GridInterval(min, maxExcl);
        }

        public static GridInterval FromRange(int min, int range)
        {
            if (range < 1) throw new ArgumentException("Range must be greater than 0");
            return new GridInterval(min, min + range);
        }

        public GridInterval(int min, int maxExcl)
        {
            if (maxExcl <= min) throw new ArgumentException("MaxExcl is exclusive and must be greater than Min");
            Min = min;
            MaxExcl = maxExcl;
            Max = MaxExcl - 1;
            Range = maxExcl - min;
        }

        public bool Contains(int value)
        {
            return value >= Min && value < MaxExcl;
        }

        public bool Contains(GridInterval other)
        {
            return Min <= other.Min && MaxExcl >= other.MaxExcl;
        }

        public bool Overlaps(GridInterval other)
        {
            if (MaxExcl <= other.Min) return false;
            return Min < other.MaxExcl;
        }

        public bool Touches(GridInterval other)
        {
            return Min == other.MaxExcl || MaxExcl == other.Min;
        }

        public bool IsEven() => Range % 2 == 0;

        public bool CanFindCenter() => !IsEven();

        public bool CanSplitEven() => IsEven();

        public int Center()
        {
            if (!CanFindCenter()) throw new InvalidOperationException("Cannot find center on even range interval");
            return (Min + Max) / 2;
        }

        public int CenterOrLower()
        {
            return (Min + Max) / 2;
        }

        public int CenterOrHigher()
        {
            return (Min + MaxExcl) / 2;
        }

        public int HalfRangeOrLower()
        {
            return Range / 2;
        }

        public int HalfRangeOrHigher()
        {
            return (Range + 1) / 2;
        }

        public GridInterval[] SplitEven()
        {
            if (!CanSplitEven()) throw new InvalidOperationException("Cannot split even an interval with odd range");
            var halfRange = Range / 2;
            return new[] { new GridInterval(Min, Min + halfRange), new GridInterval(Min + halfRange, MaxExcl)};
        }

        public GridInterval Translate(int value)
        {
            return new GridInterval(Min + value, MaxExcl + value);
        }

        public GridInterval SetPosition(int position, IntervalAnchor anchor, int offset = 0)
        {
            return anchor switch
            {
                IntervalAnchor.Start => GridInterval.FromRange(position + offset, Range),
                IntervalAnchor.CenterOrLower => GridInterval.FromRange(position - (CenterOrLower() - Min) + offset, Range),
                IntervalAnchor.CenterOrHigher => GridInterval.FromRange(position - (CenterOrHigher() - Min) + offset, Range),
                IntervalAnchor.End => GridInterval.FromRange(position - (Max - Min) + offset, Range),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public GridInterval SetMin(int min)
        {
            return new GridInterval(min, min + Range);
        }

        public GridInterval SetMaxExcl(int maxExcl)
        {
            return new GridInterval(maxExcl - Range, maxExcl);
        }

        public GridInterval Relate(GridInterval second, Relation relation, int offset = 0)
        {
            return relation.Second switch
            {
                IntervalAnchor.Start => SetPosition(second.Min, relation.First, offset),
                IntervalAnchor.CenterOrLower => SetPosition(second.CenterOrLower(), relation.First, offset),
                IntervalAnchor.CenterOrHigher => SetPosition(second.CenterOrHigher(), relation.First, offset),
                IntervalAnchor.End => SetPosition(second.Max, relation.First, offset),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public GridInterval Fraction(double fraction)
        {
            var fractionRange = Integerizer.ToInt(Range * fraction, Rounding.ToCeiling);
            return GridInterval.FromRange(Min, fractionRange);
        }
    }
}
