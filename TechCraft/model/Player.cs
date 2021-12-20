using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITechCraft;

namespace TechCraft.model
{
    public class Player : MovableEntity
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int MaxHealth { get; protected set; } = 100;
        
        public int Hunger { get; protected set; }
        public int MaxHunger { get; protected set; } = 100;
        public int Thirst { get; protected set; }
        public int MaxThirst { get; protected set; } = 100;

        public Inventory Backpack { get; protected set; }

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
