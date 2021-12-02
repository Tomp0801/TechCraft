using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCraft.model
{
    public class FieldItem
    {
        public Position Pos { get; private set; }
        public Map CurrentMap { get; private set; }
        public void Spawn(Map map, uint x, uint y)
        {
            Pos = new Position(x, y);
            map.PlaceItem(this, x, y);
            CurrentMap = map;
        }
    }
}
