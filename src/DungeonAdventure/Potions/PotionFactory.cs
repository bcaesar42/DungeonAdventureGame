using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAdventure.Potions
{
    public class PotionFactory
    {
        const int POTION_CHANCE = 10;

        public static IPotion MakeRandomPotion()
        {
            Random rand = new Random();
            if (rand.Next(101) <= POTION_CHANCE)
            {
                int selection = rand.Next(2);

                if (selection == 1)
                {
                    return new Poison();
                }
                else
                {
                    return new HealingPotion();
                }
            }
            else
            {
                return null;
            }
        }
    }
}
