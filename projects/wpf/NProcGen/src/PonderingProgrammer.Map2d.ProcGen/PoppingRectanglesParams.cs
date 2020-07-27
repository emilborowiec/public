using System.Collections.Generic;

namespace PonderingProgrammer.Map2d.ProcGen
{
    public class PoppingRectanglesParams : Map2dParams
    {
        public int RectCount { get; set; }
        public int MinRectSize { get; set; }
        public int MaxRectSize { get; set; }

        public override IList<string> GetValidationErrors()
        {
            var list = base.GetValidationErrors();
            if (RectCount * MinRectSize >= Area) list.Add("Rectangles won't fit into the area");
            if (MaxRectSize > Width) list.Add("maxRectSize cannot be greater than area width");
            if (MaxRectSize > Height) list.Add("maxRectSize cannot be greater than area height");
            if (MaxRectSize < MinRectSize) list.Add("maxRectSize cannot be lower than minRectSize");
            return list;
        }
    }
}
