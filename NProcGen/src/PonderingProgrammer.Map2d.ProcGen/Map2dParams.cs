using System.Collections.Generic;

namespace PonderingProgrammer.Map2d.ProcGen
{
    public class Map2dParams : IGenerationParams
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int DesiredCellCount { get; set; }

        public int Area => Width * Height;

        public virtual IList<string> GetValidationErrors()
        {
            var list = new List<string>();
            if (Width < 2) list.Add("width must be greater than 1");
            if (Height < 2) list.Add("height must be greater than 1");
            if (DesiredCellCount >= Area) list.Add("desiredCellCount cannot be greater than total area");
            return list;
        }
    }
}
