using ITechCraft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCraft.model
{
    public class Item : FieldItem, IItem
    {
        public string Name { get; protected set; }

        protected IItem[] subItems;

        public float Weight { get; protected set; }
        public float Volume { get; protected set; }

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

        public Item(string name, IItem[] subItems)
        {
            Name = name;
            this.subItems = subItems;
            foreach (IItem it in subItems)
            {
                Volume += it.Volume;
                Weight += it.Weight;
            }
        }

        public IItem[] Interact(InteractionType type)
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
