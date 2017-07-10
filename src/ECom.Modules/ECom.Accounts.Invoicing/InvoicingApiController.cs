using System;
using ECom.Abstractions;
using ECom.InMemoryStore;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ECom.Accounts.Invoicing
{
    public class InvoicingApiController : Controller
    {
        private readonly InMemoryPurchaserDataStore _store;

        public InvoicingApiController(InMemoryPurchaserDataStore store)
        {
            _store = store;
        }

        [HttpPost]
        [Route("/invoices")]
        [SwaggerOperation("CreateInvoice")]
        [SwaggerResponse(201, type: typeof(Invoice))]
        public IActionResult Create([FromBody]Invoice body)
        {
            return Ok();
        }

        [HttpPost]
        [Route("/invoices/{invoiceId}/payment")]
        [SwaggerOperation("CreateInvoicePayment")]
        [SwaggerResponse(200, type: typeof(Payment))]
        public IActionResult CreatePayment([FromRoute]Guid invoiceId, [FromBody]Payment body)
        {
            return Ok();
        }
    }
}
