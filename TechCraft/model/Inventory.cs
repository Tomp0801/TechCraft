using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITechCraft;

namespace TechCraft.model
{
    public class Inventory : IInventory
    {
        public int Volume { get; protected set; }

        protected List<IItem> items;

        public float FreeVolume { get; protected set; }

        public Inventory(int volume)
        {
            items = new();
            FreeVolume = volume;
            Volume = 0;
        }

        public IItem GetItem(int index)
        {
            if (index < items.Count)
            {
                return items[index];
            } else
            {
                return null;
            }
        }

        public IItem[] GetAll()
        {
            return items.ToArray();
        }

        public bool StoreItem(IItem item)
        {
            if (FreeVolume > item.Volume)
            {
                items.Add(item);
                FreeVolume -= item.Volume;
                return true;
            } else
            {
                return false;
            }
        }

        public bool Remove(IItem item)
        {
            return items.Remove(item);
        }

        public override string ToString()
        {
            string retString = "";
            foreach (Item it in items)
            {
                retString += it.ToString() + " ";
            }
            return retString;
        }
    }
}
