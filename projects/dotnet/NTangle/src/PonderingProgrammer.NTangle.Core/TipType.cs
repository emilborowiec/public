using System.Collections.Generic;

namespace PonderingProgrammer.NTangle.Core
{
    public class TipType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Tip> Tips { get; set; }
    }
}