using ITechCraft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using TechCraft.cli;
using TechCraft.model;
using TechCraftView.view;

namespace TechCraftView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private VMap map;
        private IGame game;

        public MainWindow()
        {
            InitializeComponent();
            StartGame();
        }

        public void LoadPlayerData(IPlayer player)
        {
            var playerNameBinding = new Binding("Name")
            {
                Source = player
            };
            playerName.SetBinding(TextBlock.TextProperty, playerNameBinding);
            var playerHealthBinding = new Binding("Health")
            {
                Source = player
            };
            playerHealth.SetBinding(TextBlock.TextProperty, playerHealthBinding);
            var playerMaxHealthBinding = new Binding("MaxHealth")
            {
                Source = player
            };
            playerHealthMax.SetBinding(TextBlock.TextProperty, playerMaxHealthBinding);
            var playerHungerBinding = new Binding("Hunger")
            {
                Source = player
            };
            playerHunger.SetBinding(TextBlock.TextProperty, playerHungerBinding);
            var playerMaxHungerBinding = new Binding("MaxHunger")
            {
                Source = player
            };
            playerHungerMax.SetBinding(TextBlock.TextProperty, playerMaxHungerBinding);
            var playerThirstBinding = new Binding("Thirst")
            {
                Source = player
            };
            playerThirst.SetBinding(TextBlock.TextProperty, playerThirstBinding);
            var playerMaxThirstBinding = new Binding("MaxThirst")
            {
                Source = player
            };
            playerThirstMax.SetBinding(TextBlock.TextProperty, playerMaxThirstBinding);
        }

        public void StartGame()
        {
            game = Factory.Factory.GetGame();
            map = new(game.World);
            center.Children.Add(map);
            LoadPlayerData(game.MainPlayer);
            map.SetPlayer(game.MainPlayer.Pos.X, game.MainPlayer.Pos.Y, game.MainPlayer);
        }

        private void MovePlayer(IPlayer player, uint xOld, uint yOld)
        {
            map.RemovePlayer(xOld, yOld);
            map.SetPlayer(game.MainPlayer.Pos.X, game.MainPlayer.Pos.Y, game.MainPlayer);
        }

        private void DockPanel_KeyDown(object sender, KeyEventArgs e)
        {
            uint xOld = game.MainPlayer.Pos.X;
            uint yOld = game.MainPlayer.Pos.Y;

            switch (e.Key)
            {
                case Key.W:
                    if (game.MainPlayer.Pos.Y > 0)
                    {
                        game.MainPlayer.Pos.Y -= 1;
                    }
                    break;
                case Key.A:
                    if (game.MainPlayer.Pos.X > 0)
                    {
                        game.MainPlayer.Pos.X -= 1;
                    }
                    break;
                case Key.S:
                    if (game.World.Fields.GetLength(1) > game.MainPlayer.Pos.Y+1)
                    {
                        game.MainPlayer.Pos.Y += 1;
                    }
                    break;
                case Key.D:
                    if (game.World.Fields.GetLength(0) > game.MainPlayer.Pos.X+1)
                    {
                        game.MainPlayer.Pos.X += 1;
                    }
                    break;
                default:
                    break;
            }
            MovePlayer(game.MainPlayer, xOld, yOld);
        }
    }
}
