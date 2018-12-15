using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonAdventure.Characters;

namespace DungeonAdventure.Traps
{
    public class BearTrap : ITrap
    {
        protected internal BearTrap()
        { /*Empty constructor.*/}

        public void ActivateTrap(DungeonCharacter player)
        {
            Controller.Log($"{player.Name} walked into a bear trap.");
            Random rand = new Random();
            player.TakeDamage(rand.Next(15) + 1);
        }
    }
}
