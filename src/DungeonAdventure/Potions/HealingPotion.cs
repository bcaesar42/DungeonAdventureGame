using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonAdventure.Characters;

namespace DungeonAdventure.Potions
{
    public class HealingPotion : IPotion
    {
        protected internal HealingPotion()
        {/*Empty constructor.*/}

        public void Drink(Player player)
        {
            Controller.Log($"{player.Character.Name} drank a healing potion.");
            player.Character.Heal();
        }
    }
}
