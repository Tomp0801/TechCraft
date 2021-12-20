using System;
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
            IItem messer = new TechCraft.model.Item("Messer", new IItem[] { griff, klinge });

            model.Player dennis = new model.Player("Dennis");
            IGame game = new model.Game(dennis);

            game.World.PlaceItem(messer, 0, 4);
            return game;
        }

        static void Main(string[] args)
        {
            IGame game = Test();

            game.Start();

            while (true)
            {
                Console.WriteLine(game.MainPlayer);
                Thread.Sleep(1000);
            }
        }
    }
}
