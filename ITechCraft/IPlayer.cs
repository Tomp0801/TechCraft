using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechCraft
{
    interface IPlayer
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int MaxHealth { get; protected set; }
        public int Hunger { get; protected set; }
        public int MaxHunger { get; protected set; }
        public int Thirst { get; protected set; }
        public int MaxThirst { get; protected set; }

        public IInventory Backpack { get; protected set; }
        public void Interact(IItem item, InteractionType type);

    }
}
