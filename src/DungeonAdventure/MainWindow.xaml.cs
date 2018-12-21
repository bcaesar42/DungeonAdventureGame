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
            DataContext = this;
            this.ContentRendered += OnLoad_IntializeControllerThenStartGame;
            InitializeComponent();
        }

        private void OnLoad_IntializeControllerThenStartGame(object sender, System.EventArgs e)
        {
            Controller.Logs = LogBox;
            Controller.InputBox = InputBox;
            Controller.Enter = EnterButton;
            Thread GameThread = new Thread(StartNewGame);
            GameThread.Name = "GameThread";
            GameThread.Start();
        }

        private void StartNewGame()
        {
            Game.DungeonAdventure Adventure = new Game.DungeonAdventure();
            Controller.Map = Adventure.Map;
            Adventure.PlayGame();
        }

        private void NotifyEnterButtonListeners(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            Controller.Log($"Button Pressed: {random.Next(1, 1001)}");
        }
    }
}
