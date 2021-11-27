using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCraft.model
{
    class Player
    {
        public string Name { get; }
        public int Health { get; }
        public int MaxHealth { get; } = 100;
        
        public int Hunger { get; }
        public int MaxHunger { get; } = 100;
        public int Thirst { get; }
        public int MaxThirst { get; } = 100;

        public Inventory Backpack { get; }

        public Player(string name)
        {
            Name = name;
            Health = MaxHealth;
            Hunger = MaxHunger;
            Thirst = MaxThirst;
            Backpack = new Inventory(100);
        }

        public void Interact(Item item, InteractionType type)
        {
            Item[] retItems = item.Interact(type);
            Backpack.Remove(item);
            foreach (Item it in retItems)
                Backpack.StoreItem(it);
        }

        public override string ToString() 
        {
            string retString = Name + " - Health: " + Health
                + "\nInventory: " + Backpack;

            return retString;
        }
    }
}
