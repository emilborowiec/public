using System;
using System.Collections.Generic;
using System.Linq;
using PonderingProgrammer.NTangle.Model;

namespace PonderingProgrammer.NTangle.DataAccess
{
    public class TipRepository : ITipRepository
    {
        private readonly NTangleContext _context;

        public TipRepository(NTangleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Tip FindById(int id)
        {
            return _context.Tips.FirstOrDefault(dao => dao.Id == id);
        }

        public void Add(Tip tip)
        {
            _context.Add(tip);
        }

        public IEnumerable<Tip> FetchAll()
        {
            return _context.Tips;
        }
    }
}