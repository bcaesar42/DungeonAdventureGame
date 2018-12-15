using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonAdventure.Characters;

namespace DungeonAdventure.Traps
{
    public class SpikePit : ITrap
    {
        protected internal SpikePit()
        { /*Empty constructor.*/}

        public void ActivateTrap(DungeonCharacter player)
        {
            Controller.Log($"{player.Name} fell into a spike pit.");
            Random rand = new Random();
            player.TakeDamage(rand.Next(5, 21));
        }
    }
}
