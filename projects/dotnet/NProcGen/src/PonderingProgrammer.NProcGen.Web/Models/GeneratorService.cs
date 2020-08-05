using PonderingProgrammer.Map2d;
using PonderingProgrammer.Map2d.ProcGen;
using PonderingProgrammer.Map2d.ProcGen.BuddingRectangles;
using PonderingProgrammer.Map2d.ProcGen.PoppingRectangles;

namespace PonderingProgrammer.NProcGen.Web.Models
{
    public class GeneratorService
    {
        private PoppingRectangles _poppingRectangles = new PoppingRectangles();
        private BuddingRectangles _buddingRectangles = new BuddingRectangles();

        public IMap2d<bool> GenerateWithPoppingRectangles(PoppingRectanglesGenerationOptions options)
        {
            return _poppingRectangles.Generate(options);
        }

        public IMap2d<bool> GenerateWithBuddingRectangles(BuddingRectanglesGenerationOptions options)
        {
            return _buddingRectangles.Generate(options);
        }
    }
}
