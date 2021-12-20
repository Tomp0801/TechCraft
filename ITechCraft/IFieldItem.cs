using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechCraft
{
    interface IFieldItem
    {
        public Position Pos { get; protected set; }
        public IMap CurrentMap { get; protected set; }
        public void Spawn(IMap map, uint x, uint y);
    }
}
