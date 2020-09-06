namespace PonderingProgrammer.NTangle.Core
{
    public class TipGrouping
    {
        public int TipId { get; set; }
        public Tip Tip { get; set; }
        public int TipSetId { get; set; }
        public TipSet TipSet { get; set; }
    }
}