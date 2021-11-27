using System;
using TechCraft.model;

namespace TechCraft
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Item griff = new Item("Holzgriff", 0.05f, Material.WOOD);
            Item klinge = new Item("Klinge", 0.1f, Material.METAL);
            Item messer = new Item("Messer", new Item[] { griff, klinge });

            Player dennis = new Player("Dennis");
            bool success = dennis.Backpack.StoreItem(messer);
            Console.WriteLine(success);

            Console.WriteLine(dennis);

            dennis.Interact(messer, InteractionType.BREAK_DOWN);

            Console.WriteLine(dennis);
        }
    }
}
