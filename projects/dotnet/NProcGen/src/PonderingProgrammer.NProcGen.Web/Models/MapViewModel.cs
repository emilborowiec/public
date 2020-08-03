using PonderingProgrammer.Map2d.ProcGen;

namespace PonderingProgrammer.NProcGen.Web.Models
{
    public class MapViewModel
    {
        public PoppingRectanglesGenerationOptions Options { get; set; } = new PoppingRectanglesGenerationOptions();
        public string Svg { get; set; }
    }
}
