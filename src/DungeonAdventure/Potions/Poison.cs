using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonAdventure.Characters;

namespace DungeonAdventure.Potions
{
    public class Poison : IPotion
    {
        protected internal Poison()
        {/*Empty constructor.*/}

        public void Drink(Player player)
        {
            Controller.Log($"{player.Character.Name} drank some poison.");
            Random rand = new Random();
            player.Character.TakeDamage(rand.Next(5, 15));
        }
    }
}
