namespace PonderingProgrammer.Conjurer.WebApp.Models
{
    public class TemporalProfile
    {
        public double Duration { get; set; } = double.NaN;
        public double Delay { get; set; } = double.NaN;
        public double Tick { get; set; } = double.NaN;

        public bool IsPermanent => double.IsInfinity(Duration);
        public bool IsInstantaneous => !double.IsNaN(Duration);
        public bool IsDelayed => !double.IsNaN(Delay);
        public bool IsOverTime => !double.IsNaN(Tick) && Tick < Duration;
    }
}