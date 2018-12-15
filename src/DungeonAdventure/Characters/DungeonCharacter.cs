using DungeonAdventure.Attacks;
using System;

namespace DungeonAdventure.Characters
{
    public abstract class DungeonCharacter
    {
        public string Name { get; set; }
        public int HitPoints { get; private set; }
        private Attack Weapon;
        public bool StillAlive
        {
            get
            {
                return HitPoints > 0;
            }
        }

        public DungeonCharacter(string name, int hp, Attack weapon)
        {
            Name = name;
            HitPoints = hp;
            Weapon = weapon;
        }

        public void Attack(DungeonCharacter opponent)
        {
            Random rand = new Random();
            bool canAttack = rand.Next(101) <= Weapon.AccuracyPercent;

            if (canAttack)
            {
                Controller.Log(Weapon.GetMessage(this, opponent));
                int damage = Weapon.Strike();
                opponent.TakeDamage(damage);
            }
            else
            {
                Controller.Log($"{Name}'s attack on {opponent.Name} failed!");
            }

            Controller.Log("");
        }

        public virtual void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                Heal(damage);
            }
            else
            {
                HitPoints -= damage;

                if (HitPoints < 0)
                {
                    HitPoints = 0;
                }
                Controller.Log($"{Name} took [{damage}] points of damage.");
                Controller.Log($"{Name} now has [{HitPoints}] hit points remaining.");
                Controller.Log("");
            }

            if (HitPoints <= 0)
            {
                Controller.Log($"{Name} has been killed.");
            }
        }

        public virtual void Heal(int healing)
        {
            if (healing < 0)
            {
                TakeDamage(healing);
            }
            else
            {
                HitPoints += healing;
                Controller.Log($"{Name} was healed for [{healing}] points.");
                Controller.Log($"{Name}'s total hit points remaining are: {HitPoints}");
                Controller.Log("");
            }
        }

        public abstract int ChooseBattleOption();
        public abstract void Heal();

        public void MakeBattleMove(int moveSelection, DungeonCharacter opponent)
        {
            if (moveSelection == 1)
            {
                Attack(opponent);
            }
            else
            {
                Heal();
            }
        }
    }
}