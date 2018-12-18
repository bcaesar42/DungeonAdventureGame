using System;
using System.Collections.Generic;

namespace DungeonAdventure.Heroes
{
    public class HeroFactory
    {
        public static Hero MakeHero()
        {
            List<string> heroOptions = new List<string>{ "Sorceress", "Thief", "Warrior" };

            string userInput = SelectHeroType(heroOptions);

            return ConstructHero(userInput);
        }

        private static Hero ConstructHero(string type)
        {
            if (type.Equals("Sorceress"))
            {
                return new Sorceress();
            }
            else if (type.Equals("Warrior"))
            {
                return new Warrior();
            }
            else
            {
                return new Thief();
            }
        }

        private static string SelectHeroType(List<string> heroOptions)
        {
            if (heroOptions == null || heroOptions.Count < 1)
            {
                throw new ArgumentException("Null or empty parameter.");
            }

            Controller.Log("Please select which kind of hero do you want to play as:");

            while (true)
            {
                for (int index = 0; index < heroOptions.Count; index++)
                {
                    Controller.Log((index + 1) + ".) " + heroOptions[index]);
                }

                Controller.Log("Enter the number of your selection in the selection box.");

                try
                {
                    int selection = int.Parse(Controller.GetInput());
                    if (selection < 1 || selection > heroOptions.Count)
                    {
                        throw new ArgumentException($"Invalid Input - Number out of range (1-{heroOptions.Count}).");
                    }

                    return heroOptions[selection - 1];
                }
                catch (FormatException)
                {
                    Controller.Log("Invalid Input - Not a number.");
                }
                catch (ArgumentException e)
                {
                    Controller.Log(e.Message);
                }
            }
        }
    }
}
