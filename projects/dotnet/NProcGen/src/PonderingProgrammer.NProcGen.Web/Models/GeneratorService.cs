using PonderingProgrammer.Map2d;
using PonderingProgrammer.Map2d.ProcGen;

namespace PonderingProgrammer.NProcGen.Web.Models
{
    public class GeneratorService
    {
        private PoppingRectangles _poppingRectangles = new PoppingRectangles();

        public IMap2d<bool> GenerateWithPoppingRectangles(PoppingRectanglesGenerationOptions options)
        {
            return _poppingRectangles.Generate(options);
        }
    }
}
