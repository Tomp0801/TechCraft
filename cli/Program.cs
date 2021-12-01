using System;
using TechCraft.model;

namespace TechCraft.cli
{
    class Program
    {
        static void Main(string[] args)
        {
            Item griff = new Item("Holzgriff", 0.05f, Material.WOOD);
            Item klinge = new Item("Klinge", 0.1f, Material.METAL);
            Item messer = new Item("Messer", new Item[] { griff, klinge });

            Player dennis = new Player("Dennis");
            Game game = new Game(dennis);

            game.World.PlaceItem(messer, 0, 4);

            Console.Clear();
            Console.Write(game.World);
            Console.Write(game.MainPlayer);

            bool exit = false;
            ConsoleKeyInfo keyInfo;
            char key;
            InputAction action;
            while (!exit)
            {
                keyInfo = Console.ReadKey();
                key = (char)keyInfo.Key;
                action = InputAction.NONE;
                switch (key)
                {
                    case 'Q':
                        exit = true;
                        break;
                    case 'W':
                        action = InputAction.MOVE_NORTH;
                        break;
                    case 'A':
                        action = InputAction.MOVE_WEST;
                        break;
                    case 'S':
                        action = InputAction.MOVE_SOUTH;
                        break;
                    case 'D':
                        action = InputAction.MOVE_EAST;
                        break;
                    case 'E':
                        action = InputAction.PICK_UP;
                        break;
                }

                if (action != InputAction.NONE)
                {
                    bool success = game.OnInput(action);
                    Console.Clear();
                    Console.Write(game.World);
                    Console.WriteLine(game.MainPlayer);
                    if (!success)
                        Console.WriteLine("That was not possible");
                }
            }

        }
    }
}
