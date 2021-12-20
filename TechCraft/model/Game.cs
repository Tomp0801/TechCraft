using ITechCraft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCraft.model
{
    public class Game
    {
        public Player MainPlayer { get; }
        public Map World { get; }
        public Game(Player player)
        {
            MainPlayer = player;
            World = new Map(5, 5);

            player.Spawn(World, 2, 2);
        }

        public bool OnInput(InputAction action)
        {
            bool success = false;
            switch (action)
            {
                case InputAction.MOVE_NORTH:
                    success = MainPlayer.Move(Direction.NORTH);
                    break;
                case InputAction.MOVE_SOUTH:
                    success = MainPlayer.Move(Direction.SOUTH);
                    break;
                case InputAction.MOVE_WEST:
                    success = MainPlayer.Move(Direction.WEST);
                    break;
                case InputAction.MOVE_EAST:
                    success = MainPlayer.Move(Direction.EAST);
                    break;
                case InputAction.PICK_UP:
                    success = false;
                    break;
            }
            return success;
        }
    }
}
