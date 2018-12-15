using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DungeonAdventure.Game;

namespace DungeonAdventure
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Controller.Logs = LogBox;
            Controller.InputBox = InputBox;
            Controller.Enter = EnterButton;
            //Game.DungeonAdventure adventure = new Game.DungeonAdventure();
            //Controller.Map = adventure.Map;
            //adventure.PlayGame();
        }

        private void NotifyEnterButtonListeners(object sender, RoutedEventArgs e)
        {
            Controller.Log("Button Pressed");
        }
    }
}
