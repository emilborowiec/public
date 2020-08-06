using System.Collections.Generic;
using PonderingProgrammer.GridMath;

namespace PonderingProgrammer.Map2d.ProcGen.BuddingRectangles
{
    public class Rectangle
    {
        private GridBoundingBox box;
        private Dictionary<int, Rectangle> wallToRectangle;
    }
}
