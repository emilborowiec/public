using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PonderingProgrammer.Map2d.ProcGen
{
    public class PoppingRectanglesParams : Map2dParams
    {
        public int RectCount { get; set; }
        public int MinRectSize { get; set; }
        public int MaxRectSize { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            foreach (var result in base.Validate(validationContext))
            {
                yield return result;
            }
            if (RectCount * MinRectSize >= Area) 
                yield return new ValidationResult("Rectangles won't fit into the area", new []{nameof(RectCount)});
            if (MaxRectSize > Width) 
                yield return new ValidationResult("maxRectSize cannot be greater than area width", new []{nameof(MaxRectSize)});
            if (MaxRectSize > Height) 
                yield return new ValidationResult("maxRectSize cannot be greater than area height", new []{nameof(MaxRectSize)});
            if (MaxRectSize < MinRectSize) 
                yield return new ValidationResult("maxRectSize cannot be lower than minRectSize", new []{nameof(MaxRectSize)});
        }
    }
}
