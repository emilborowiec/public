using System.Collections.Generic;

namespace PonderingProgrammer.Conjurer.WebApp.Models
{
    public interface IEffect
    {
        SpatialProfile SpatialProfile { get; }
        TemporalProfile TemporalProfile { get; }
        double Magnitude { get; }
    }
}