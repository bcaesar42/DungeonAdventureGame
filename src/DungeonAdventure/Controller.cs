﻿using DungeonAdventure.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Threading;

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
            Logs?.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                ListBoxItem newEntry = new ListBoxItem();
                newEntry.Content = message;
                newEntry.FontSize = 6;
                Logs?.Items?.Add(newEntry);
                ScrollToLastItem();
            }));
        }

        public static void Log()
        {
            Log("");
        }

        public static void LogList(List<string> list)
        {
            string toReturn = "";

            foreach (string item in list ?? new List<string>())
            {
                toReturn += item;
            }

            Log(toReturn);
        }

        private static void ScrollToLastItem()
        {
            Logs?.ScrollIntoView(Logs.Items[Logs.Items.Count - 1]);
        }

        public static string GetInput()
        {
            string[] testValues = { "1", "up", "down", "left", "right" };
            Random rand = new Random();
            return testValues[rand.Next(testValues.Length)];
            //string temp = InputBox.Text;
            //InputBox.Text = "";
            //return temp;
        }

        /*Seperate method that may be changed to allow
          directional input to come from a button, instead of text entry.*/
        internal static string GetDirection()
        {
            return GetInput();
        }
    }
}
