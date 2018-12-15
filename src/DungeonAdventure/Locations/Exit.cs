using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonAdventure.Characters;

namespace DungeonAdventure.Locations
{
    public class Exit : Room
    {
        public override string GetContents()
        {
            return "Exit";
        }

        public override void PerformRoomActions(Player player)
        {
            if (player.PillarsFound < 4)
            {
                Controller.Log("You found the exit, but you don't have all 4 pillars yet." +
                        Environment.NewLine + "Please find the remaining pillars, then return here.");
            }
            else
            {
                Controller.Log("You found the exit and have all 4 pillars. Well done!");
            }
        }
    }
}
