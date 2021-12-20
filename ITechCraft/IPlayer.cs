using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechCraft
{
    public interface IPlayer : IMovableEntity
    {
        public string Name { get; }
        public int Health { get; }
        public int MaxHealth { get; }
        public int Hunger { get; }
        public int MaxHunger { get; }
        public int Thirst { get; }
        public int MaxThirst { get; }

        public IInventory Backpack { get; }
        public void Interact(IItem item, InteractionType type);

    }
}
