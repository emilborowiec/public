using System.Collections.Generic;

namespace PonderingProgrammer.NTangle.Core
{
    public interface IActivityRepository
    {
        Activity Get(int id);
        IEnumerable<Activity> FetchActivities();
        void Save(Activity activity);
    }
}