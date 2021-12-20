using System;
using System.ComponentModel;
using System.Threading;
using ITechCraft;

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
            IGame game = Test();

            game.Start();
            game.MainPlayer.PropertyChanged += onPropertyChanged;

            while (true)
            {
                
                Thread.Sleep(1000);
            }
        }

        static void onPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine(e.PropertyName);
        }
    }
}
