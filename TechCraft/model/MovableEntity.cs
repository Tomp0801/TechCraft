using ITechCraft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCraft.model
{
    public class MovableEntity : FieldItem
    {
        public bool Move(Direction dir)
        {
            bool success = CurrentMap.MoveItem(Pos, dir);
            if (success)
            {
                switch (dir)
                {
                    case Direction.NORTH:
                        Pos.Y--;
                        break;
                    case Direction.SOUTH:
                        Pos.Y++;
                        break;
                    case Direction.WEST:
                        Pos.X--;
                        break;
                    case Direction.EAST:
                        Pos.X++;
                        break;
                }
            }
            return success;
        }
    }
}
