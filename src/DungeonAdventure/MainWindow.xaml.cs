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
        public Game.DungeonAdventure Adventure { get; private set; }

        public MainWindow()
        {
            this.DataContext = this;
            Controller.Logs = LogBox;
            Controller.InputBox = InputBox;
            Controller.Enter = EnterButton;
            Loaded += OnLoaded_StartNewGame;
            InitializeComponent();
        }

        private void OnLoaded_StartNewGame(object sender, System.EventArgs e)
        {
            Adventure = new Game.DungeonAdventure();
            Controller.Map = Adventure.Map;
            Adventure.PlayGame();
        }

        private void NotifyEnterButtonListeners(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            Controller.Log($"Button Pressed: {random.Next(1, 1001)}");
            //Controller.Log("Button Pressed");
        }
    }
}
