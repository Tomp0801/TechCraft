using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechCraft
{
    public interface IMovableEntity
    {
        public bool Move(Direction dir);
    }
}
