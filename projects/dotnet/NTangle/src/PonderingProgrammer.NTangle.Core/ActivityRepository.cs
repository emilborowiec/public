using System;
using System.Collections.Generic;
using System.Linq;

namespace PonderingProgrammer.NTangle.Core
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly NTangleContext _context;

        public ActivityRepository(NTangleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Activity Get(int id)
        {
            return _context.Activities.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Activity> FetchActivities()
        {
            return _context.Activities.ToList();
        }

        public void Save(Activity activity)
        {
            _context.Add(activity);
            _context.SaveChanges();
        }
    }
}