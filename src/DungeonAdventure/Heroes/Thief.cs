using DungeonAdventure.Attacks;

namespace DungeonAdventure.Heroes
{
    public class Thief : Hero
    {
        protected internal Thief()
            : base("Thief", 200, new Daggers(), 20)
        { /*Constructor only calls the base constructor.*/ }
    }
}