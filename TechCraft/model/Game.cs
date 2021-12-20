using ITechCraft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TechCraft.model
{
    public class Game : IGame
    {
        public Player MainPlayer { get; protected set; }
        IPlayer IGame.MainPlayer { get => MainPlayer; }
        public IMap World { get; protected set; }

        protected int lastUpdate = -1;

        protected Random prng;

        protected bool stop = true;

        protected const int TICK_PERIOD_MS = 100;

        protected Thread gameThread;

        public Game(Player player)
        {
            prng = new Random();
            MainPlayer = player;
            World = new Map(5, 5);

            player.Spawn(World, 2, 2);
        }

        public Game(Player player, int mapSize, int seed)
        {
            prng = new Random(seed);
            MainPlayer = player;
            World = new Map(mapSize, mapSize);
            player.Spawn(World, (uint)prng.Next(mapSize), (uint)prng.Next(mapSize));
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
        public void Update(int ticks)
        {
            MainPlayer.Update(ticks);
        }
        public void Start()
        {
            ThreadStart start = new ThreadStart(run);
            gameThread = new Thread(start);
        }

        protected void run()
        {
            while (!stop)
            {
                Update(1);
                Thread.Sleep(TICK_PERIOD_MS);
            }
        }
    }
}
