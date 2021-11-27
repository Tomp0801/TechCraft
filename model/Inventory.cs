using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCraft.model
{
    class Inventory
    {
        public int Volume { get; }

        protected List<Item> items;

        public float FreeVolume;

        public Inventory(int volume)
        {
            items = new();
            FreeVolume = volume;
            Volume = 0;
        }

        public Item GetItem(int index)
        {
            if (index < items.Count)
            {
                return items[index];
            } else
            {
                return null;
            }
        }

        public Item[] GetAll()
        {
            return items.ToArray();
        }

        public bool StoreItem(Item item)
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

        public bool Remove(Item item)
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
