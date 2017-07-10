using System;
using System.Collections.Generic;
using System.Linq;
using ECom.Abstractions;
using ECom.InMemoryStore;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ECom.Accounts.Contracts
{
    public class ContractsApiController : Controller
    {
        private readonly InMemoryPurchaserDataStore _store;

        public ContractsApiController(InMemoryPurchaserDataStore store)
        {
            _store = store;
        }

        [HttpGet]
        [Route("/accounts/{accountId}/contract")]
        [SwaggerOperation("GetContractForAccount")]
        [SwaggerResponse(200, type: typeof(List<Contract>))]
        [SwaggerResponse(404, type: typeof(List<Contract>))]
        public IActionResult Get([FromRoute]Guid accountId)
        {
            if (!_store.Users.Any(x => x.Id == accountId))
            {
                return NotFound();
            }

            return Json(_store.Users.First(x => x.Id == accountId));
        }

        [HttpGet]
        [Route("/accounts/{accountId}/contract/approve")]
        [SwaggerOperation("Approve Contract on Account")]
        [SwaggerResponse(202, type: typeof(List<Contract>))]
        [SwaggerResponse(404, type: typeof(List<Contract>))]
        public IActionResult Post([FromRoute]Guid accountId)
        {
            return Accepted();
        }
    }
}
