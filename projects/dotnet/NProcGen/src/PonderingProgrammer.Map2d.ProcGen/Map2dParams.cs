using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PonderingProgrammer.Map2d.ProcGen
{
    public class Map2dParams : IValidatableObject
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int DesiredCellCount { get; set; }

        public int Area => Width * Height;

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Width < 2) 
                yield return new ValidationResult("width must be greater than 1", new []{nameof(Width)});
            if (Height < 2) 
                yield return new ValidationResult("height must be greater than 1", new []{nameof(Height)});
            if (DesiredCellCount >= Area) 
                yield return new ValidationResult("desiredCellCount cannot be greater than total area", new []{nameof(DesiredCellCount)});
        }
    }
}
