using ITechCraft;
using System;
using TechCraft.model;

namespace TechCraft.cli
{
    public static class TestProgram
    {
        public static Game Test()
        {
            Item griff = new("Holzgriff", 0.05f, Material.WOOD);
            Item klinge = new("Klinge", 0.1f, Material.METAL);
            Item messer = new("Messer", new Item[] { griff, klinge });

            Player dennis = new("Dennis");
            Game game = new(dennis);

            game.World.PlaceItem(messer, 0, 4);
            return game;
        }
    }
}
