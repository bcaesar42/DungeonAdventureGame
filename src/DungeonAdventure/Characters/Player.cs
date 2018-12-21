using DungeonAdventure.Heroes;
using DungeonAdventure.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAdventure.Characters
{
    public class Player
    {
        public int PillarsFound { get; set; }
        public int PotionsFound { get; set; }
        public int MonstersBattled { get; set; }
        public int TrapsEncountered { get; set; }
        public Hero Character { get; }
        public DungeonPosition CurrentLocation { get; private set; }
        private Dungeon Dungeon;
        public bool CanMoveUp
        {
            get
            {
                return CurrentLocation.Y < (Dungeon.Rooms.Length - 1);
            }
        }
        public bool CanMoveRight
        {
            get
            {
                return CurrentLocation.X < (Dungeon.Rooms[CurrentLocation.Y].Length - 1);
            }
        }
        public bool CanMoveDown
        {
            get
            {
                return CurrentLocation.Y > 0;
            }
        }
        public bool CanMoveLeft
        {
            get
            {
                return CurrentLocation.X > 0;
            }
        }

        public Player(Dungeon dungeon)
        {
            Dungeon = dungeon;
            CurrentLocation = Dungeon.EntranceLocation;
            PillarsFound = 0;
            PotionsFound = 0;
            MonstersBattled = 0;
            TrapsEncountered = 0;
            Character = HeroFactory.MakeHero();
        }

        private List<string> ListValidMoves()
        {
            List<string> validMoves = new List<string>();

            if (CanMoveUp)
            {
                validMoves.Add("up");
            }
            if (CanMoveDown)
            {
                validMoves.Add("down");
            }
            if (CanMoveLeft)
            {
                validMoves.Add("left");
            }
            if (CanMoveRight)
            {
                validMoves.Add("right");
            }

            if (validMoves.Count < 1)
            {
                validMoves.Add("You can't move. That's not supposed to happen.");
            }

            return validMoves;
        }

        private string GetDirectionFromUser()
        {
            List<string> validMoves = ListValidMoves();
            string direction = null;

            do
            {
                Controller.Log("Which direction do you want to move?");
                Controller.Log($"Valid Options: {string.Join(", " , validMoves)}.");
                direction = Controller.GetDirection()?.ToLower();
            } while (string.IsNullOrEmpty(direction) || !validMoves.Contains(direction));

            return direction;
        }

        private void Move(string direction)
        {
            if (string.IsNullOrEmpty(direction))
            {
                throw new ArgumentException("Direction cannot be null of empty.");
            }

            if (direction.Equals("up"))
            {
                CurrentLocation = new DungeonPosition(CurrentLocation.X, CurrentLocation.Y + 1);
            }
            else if (direction.Equals("down"))
            {
                CurrentLocation = new DungeonPosition(CurrentLocation.X, CurrentLocation.Y - 1);
            }
            else if (direction.Equals("left"))
            {
                CurrentLocation = new DungeonPosition(CurrentLocation.X - 1, CurrentLocation.Y);
            }
            else if (direction.Equals("right"))
            {
                CurrentLocation = new DungeonPosition(CurrentLocation.X + 1, CurrentLocation.Y);
            }
            else
            {
                throw new ArgumentException("The string that was passed-in is not a direction.");
            }
        }

        public void MakeMove()
        {
            string movementDirection = GetDirectionFromUser();
            Move(movementDirection);

            Room newLocation = Dungeon?.Rooms[CurrentLocation.Y][CurrentLocation.X];

            newLocation?.PerformRoomActions(this);
            newLocation.WasVisited = true;
        }
    }
}
