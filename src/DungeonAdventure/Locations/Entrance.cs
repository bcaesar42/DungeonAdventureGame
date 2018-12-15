using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonAdventure;
using DungeonAdventure.Characters;

namespace DungeonAdventure.Locations
{
    public class Entrance : Room
    {
        public override string GetContents()
        {
            return "Entrance";
        }

        public override void PerformRoomActions(Player player)
        {
            Controller.Log("You are at the entrance.");
        }
    }
}
