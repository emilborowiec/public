using System.Linq;
using PonderingProgrammer.GridMath;
using PonderingProgrammer.Map2d.ProcGen.Randoms;

namespace PonderingProgrammer.Map2d.ProcGen.BuddingRectangles
{
    public class PackedRectangles
    {
        private RandomBoxFactory _randomBoxFactory = new RandomBoxFactory();

        public IGridMap Generate(PackedRectanglesGenerationOptions options)
        {
            var map = GenerateFixedMap(options.Width, options.Height);
            
            var rectangles = new GridBoundingBox[options.RectCount];
            for (var i = 0; i < options.RectCount; i++)
            {
                rectangles[i] = _randomBoxFactory.RandomSizeBox(options.MinRectSize, options.MaxRectSize);
            }
            GridBoundingBoxes.Pack(rectangles, BoxAlignment.TOP_LEFT, options.CorridorLength);
            rectangles = rectangles.Where(r => map.GetBounds().Contains(r)).ToArray();
            foreach (var rectangle in rectangles)
            {
                
                map.SetInBounds(true, rectangle);
            }

            return map;
        }

        private ManhattanFixedSquareGridMap<bool> GenerateFixedMap(int width, int height)
        {
            return new ManhattanFixedSquareGridMap<bool>(width, height);
        }
    }
}
