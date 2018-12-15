using DungeonAdventure.Attacks;

namespace DungeonAdventure.Monsters
{
    public class Skeleton : Monster
    {
        protected internal Skeleton()
            : base("Skeleton", 200, new BoneClub())
        { /*Constructor only calls the base constructor.*/ }
    }
}