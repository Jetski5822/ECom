using System.Collections.Generic;
using ECom.Abstractions;

namespace ECom.InMemoryStore
{
    public class InMemorySupplierDataStore
    {
        public List<Order> Orders = new List<Order>();

        public List<InventoryItem> Inventory = new List<InventoryItem>();
    }
}
