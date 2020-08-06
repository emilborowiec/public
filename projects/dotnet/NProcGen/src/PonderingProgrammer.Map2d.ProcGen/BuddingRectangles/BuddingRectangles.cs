using System;
using System.Collections.Generic;
using System.Linq;
using PonderingProgrammer.GridMath;
using PonderingProgrammer.Map2d.ProcGen.Randoms;
using RandomBoxFactory = PonderingProgrammer.Map2d.ProcGen.Randoms.RandomBoxFactory;

namespace PonderingProgrammer.Map2d.ProcGen.BuddingRectangles
{
    public class BuddingRectangles
    {
        private RandomBoxFactory _randomBoxFactory = new RandomBoxFactory();
        private Random _rand = new Random();
        
        public IMap2d<bool> Generate(BuddingRectanglesGenerationOptions options)
        {
            var map = GenerateFixedMap(options.Width, options.Height);
            var rooms = new List<Room>();
            var roomsToVisit = new List<Room>();

            var box = _randomBoxFactory.RandomSizeBox(options.MinRectSize, options.MaxRectSize);
            box = box.Relate(map.GetBounds(), Relation.CenterToCenter(),
                Relation.CenterToCenter());
            var firstRoom = new Room { Box = box };
            map.SetInBounds(true, firstRoom.Box);
            rooms.Add(firstRoom);
            roomsToVisit.Add(firstRoom);

            while (roomsToVisit.Count > 0)
            {
                var room = roomsToVisit.First();
                box = _randomBoxFactory.RandomSizeBox(options.MinRectSize, options.MaxRectSize);
                foreach (var direction in _rand.ShuffleEnum<Grid4Direction>())
                {
                    if (!room.WallsToRooms.ContainsKey(direction))
                    {
                        box = box.PlaceBeside(room.Box, direction);
                        if (map.FindCellsInBox(box).Any(c => c.Value) || !map.GetBounds().Contains(box))
                        {
                            continue;
                        }

                        // no collision and within map bounds
                        var newRoom = new Room {Box = box};
                        room.WallsToRooms[direction] = newRoom;
                        map.SetInBounds(true, box);
                        rooms.Add(newRoom);
                        roomsToVisit.Add(newRoom);
                    }
                }

                roomsToVisit.Remove(room);
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
