using System.Collections.Generic;

namespace PonderingProgrammer.Map2d.ProcGen
{
    public interface IGenerationParams
    {
        IList<string> GetValidationErrors();
    }
}
