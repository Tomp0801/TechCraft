using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using TechCraft.model;
using System.IO;

namespace TechCraft.data
{
    public class ItemHandler
    {
        public HashSet<Item> Items { get; protected set; }
        public ItemHandler()
        {
            Items = new HashSet<Item>();
        }
        public bool LoadSingleItem(string file)
        {
            Item item;
            try
            {
                string jsonString = File.ReadAllText(file);
                item = JsonSerializer.Deserialize<Item>(jsonString);
            } catch (IOException e)
            {
                return false;
            }

            Items.Add(item);

            return true;
        }

    }
}
