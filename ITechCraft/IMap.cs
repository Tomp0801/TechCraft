using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechCraft
{
    public interface IMap
    {
        public IField[,] Fields { get; }
        public int Width { get; }
        public int Height { get; }

        public void PlaceItem(IFieldItem item, uint x, uint y);
        public bool MoveItem(Position pos, Direction dir);
        public bool MoveItem(uint x, uint y, Direction dir);
    }
}
