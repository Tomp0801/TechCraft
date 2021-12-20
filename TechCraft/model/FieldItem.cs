using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITechCraft;

namespace TechCraft.model
{
    public class FieldItem : IFieldItem
    {
        Position IFieldItem.Pos { get; }
        IMap CurrentMap { get; set; }
        IMap IFieldItem.CurrentMap { get => return CurrentMap.get; }

        public void Spawn(IMap map, uint x, uint y)
        {
            Pos = new Position(x, y);
            map.PlaceItem(this, x, y);
            CurrentMap = map;
        }

        void IFieldItem.Spawn(IMap map, uint x, uint y)
        {
            throw new NotImplementedException();
        }
    }
}
