using PonderingProgrammer.Map2d;
using System.Collections.Generic;

namespace PonderingProgrammer.Map2dTests
{
    class ConcreteFixedSquareMap2d : FixedSquareMap2d<bool>
    {
        public ConcreteFixedSquareMap2d(int width, int height) : base(width, height)
        {
        }

        public override IEnumerable<Cell<bool>> FindAdjacentCells(int x, int y)
        {
            return null;
        }

        public override CellGraph<bool> ToCellGraph()
        {
            return null;
        }
    }
}
