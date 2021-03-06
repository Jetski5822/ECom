﻿using System;
using System.Linq;
using ECom.Abstractions;
using ECom.InMemoryStore;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ECom.Orders
{
    public class OrdersApiController : Controller
    {
        private readonly InMemorySupplierDataStore _store;

        public OrdersApiController(InMemorySupplierDataStore store)
        {
            _store = store;
        }

        [HttpPost]
        [Route("/orders")]
        [SwaggerOperation("CreateOrder")]
        [SwaggerResponse(201, type: typeof(Order))]
        [SwaggerResponse(400, type: typeof(OrderError))]
        [IgnoreAntiforgeryToken]
        public JsonResult Create(Order body)
        {
            OrderError errors = new OrderError();
            foreach (var line in body.Lines)
            {
                var item = _store.Inventory.FirstOrDefault(i => i.Id == line.Id);
                if (item == null)
                {
                    errors.Lines.Add(new OrderErrorLine
                    {
                        InventoryItemId = line.Id,
                        Error = $"Inventory Item does not exist."
                    });
                }
                else if (item.QuantityInStock < line.Quantity)
                {
                    errors.Lines.Add(new OrderErrorLine
                    {
                        InventoryItemId = line.Id,
                        Error = $"Not enough in stock."
                    });
                }
            }

            if (errors.Lines.Any())
            {
                var response = Json(errors);
                response.StatusCode = 400;
                return response;
            }

            body.Id = Guid.NewGuid();
            body.Status = OrderStatus.Placed;
            body.Complete = false;
            _store.Orders.Add(body);

            return Json(body);
        }

        [HttpPatch]
        [Route("/orders/{orderId}")]
        [SwaggerOperation("UpdateOrder")]
        [SwaggerResponse(200, type: typeof(Order))]
        [SwaggerResponse(404)]
        public IActionResult Update([FromRoute]Guid orderId, [FromBody]Order body)
        {
            if (!_store.Orders.Any(x => x.Id == orderId))
            {
                return NotFound();
            }

            var order = _store.Orders.First(x => x.Id == orderId);
            _store.Orders.Remove(order);
            order.Lines = body.Lines;
            _store.Orders.Add(order);

            return Json(body);
        }

        [HttpGet]
        [Route("/orders/{orderId}")]
        [SwaggerOperation("GetOrderById")]
        [SwaggerResponse(200, type: typeof(Order))]
        [SwaggerResponse(404)]
        public IActionResult Get([FromRoute]Guid orderId)
        {
            if (!_store.Orders.Any(x => x.Id == orderId))
            {
                return NotFound();
            }

            return Json(_store.Orders.First(i => i.Id == orderId));
        }

        [HttpDelete]
        [Route("/orders/{orderId}")]
        [SwaggerOperation("DeleteOrder")]
        [SwaggerResponse(204)]
        public IActionResult Delete(Guid orderId)
        {
            _store.Orders.RemoveAll(x => x.Id == orderId);

            return NoContent();
        }
    }
}
