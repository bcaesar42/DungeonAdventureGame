using DungeonAdventure.Attacks;

namespace DungeonAdventure.Monsters
{
    public class Ogre : Monster
    {
        protected internal Ogre()
            : base("Ogre", 200, new GiantAxe())
        { /*Constructor only calls the base constructor.*/ }
    }
}