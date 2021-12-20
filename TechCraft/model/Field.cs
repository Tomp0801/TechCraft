using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITechCraft;

namespace TechCraft.model
{
    public class Field : IField
    {
        IFieldItem IField.Item { get; set; }
        public Field()
        {
        }
    }
}
