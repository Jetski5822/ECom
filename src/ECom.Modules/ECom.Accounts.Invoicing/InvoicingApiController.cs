using System;
using System.Collections.Generic;
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
        [Route("/accounts/{accountId}/invoices")]
        [SwaggerOperation("CreateInvoice")]
        [SwaggerResponse(202, type: typeof(Invoice))]
        public IActionResult Create([FromRoute]Guid accountId, [FromBody]Invoice body)
        {
            return Ok();
        }

        [HttpPost]
        [Route("/accounts/{accountId}/invoices/{invoiceId}")]
        [SwaggerOperation("CreateInvoicePayment")]
        [SwaggerResponse(200, type: typeof(Invoice))]
        public IActionResult Create([FromRoute]Guid accountId, [FromRoute]Guid invoiceId, [FromBody]Payment body)
        {
            return Ok();
        }

        [HttpGet]
        [Route("/accounts/{accountId}/invoices")]
        [SwaggerOperation("GetInvoices")]
        [SwaggerResponse(200, type: typeof(List<Invoice>))]
        public IActionResult Get([FromRoute]Guid accountId)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("/accounts/{accountId}/invoices/{invoiceId}")]
        [SwaggerOperation("DeleteInvoice")]
        public IActionResult Delete([FromRoute]Guid accountId,[FromRoute]Guid invoiceId)
        {
            return NoContent();
        }
    }
}
