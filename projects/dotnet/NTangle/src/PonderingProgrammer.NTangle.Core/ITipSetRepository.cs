using System.Collections.Generic;

namespace PonderingProgrammer.NTangle.Core
{
    public interface ITipSetRepository
    {
        IEnumerable<TipSet> FetchTipSets();
        void Save(TipSet tipSet);
    }
}