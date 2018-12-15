using DungeonAdventure.Attacks;
using DungeonAdventure.Characters;
using System;

namespace DungeonAdventure.Monsters
{
    public abstract class Monster : DungeonCharacter
    {
        protected Monster(string name, int health, Attack weapon)
            :base(name, health, weapon)
        { /*Constructor only calls the base constructor.*/ }

        override public void Heal()
        {
            Random rand = new Random();
            base.Heal(rand.Next(5, 20));
        }

        // 80% chance to attack, 20% chance to heal.
        override public int ChooseBattleOption()
        {
            Random rand = new Random();
            if (rand.Next(101) <= 20)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        public void Battle(DungeonCharacter opponent)
        {
            Controller.Log($"{opponent.Name} battles {Name}.");
            Controller.Log("---------------------------------------------");

            while (opponent.StillAlive && StillAlive)
            {
                opponent.MakeBattleMove(opponent.ChooseBattleOption(), this);

                if (StillAlive)
                {
                    MakeBattleMove(ChooseBattleOption(), opponent);
                }
            }

            if (StillAlive)
            {
                Controller.Log($"{opponent} was defeated by {Name}.");
            }
            else
            {
                Controller.Log($"{Name} was defeated by {opponent}.");
            }
        }
    }
}