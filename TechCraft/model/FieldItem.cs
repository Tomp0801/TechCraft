using ITechCraft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCraft.model
{
    public class FieldItem : Item, IFieldItem
    {
        public Position Pos { get; protected set; }
        public IMap CurrentMap { get; protected set; }

        public void Spawn(IMap map, uint x, uint y)
        {
            Pos = new Position(x, y);
            map.PlaceItem(this, x, y);
            CurrentMap = map;
        }
    }
}
