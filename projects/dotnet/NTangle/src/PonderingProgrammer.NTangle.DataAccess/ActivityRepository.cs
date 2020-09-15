using System;
using System.Collections.Generic;
using System.Linq;
using PonderingProgrammer.NTangle.Model;

namespace PonderingProgrammer.NTangle.DataAccess
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly NTangleContext _context;

        public ActivityRepository(NTangleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Activity FindById(int id)
        {
            return _context.Activities.FirstOrDefault(dao => dao.Id == id);
        }

        public void Add(Activity activity)
        {
            _context.Activities.Add(activity);
        }

        public IEnumerable<Activity> FetchAll()
        {
            return _context.Activities;
        }

        public IEnumerable<Activity> FetchRoots()
        {
            return _context.Activities.Where(a => a.Parent == null);
        }

        public IEnumerable<Activity> FetchNonDescendantActivities(Activity activity)
        {
            if (activity == null || activity.Id == 0)
            {
                return _context.Activities;
            }
            
            var roots = FetchRoots();
            var queue = new Queue<Activity>();
            var list = new List<Activity>();
            foreach (var other in roots.Where(a => a.Id != activity.Id))
            {
                queue.Enqueue(other);
            }

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                list.Add(current);
                foreach (var other in current.Children.Where(a => a.Id != activity.Id))
                {
                    queue.Enqueue(other);
                }
            }

            return list;
        }
    }
}