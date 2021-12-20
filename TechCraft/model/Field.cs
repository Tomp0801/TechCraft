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
        public FieldItem Item { get; set; }
        IFieldItem IField.Item { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Field()
        {
        }
    }
}
