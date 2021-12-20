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
        public List<Item> Items { get; protected set; }
        public ItemHandler()
        {
            Items = new List<Item>();
        }
        public bool LoadSingleItem(string file)
        {
            Item item;
            try
            {
                string jsonString = File.ReadAllText(file);
                JsonSerializerOptions options = new JsonSerializerOptions(JsonSerializerDefaults.General);
                item = JsonSerializer.Deserialize<Item>(jsonString, options);
            } catch (IOException e)
            {
                Logger.LogError(e.Message);
                return false;
            }

            Items.Add(item);

            return true;
        }

        public static bool StoreSingleItem(Item item, string file)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize<Item>(item);
                File.WriteAllText(file, jsonString);
            }
            catch (IOException e)
            {
                Logger.LogError(e.Message);
                return false;
            }
            return true;
        }
             
    }
}
