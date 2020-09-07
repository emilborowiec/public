using System;
using System.Collections.Generic;
using System.Linq;

namespace PonderingProgrammer.NTangle.Core
{
    public class TipSetRepository : ITipSetRepository
    {
        private readonly NTangleContext _context;

        public TipSetRepository(NTangleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<TipSet> FetchTipSets()
        {
            return _context.TipSets.ToList();
        }

        public void Save(TipSet tipSet)
        {
            _context.Add(tipSet);
            _context.SaveChanges();
        }
    }
}