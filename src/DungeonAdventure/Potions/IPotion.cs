using DungeonAdventure.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAdventure.Potions
{
    public interface IPotion
    {
        void Drink(Player player);
    }
}
