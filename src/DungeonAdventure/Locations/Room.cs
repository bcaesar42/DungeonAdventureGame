using DungeonAdventure.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAdventure.Locations
{
    public abstract class Room
    {
        public bool NorthDoorIsOpen { get; set; } = true;
        public bool EastDoorIsOpen { get; set; } = true;
        public bool SouthDoorIsOpen { get; set; } = true;
        public bool WestDoorIsOpen { get; set; } = true;
        public bool WasVisited { get; set; }

        abstract public string GetContents();
        abstract public void PerformRoomActions(Player player);
    }
}
