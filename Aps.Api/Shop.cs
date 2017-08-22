using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aps.Api
{
    public static class Shop
    {
        public static IEnumerable<Item> GetItems()
        {
            return new List<Item>
            {
                new Item { Id = 0, Name = "Multi-Phase Quantum Resonator", Cost = "70 Smidgen" },
                new Item { Id = 1, Name = "Gwendolyn", Cost = "20 Smidgen" },
                new Item { Id = 2, Name = "Schezwan Sauce", Cost = "SOLD OUT!" }
            };
        }
    }

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cost { get; set; }
    }
}
