using DungeonAdventure.Characters;

namespace DungeonAdventure.Traps
{
    public interface ITrap
    {
        void ActivateTrap(DungeonCharacter player);
    }
}
