using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCraft.model
{
    public class Material
    {
        public string Name { get; }
        public float Hardness { get; }
        public float Density { get; }
        public float BurnVal { get; }

        public static readonly Material METAL = new Material("Metal", 0.8f, 0.9f, 0.0f);
        public static readonly Material PLASTIC = new Material("Plastic", 0.3f, 0.2f, 0.4f);
        public static readonly Material WOOD = new Material("Wood", 0.7f, 0.5f, 0.85f);
        public static readonly Material STONE = new Material("Stone", 1.0f, 0.95f, 0.0f);

        public Material(string name, float hardness, float density, float burnVal)
        {
            this.Name = name;
            Hardness = hardness;
            Density = density;
            BurnVal = burnVal;

        }

    }
}
