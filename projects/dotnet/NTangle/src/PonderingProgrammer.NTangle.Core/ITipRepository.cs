using System.Collections.Generic;

namespace PonderingProgrammer.NTangle.Core
{
    public interface ITipRepository
    {
        IEnumerable<Tip> FetchTips();
        void Save(Tip tip);
    }
}