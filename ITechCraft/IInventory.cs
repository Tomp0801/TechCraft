using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechCraft
{
    public interface IInventory
    {
        public int Volume { get; protected set; }

        public float FreeVolume { get; protected set; }

        public IItem GetItem(int index);

        public IItem[] GetAll();

        public bool StoreItem(IItem item);

        public bool Remove(IItem item);

    }
}
