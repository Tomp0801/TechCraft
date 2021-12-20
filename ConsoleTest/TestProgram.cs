﻿using System;
using System.ComponentModel;
using System.Threading;
using ITechCraft;
using TechCraft.data;

namespace TechCraft.cli
{
    public static class TestProgram
    {
        public static IGame Test()
        {
            IItem griff = new TechCraft.model.Item("Holzgriff", 0.05f, Material.WOOD);
            IItem klinge = new TechCraft.model.Item("Klinge", 0.1f, Material.METAL);

            model.Player dennis = new model.Player("Dennis");
            IGame game = new model.Game(dennis);

            return game;
        }

        static void Main(string[] args)
        {
            ItemHandler ih = new ItemHandler();

            ih.LoadItems("griff.json");
            Logger.LogInfo(ih.Items.Count + " items");
            foreach (model.Item it in ih.Items)
            {
                Logger.LogInfo(it.Name);
            }
            
        }

        static void onPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            IPlayer player = (IPlayer)sender;
            //Console.WriteLine(e.PropertyName);
        }
    }
}
