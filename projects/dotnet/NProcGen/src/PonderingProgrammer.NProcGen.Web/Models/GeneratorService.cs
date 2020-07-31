using PonderingProgrammer.Map2d;
using PonderingProgrammer.Map2d.ProcGen;

namespace PonderingProgrammer.NProcGen.Web.Models
{
    public class GeneratorService
    {
        private PoppingRectangles _poppingRectangles = new PoppingRectangles();
        
        public IMap2d<bool> GenerateSampleMap()
        {
            var options = new PoppingRectanglesParams { Width = 40, Height = 40, RectCount = 8, MinRectSize = 4, MaxRectSize = 8, DesiredCellCount = 400 };
            return _poppingRectangles.Generate(options);
        }
    }
}
