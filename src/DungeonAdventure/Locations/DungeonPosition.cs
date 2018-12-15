using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAdventure.Locations
{
    public class DungeonPosition
    {
        public int X { get; }
        public int Y { get; }

        public DungeonPosition(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
