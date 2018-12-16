using DungeonAdventure.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Threading;
using System.Runtime.CompilerServices;

namespace DungeonAdventure
{
    public static class Controller
    {
        public static ListBox Logs { get; set; } = new ListBox();
        public static Dungeon Map { get; set; }
        public static TextBox InputBox { get; set; } = new TextBox();
        public static Button Enter { get; set; } = new Button();

        public static void Log(string message)
        {
            Logs.Items.Add(message);
            ScrollToLastItem();
        }

        private static void ScrollToLastItem()
        {
            Logs.ScrollIntoView(Logs.Items[Logs.Items.Count - 1]);
        }

        public static string GetInput()
        {
            string temp = InputBox.Text;
            InputBox.Text = "";
            return temp;
        }

        /*Seperate method that may be changed to allow
          directional input to come from a button, instead of text entry.*/
        internal static string GetDirection()
        {
            return GetInput();
        }

        //public static void StartNewGame()
        //{
        //    new Thread(() =>
        //   {
        //       Console.WriteLine("Start of new Thread:");
        //       Game = new Game.DungeonAdventure();
        //       Map = Game.Map;
        //       Game.PlayGame();
        //   }).Start();
        //}
    }
}
