using System.Collections.Generic;

namespace PonderingProgrammer.NTangle.Core
{
    public class Tip
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TipTypeId { get; set; }
        public TipType TipType { get; set; }
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
        public string Summary { get; set; }
        public string ReferenceUrl { get; set; }
        public List<TipGrouping> Groupings { get; set; }
    }
}