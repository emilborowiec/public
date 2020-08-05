using System;

namespace PonderingProgrammer.GridMath
{
    public static class Integerizer
    {
        public static int ToInt(double value, Rounding rounding = Rounding.ToNearest)
        {
            return rounding switch
            {
                Rounding.ToNearest => Convert.ToInt32(value),
                Rounding.ToCeiling => Convert.ToInt32(Math.Ceiling(value)),
                Rounding.ToFloor => Convert.ToInt32(Math.Floor(value)),
                _ => throw new ArgumentOutOfRangeException(nameof(rounding), rounding, null)
            };
        }
    }
}
