using DungeonAdventure.Characters;
using DungeonAdventure.Monsters;
using DungeonAdventure.Potions;
using DungeonAdventure.Traps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAdventure.Locations
{
    public class StandardRoom : Room
    {
        public bool HasPillar { get; set; }
        private IPotion Potion;
        private ITrap Trap;
        private Monster Enemy;

        public StandardRoom()
        {
            WasVisited = false;
            HasPillar = false;
            Potion = PotionFactory.MakeRandomPotion();
            Trap = TrapFactory.MakeRandomTrap();
            Enemy = MonsterFactory.MakeRandomMonster();
        }

        public override string GetContents()
        {
            string str = "";
            
            if (HasPillar)
            {
                str = AddContentDescription(str, "Pillar of OO");
            }
            if (Potion != null)
            {
                str = AddContentDescription(str, "Potion");
            }
            if (Trap != null)
            {
                str = AddContentDescription(str, "Trap");
            }
            if (Enemy != null)
            {
                str = AddContentDescription(str, "Monster");
            }

            if (string.IsNullOrEmpty(str))
            {
                return "Empty Room";
            }
            else
            {
                return str;
            }
        }

        public override void PerformRoomActions(Player player)
        {
            if (!WasVisited)
            {
                if (HasPillar)
                {
                    player.PillarsFound++;
                }
                if (Trap != null)
                {
                    player.TrapsEncountered++;
                    Trap.ActivateTrap(player.Character);
                }
                if (Enemy != null && player.Character.StillAlive)
                {
                    player.MonstersBattled++;
                    Enemy.Battle(player.Character);
                }
                if (Potion != null && player.Character.StillAlive)
                {
                    player.PotionsFound++;
                    Potion.Drink(player);
                }
            }
        }

        private static string AddContentDescription(string currentString, string toAdd)
        {
            if (string.IsNullOrEmpty(currentString))
            {
                return toAdd;
            }
            else
            {
                return currentString + ", " + toAdd;
            }
        }
    }
}
