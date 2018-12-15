using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAdventure.Traps
{
    public class TrapFactory
    {
        private const int TRAP_CHANCE = 10;

        public static ITrap MakeRandomTrap()
        {
            Random rand = new Random();

            if (rand.Next(101) <= TRAP_CHANCE)
            {
                int selection = rand.Next(3);

                if (selection == 0)
                {
                    return new BearTrap();
                }
                else if (selection == 1)
                {
                    return new PoisonDartTrap();
                }
                else
                {
                    return new SpikePit();
                }
            }
            else
            {
                return null;
            }
        }
    }
}
