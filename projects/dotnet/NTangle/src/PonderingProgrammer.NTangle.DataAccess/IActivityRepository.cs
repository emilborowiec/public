using System.Collections.Generic;
using PonderingProgrammer.NTangle.Model;

namespace PonderingProgrammer.NTangle.DataAccess
{
    public interface IActivityRepository : IRepository<Activity>
    {
        IEnumerable<Activity> FetchRoots();
        IEnumerable<Activity> FetchAll();
        IEnumerable<Activity> FetchNonDescendantActivities(Activity activity);
    }
}