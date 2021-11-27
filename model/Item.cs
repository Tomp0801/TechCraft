using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCraft.model
{
    class Item
    {
        public string Name { get; }

        protected Item[] subItems;

        public float Weight { get; }
        public float Volume { get; }
        protected Material material;
        
        public Item()
        {

        }

        public Item(string name, float volume, Material material)
        {
            this.Name = name;
            this.Volume = volume;
            Weight = volume * material.Density;
            this.material = material;
        }

        public Item(string name, Item[] subItems)
        {
            Name = name;
            this.subItems = subItems;
            foreach (Item it in subItems)
            {
                Volume += it.Volume;
                Weight += it.Weight;
            }
        }

        public Item[] Interact(InteractionType type)
        {
            Item[] retItems;
            switch (type)
            {
                case InteractionType.BREAK_DOWN:
                    return subItems;
                default:
                    retItems = new Item[1];
                    retItems[0] = this;
                    return retItems;
            }
            
        }

        public override string ToString() 
        {
            return Name;
        }
    }
}
