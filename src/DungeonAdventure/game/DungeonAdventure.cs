using DungeonAdventure.Characters;
using DungeonAdventure.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAdventure.Game
{
    public class DungeonAdventure
    {
        public Player Player { get; }
        public Dungeon Map { get; }

        public DungeonAdventure()
        {
            Map = Dungeon.GenerateDungeon();
            Player = new Player(Map);
        }

        public void PlayGame()
        {
            Controller.Log("You are trapped in a dungeon.");
            Controller.Log("In order to escape: You must locate all 4 pillars of OO, then go to/find the exit.");
            Controller.Log("Good Luck! :)");

            while (Player.Character.StillAlive && 
                  (Player.PillarsFound < 4 || Player.CurrentLocation != Map.ExitLocation))
            {
                Player.MakeMove();
            }

            if (Player.Character.StillAlive)
            {
                Controller.Log("YOU WON! :)");
            }
            else
            {
                Controller.Log("Game Over.");
            }

            RevealAllRooms();
        }

        private void RevealAllRooms()
        {
            foreach (Room[] row in Map.Rooms)
            {
                foreach (Room room in row)
                {
                    room.WasVisited = true;
                }
            }
        }
    }
}
