using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITechCraft;

namespace TechCraft.model
{
    public class Player : MovableEntity, IPlayer
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int MaxHealth { get; protected set; } = 100;

        public int Hunger { get; protected set; }
        public int MaxHunger { get; protected set; } = 100;
        public int Thirst { get; protected set; }
        public int MaxThirst { get; protected set; } = 100;

        protected int myTicks = 0;
        protected const int TICK_PERIOD = 10;

        public IInventory Backpack { get; protected set; }

        public Player(string name)
        {
            Name = name;
            Health = MaxHealth;
            Hunger = MaxHunger;
            Thirst = MaxThirst;
            Backpack = new Inventory(100);
        }

        public void Interact(IItem item, InteractionType type)
        {
            IItem[] retItems = item.Interact(type);
            Backpack.Remove(item);
            foreach (Item it in retItems)
                Backpack.StoreItem(it);
        }
        public override void Update(int ticks) {
            myTicks += ticks;
            if (myTicks >= TICK_PERIOD)
            {
                // update stati
                if (Hunger > 0) Hunger -= 1;
                if (Thirst > 0) Thirst -= 1;
                // more health, if full hunger
                if (Hunger == MaxHunger * 0.9 && Health < MaxHealth)
                {
                    Health += 1;
                }
                myTicks -= TICK_PERIOD - 1;
            }
        }

        public override string ToString() 
        {
            string retString = Name + " - Health: " + Health;
            retString += "\nHunger: " + Hunger;
            retString += "\nThirst: " + Thirst;
            retString += "\nInventory: " + Backpack;

            return retString;
        }
    }
}
