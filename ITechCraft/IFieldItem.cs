using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechCraft
{
    public interface IFieldItem : IItem
    {
        public Position Pos { get; }
        public IMap CurrentMap { get; }
        public void Spawn(IMap map, uint x, uint y);
    }
}
