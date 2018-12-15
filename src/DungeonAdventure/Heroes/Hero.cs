using DungeonAdventure.Attacks;
using DungeonAdventure.Characters;
using System;

namespace DungeonAdventure.Heroes
{
	public abstract class Hero : DungeonCharacter
	{
        public int DodgeChance { get; }

        protected Hero(string name, int health, Attack weapon, int dodgeChance)
                :base(name, health, weapon)
        {
            DodgeChance = dodgeChance;
            Controller.Log("Enter a name for your character.");
            Name = Controller.GetInput();
	    }

		override public void TakeDamage(int damage)
		{
            Random rand = new Random();

			if (rand.Next(101) <= DodgeChance)
			{
				Controller.Log($"{Name} DODGED the attack!");
			}
			else
			{
				base.TakeDamage(damage);
			}
		}

        override public int ChooseBattleOption()
        {
            int selection = 0;

            do
            {
                Controller.Log("Move Options:");
                Controller.Log("1.) Attack Opponent");
                Controller.Log("2.) Heal");
                Controller.Log("Enter the number of your selection in the input box:");

                try
                {
                    string userInput = Controller.GetInput();
                    selection = int.Parse(Controller.GetInput());
                    if (selection < 1 || selection > 2)
                    {
                        throw new ArgumentException("Invalid Input - Number out of range (1-2).");
                    }
                }
                catch (FormatException)
                {
                    Controller.Log("Invalid Input - Not a number.");
                }
                catch (ArgumentException e)
                {
                    Controller.Log(e.Message);
                }
            } while (!(selection == 1 || selection == 2));

            return selection;
        }

        public override void Heal()
        {
            Random rand = new Random();
            base.Heal(rand.Next(20, 50));
        }
    }
}