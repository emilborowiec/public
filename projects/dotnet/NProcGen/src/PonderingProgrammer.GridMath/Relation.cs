namespace PonderingProgrammer.GridMath
{
    public readonly struct Relation
    {
        public readonly IntervalAnchor First;
        public readonly IntervalAnchor Second;

        public static Relation StartToStart() => new Relation(IntervalAnchor.Start, IntervalAnchor.Start);
        public static Relation StartToCenterOrLower() => new Relation(IntervalAnchor.Start, IntervalAnchor.CenterOrLower);
        public static Relation StartToCenterOrHigher() => new Relation(IntervalAnchor.Start, IntervalAnchor.CenterOrHigher);
        public static Relation StartToEnd() => new Relation(IntervalAnchor.Start, IntervalAnchor.End);
        
        public static Relation CenterOrLowerToStart() => new Relation(IntervalAnchor.CenterOrLower, IntervalAnchor.Start);
        public static Relation CenterOrLowerToCenterOrLower() => new Relation(IntervalAnchor.CenterOrLower, IntervalAnchor.CenterOrLower);
        public static Relation CenterOrLowerToCenterOrHigher() => new Relation(IntervalAnchor.CenterOrLower, IntervalAnchor.CenterOrHigher);
        public static Relation CenterOrLowerToEnd() => new Relation(IntervalAnchor.CenterOrLower, IntervalAnchor.End);
        
        public static Relation CenterOrHigherToStart() => new Relation(IntervalAnchor.CenterOrHigher, IntervalAnchor.Start);
        public static Relation CenterOrHigherToCenterOrLower() => new Relation(IntervalAnchor.CenterOrHigher, IntervalAnchor.CenterOrLower);
        public static Relation CenterOrHigherToCenterOrHigher() => new Relation(IntervalAnchor.CenterOrHigher, IntervalAnchor.CenterOrHigher);
        public static Relation CenterOrHigherToEnd() => new Relation(IntervalAnchor.CenterOrHigher, IntervalAnchor.End);
        
        public static Relation EndToStart() => new Relation(IntervalAnchor.End, IntervalAnchor.Start);
        public static Relation EndToCenterOrLower() => new Relation(IntervalAnchor.End, IntervalAnchor.CenterOrLower);
        public static Relation EndToCenterOrHigher() => new Relation(IntervalAnchor.End, IntervalAnchor.CenterOrHigher);
        public static Relation EndToEnd() => new Relation(IntervalAnchor.End, IntervalAnchor.End);
        
        public Relation(IntervalAnchor first, IntervalAnchor second)
        {
            First = first;
            Second = second;
        }
    }
}
