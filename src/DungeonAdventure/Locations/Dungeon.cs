using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAdventure.Locations
{
    public class Dungeon
    {
        const int DUNGEON_HEIGHT = 5;
        const int DUNGEON_WIDTH = 5;

        public Room[][] Rooms { get; }
        public DungeonPosition EntranceLocation { get; private set; }
        public DungeonPosition ExitLocation { get; private set; }
        public List<DungeonPosition> TopRow { get; private set; }
        public List<DungeonPosition> RightColumn { get; private set; }
        public List<DungeonPosition> BottomRow { get; private set; }
        public List<DungeonPosition> LeftColumn { get; private set; }
        public int Width
        {
            get
            {
                return Rooms[0].Length;
            }
        }
        public int Height
        {
            get
            {
                return Rooms.Length;
            }
        }

        private Dungeon()
        {
            Rooms = new Room[DUNGEON_HEIGHT][];
            for (int row = 0; row < Height; row++)
            {
                Rooms[row] = new Room[DUNGEON_WIDTH];
            }

            TopRow = GetRoomPositionsInRow(0);
            RightColumn = GetRoomPositionsInColumn(Width - 1);
            BottomRow = GetRoomPositionsInRow(Height - 1);
            LeftColumn = GetRoomPositionsInColumn(0);
        }

        public static Dungeon GenerateDungeon()
        {
            Dungeon dungeon = new Dungeon();
            dungeon.PlaceEntrance();
            dungeon.PlaceExit();
            dungeon.FillRemainingRooms();
            dungeon.CloseExteriorDoors();
            dungeon.PlacePillars();
            return dungeon;
        }

        private List<DungeonPosition> GetRoomPositionsInRow(int rowNum)
        {
            List<DungeonPosition> roomPositionss = new List<DungeonPosition>();

            for (int x = 0; x < Rooms[rowNum]?.Length; x++)
            {
                roomPositionss.Add(new DungeonPosition(x, rowNum));
            }

            return roomPositionss;
        }

        private List<DungeonPosition> GetRoomPositionsInColumn(int columnNum)
        {
            List<DungeonPosition> roomPositions = new List<DungeonPosition>();

            for (int y = 0; y < Rooms?.Length; y++)
            {
                roomPositions.Add(new DungeonPosition(columnNum, y));
            }

            return roomPositions;
        }

        private void PlaceEntrance()
        {
            DungeonPosition position = GetRandomExteriorPosition();
            EntranceLocation = position;
            Rooms[position.Y][position.X] = new Entrance();
        }

        private void PlaceExit()
        {
            DungeonPosition position = GetRandomExteriorPosition();

            do
            {
                position = GetRandomExteriorPosition();
            } while (position.Equals(EntranceLocation));

            ExitLocation = position;
            Rooms[position.Y][position.X] = new Exit();
        }

        private DungeonPosition GetRandomExteriorPosition()
        {
            Random rand = new Random();
            List<List<DungeonPosition>> exteriorEdges = new List<List<DungeonPosition>>();
            exteriorEdges.Add(TopRow);
            exteriorEdges.Add(RightColumn);
            exteriorEdges.Add(BottomRow);
            exteriorEdges.Add(LeftColumn);

            List<DungeonPosition> randomEdge = exteriorEdges[rand.Next(exteriorEdges.Count)];
            return randomEdge[rand.Next(randomEdge.Count)];
        }

        private void FillRemainingRooms()
        {
            for (int row = 0; row < Height; row++)
            {
                for (int column = 0; column < Width; column++)
                {
                    if (!(Rooms[row][column] is Entrance || Rooms[row][column] is Exit))
                    {
                        Rooms[row][column] = new StandardRoom();
                    }
                }
            }
        }

        private void CloseExteriorDoors()
        {
            foreach (DungeonPosition position in TopRow)
            {
                Rooms[position.Y][position.X].NorthDoorIsOpen = false;
            }

            foreach (DungeonPosition position in RightColumn)
            {
                Rooms[position.Y][position.X].EastDoorIsOpen = false;
            }

            foreach (DungeonPosition position in BottomRow)
            {
                Rooms[position.Y][position.X].SouthDoorIsOpen = false;
            }

            foreach (DungeonPosition position in LeftColumn)
            {
                Rooms[position.Y][position.X].WestDoorIsOpen = false;
            }
        }

        private void PlacePillars()
        {
            Random rand = new Random();
            DungeonPosition position = null;

            for (int pillarsPlaced = 0; pillarsPlaced < 4;)
            {
                position = new DungeonPosition(rand.Next(Width), rand.Next(Height));
                if (Rooms[position.Y][position.X] is StandardRoom)
                {
                    StandardRoom room = (StandardRoom)Rooms[position.Y][position.X];
                    
                    if (!room.HasPillar)
                    {
                        room.HasPillar = true;
                        pillarsPlaced++;
                    }
                }
            }
        }
    }
}
