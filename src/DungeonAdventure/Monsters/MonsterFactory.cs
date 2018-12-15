using System;

namespace DungeonAdventure.Monsters
{
    public class MonsterFactory
    {
        const int MONSTER_CHANCE = 15;

        public static Monster MakeRandomMonster()
        {
            Random rand = new Random();

            if (rand.Next(101) <= MONSTER_CHANCE)
            {
                int choice = rand.Next(3);

                if (choice == 0)
                {
                    return new Gremlin();
                }
                else if (choice == 1)
                {
                    return new Ogre();
                }
                else
                {
                    return new Skeleton();
                }
            }
            else
            {
                return null;
            }
        }
    }
}
