using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonAdventure.Characters;

namespace DungeonAdventure.Traps
{
    public class PoisonDartTrap : ITrap
    {
        protected internal PoisonDartTrap()
        { /*Empty constructor.*/}

        public void ActivateTrap(DungeonCharacter player)
        {
            Controller.Log($"{player.Name} got hit by a poison dart trap.");
            Random rand = new Random();
            player.TakeDamage(rand.Next(15, 35));
        }
    }
}
