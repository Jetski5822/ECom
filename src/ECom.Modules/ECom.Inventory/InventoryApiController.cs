using System;
using System.Collections.Generic;
using System.Linq;
using ECom.Abstractions;
using ECom.InMemoryStore;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ECom.Inventory
{
    public class InventoryApiController : Controller
    {
        private readonly InMemorySupplierDataStore _store;

        public InventoryApiController(InMemorySupplierDataStore store)
        {
            _store = store;
        }

        [HttpGet]
        [Route("/inventory")]
        [SwaggerOperation("GetInventory")]
        [SwaggerResponse(200, type: typeof(List<InventoryItem>))]
        public IActionResult Get()
        {
            return Json(_store.Inventory);
        }

        [HttpGet]
        [Route("/inventory/{inventoryItemId}")]
        [SwaggerOperation("GetInventoryById")]
        [SwaggerResponse(200, type: typeof(InventoryItem))]
        [SwaggerResponse(404)]
        public virtual IActionResult Get([FromRoute]Guid inventoryItemId)
        {
            if (!_store.Inventory.Any(x => x.Id == inventoryItemId))
            {
                return NotFound();
            }

            return Json(_store.Inventory.First(i => i.Id == inventoryItemId));
        }
    }
}
