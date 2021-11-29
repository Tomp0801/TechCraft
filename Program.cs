using System;
using TechCraft.model;

namespace TechCraft
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Item griff = new("Holzgriff", 0.05f, Material.WOOD);
            Item klinge = new("Klinge", 0.1f, Material.METAL);
            Item messer = new("Messer", new Item[] { griff, klinge });

            Player dennis = new("Dennis");
            bool success = dennis.Backpack.StoreItem(messer);
            Console.WriteLine(success);

            Console.WriteLine(dennis);

            dennis.Interact(messer, InteractionType.BREAK_DOWN);

            Console.WriteLine(dennis);
        }
    }
}
