using System;

namespace PonderingProgrammer.Conjurer.WebApp.Models
{
    public class SpatialProfile
    {
        public bool IsSingleTarget { get; set; } = true;
        public bool CanTargetSelf { get; set; } = false;
        public bool CanTargetEnemy { get; set; } = true;
        public bool CanTargetGround { get; set; } = false;
        public double Range { get; set; } = double.PositiveInfinity;
        public double Radius { get; set; } = double.NaN;
        public double Angle { get; set; } = double.NaN;
        public double Breadth { get; set; } = double.NaN;
        
        public bool IsSelfOnly => double.IsNaN(Range);
        public bool IsCone => Radius > 0 && double.IsFinite(Radius) && 0 < Angle && Angle <= Math.PI;
        public bool IsSphere => Radius > 0 && double.IsFinite(Radius) && double.IsInfinity(Angle);
        public bool IsLine => Radius > 0 && double.IsNaN(Angle);
    }
}