using System.Collections.Generic;

namespace PonderingProgrammer.NTangle.Core
{
    public interface IActivityRepository
    {
        IEnumerable<Activity> FetchActivities();
        void Save(Activity activity);
    }
}