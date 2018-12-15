using DungeonAdventure.Attacks;

namespace DungeonAdventure.Monsters
{
    public class Gremlin : Monster
    {
        protected internal Gremlin()
            : base("Gremlin", 300, new Claws())
        { /*Constructor only calls the base constructor.*/ }
    }
}