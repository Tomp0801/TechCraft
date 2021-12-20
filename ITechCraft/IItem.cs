using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechCraft
{
    public interface IItem
    {
        public string Name { get; protected set; }
        public float Weight { get; protected set; }
        public float Volume { get; protected set; }
        public IItem[] Interact(InteractionType type);
    }
}
