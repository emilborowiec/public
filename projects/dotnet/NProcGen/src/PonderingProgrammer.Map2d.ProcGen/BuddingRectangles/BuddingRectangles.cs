using System;
using PonderingProgrammer.GridMath;

namespace PonderingProgrammer.Map2d.ProcGen.BuddingRectangles
{
    public class BuddingRectangles
    {
        private RandomBoxFactory _randomBoxFactory = new RandomBoxFactory();
        private Random _rand = new Random();
        
        public IMap2d<bool> Generate(BuddingRectanglesGenerationOptions options)
        {
            var map = GenerateFixedMap(options.Width, options.Height);
            
            var firstRoom = _randomBoxFactory.RandomSizeBox(options.MaxRectSize, options.MaxRectSize);
            firstRoom.Relate(map.GetBounds(), Relation.CenterToCenter(),
                Relation.CenterToCenter());
            map.SetInBounds(true, firstRoom);

            var lastRoom = firstRoom;

            for (int i = 0; i < 10; i++)
            {
                var aspectType = Aspect.RatioToType(options.Width / options.Height);
                var preferredAxis = Axis.Horizontal;
                if (options.Width / options.Height < 1) preferredAxis = Axis.Vertical;

                var axis = getAxis(preferredAxis);

                var room = _randomBoxFactory.RandomSizeBox(options.MinRectSize, options.MaxRectSize);
                if (preferredAxis == Axis.Horizontal)
                {
                    room.Relate(lastRoom, Relation.StartToEnd(), Relation.StartToStart());
                    map.SetInBounds(true, room);
                    lastRoom = room;
                }
            }


            return map;
        }

        private Axis getAxis(Axis preferredAxis)
        {
            var notPreferred = preferredAxis == Axis.Horizontal ? Axis.Vertical : Axis.Horizontal;
            return _rand.Chance(0.25) ? notPreferred : preferredAxis;
        }

        private ManhattanFixedSquareMap2d<bool> GenerateFixedMap(int width, int height)
        {
            return new ManhattanFixedSquareMap2d<bool>(width, height);
        }
    }
    
    public enum Axis
    {
        Horizontal,
        Vertical
    }
}
