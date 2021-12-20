using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechCraft
{
    public class Position
    {
        public uint X { get; set; }
        public uint Y { get; set; }
        public Position(uint x, uint y)
        {
            X = x;
            Y = y;
        }
    }
}
