using System.Collections.Generic;

namespace PonderingProgrammer.Conjurer.WebApp.Models
{
    public interface IBearer
    {
        int GetCost();
        List<IEffect> GetEffects();
    }
}