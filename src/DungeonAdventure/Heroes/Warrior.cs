using DungeonAdventure.Attacks;

namespace DungeonAdventure.Heroes
{
    public class Warrior : Hero
    {
        protected internal Warrior()
            : base("Warrior", 300, new Sword(), 5)
        { /*Constructor only calls the base constructor.*/ }
    }
}