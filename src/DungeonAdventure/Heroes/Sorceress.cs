using DungeonAdventure.Attacks;
using DungeonAdventure.Characters;
using System;

namespace DungeonAdventure.Heroes
{
    public class Sorceress : Hero
    {
        private const int HEALING_BONUS_MIN = 10;
        private const int HEALING_BONUS_MAX = 30;

        protected internal Sorceress()
            :base("Sorceress", 200, new Fireball(), 5)
        { /*Constructor only calls the base constructor.*/ }

        override public void Heal(int healing)
        {
            Random rand = new Random();
	        int healingBonus = rand.Next(HEALING_BONUS_MIN, HEALING_BONUS_MAX+1);

            base.Heal(healing + healingBonus);
        }
    }
}