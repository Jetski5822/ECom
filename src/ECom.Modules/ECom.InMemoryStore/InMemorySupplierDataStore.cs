using System;
using System.Collections.Generic;
using ECom.Abstractions;

namespace ECom.InMemoryStore
{
    public class InMemorySupplierDataStore
    {
        public List<Order> Orders = new List<Order>();

        public List<InventoryItem> Inventory = new List<InventoryItem> {
            new InventoryItem{
                Id = Guid.Parse("05cfcbd2-d654-4d44-ab4f-2fb895d3dbbb"),
                Name = "Some product",
                QuantityInStock = 10
            }
        };
    }
}
