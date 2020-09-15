using System.Collections.Generic;
using PonderingProgrammer.NTangle.Model;

namespace PonderingProgrammer.NTangle.DataAccess
{
    public interface ITipRepository : IRepository<Tip>
    {
        IEnumerable<Tip> FetchAll();
    }
}