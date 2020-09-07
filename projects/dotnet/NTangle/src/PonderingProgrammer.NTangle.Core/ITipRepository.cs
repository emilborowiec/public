using System.Collections.Generic;

namespace PonderingProgrammer.NTangle.Core
{
    public interface ITipRepository
    {
        IEnumerable<Tip> FetchTips();
        IEnumerable<TipSet> FetchTipSets();
        IEnumerable<Activity> FetchActivities();
    }
}