using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechCraft
{
    public interface IItem : IFieldItem
    {
        public string Name { get; }
        public float Weight { get; }
        public float Volume { get; }
        public IItem[] Interact(InteractionType type);
    }
}
