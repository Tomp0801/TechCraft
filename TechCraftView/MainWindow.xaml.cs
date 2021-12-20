﻿using ITechCraft;
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

        private void Refresh()
        {
            center.Children.Add(map);
            map.SetPlayer(game.MainPlayer.Pos.X, game.MainPlayer.Pos.Y, game.MainPlayer);
            map.Refresh();
        }

        public void InitPlayerData(IPlayer player)
        {
            var playerNameBinding = new Binding()
            {
                Source = player.Name
            };
            playerName.SetBinding(TextBlock.TextProperty, playerNameBinding);
            var playerHealthBinding = new Binding()
            {
                Source = player.Health
            };
            playerHealth.SetBinding(TextBlock.TextProperty, playerHealthBinding);
            var playerMaxHealthBinding = new Binding()
            {
                Source = player.MaxHealth
            };
            playerHealthMax.SetBinding(TextBlock.TextProperty, playerMaxHealthBinding);
            var playerHungerBinding = new Binding("Hunger")
            {
                Source = player
            };
            playerHunger.SetBinding(TextBlock.TextProperty, playerHungerBinding);
            var playerMaxHungerBinding = new Binding()
            {
                Source = player.MaxHunger
            };
            playerHungerMax.SetBinding(TextBlock.TextProperty, playerMaxHungerBinding);
            var playerThirstBinding = new Binding()
            {
                Source = player.Thirst
            };
            playerThirst.SetBinding(TextBlock.TextProperty, playerThirstBinding);
            var playerMaxThirstBinding = new Binding()
            {
                Source = player.MaxThirst
            };
            playerThirstMax.SetBinding(TextBlock.TextProperty, playerMaxThirstBinding);
        }

        public void StartGame()
        {
            game = Factory.Factory.GetGame();
            map = new(game.World);
            InitPlayerData(game.MainPlayer);
            Refresh();
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
                case Key.E:
                    // consume item if one exist on player field
                    ConsumeItem();
                    break;
                default:
                    break;
            }
            MovePlayer(game.MainPlayer, xOld, yOld);
        }
    
        private void ConsumeItem()
        {
            IFieldItem item = game.World.Fields[game.MainPlayer.Pos.X, game.MainPlayer.Pos.Y].Item;
            if (item != null)
            {
                item.Interact(InteractionType.CONSUME);
                Refresh();
            }
            else
            {
                Console.WriteLine("Hier ist nichts du Trottel !!!!");
            }
        }
    }
}
