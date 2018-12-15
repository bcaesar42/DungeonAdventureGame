using DungeonAdventure.Characters;
using System;

namespace DungeonAdventure.Attacks
{
    public abstract class Attack
    {
        public string Description { get; }
        public int MinDamage { get; }
        public int MaxDamage { get; }
        public int AccuracyPercent { get; }

        protected Attack(string description, int min, int max, int hitChance)
        {
            Description = description;

            if (max < min)
            {
                max = min;
            }
            if (hitChance < 1)
            {
                hitChance = 1;
            }

            MaxDamage = max;
            MinDamage = min;
            AccuracyPercent = hitChance;
        }

        public string GetMessage(DungeonCharacter attacker, DungeonCharacter target)
        {
            return $"{attacker.Name} attacks {target.Name} using {Description}.";
        }

        public int Strike()
        {
            Random rand = new Random();
            return rand.Next((MaxDamage - MinDamage)+1) + MinDamage;
        }
    }
}
