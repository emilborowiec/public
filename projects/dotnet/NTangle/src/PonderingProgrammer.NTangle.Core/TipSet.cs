using System.Collections.Generic;

namespace PonderingProgrammer.NTangle.Core
{
    public class TipSet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string ReferenceUrl { get; set; }
        public List<TipGrouping> Groupings { get; set; }
    }
}