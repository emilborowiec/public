using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PonderingProgrammer.Map2d.ProcGen.PoppingRectangles
{
    public class PoppingRectanglesGenerationOptions : Map2dGenerationOptions, IValidatableObject
    {
        [Range(1, 1000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int RectCount { get; set; } = 8;

        public int MinRectSize { get; set; } = 4;
        public int MaxRectSize { get; set; } = 12;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (MinRectSize < 1) 
                yield return new ValidationResult("minRectSize must be at least 1", new []{nameof(MinRectSize)});
            if (MaxRectSize > Width/2) 
                yield return new ValidationResult("maxRectSize cannot be greater than area half width", new []{nameof(MaxRectSize)});
            if (MaxRectSize > Height/2) 
                yield return new ValidationResult("maxRectSize cannot be greater than area half height", new []{nameof(MaxRectSize)});
            if (MaxRectSize < MinRectSize) 
                yield return new ValidationResult("maxRectSize cannot be lower than minRectSize", new []{nameof(MaxRectSize)});
        }
    }
}
