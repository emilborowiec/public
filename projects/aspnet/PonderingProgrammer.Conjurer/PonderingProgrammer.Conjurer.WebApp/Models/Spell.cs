using System.Collections.Generic;

namespace PonderingProgrammer.Conjurer.WebApp.Models
{
    public class Spell : IBearer
    {
        public int GetCost()
        {
            throw new System.NotImplementedException();
        }

        public List<IEffect> GetEffects()
        {
            throw new System.NotImplementedException();
        }
    }
}