using System;
using System.Collections.Generic;
using System.Linq;

namespace PonderingProgrammer.NTangle.Core
{
    public class TipRepository : ITipRepository
    {
        private readonly NTangleContext _context;

        public TipRepository(NTangleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Tip> FetchTips()
        {
            return _context.Tips.ToList();
        }

        public IEnumerable<TipSet> FetchTipSets()
        {
            return _context.TipSets.ToList();
        }

        public IEnumerable<Activity> FetchActivities()
        {
            return _context.Activities.ToList();
        }
    }
}