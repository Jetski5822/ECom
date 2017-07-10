using System;
using ECom.Abstractions;
using ECom.InMemoryStore;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ECom.Accounts
{
    public class RegistrationApiController : Controller
    {
        private readonly InMemoryPurchaserDataStore _store;

        public RegistrationApiController(InMemoryPurchaserDataStore store)
        {
            _store = store;
        }

        [HttpPost]
        [Route("/accounts")]
        [SwaggerOperation("Create Account")]
        [SwaggerResponse(201, type: typeof(User))]
        [SwaggerResponse(400, type: typeof(UserError))]
        public JsonResult Create([FromBody]User body)
        {
            body.Id = Guid.NewGuid();
            body.ClientId = "CLIENTID";
            body.ClientSecret = "CLIENTSECRET";
            _store.Users.Add(body);

            return Json(body);
        }

        [HttpDelete]
        [Route("/accounts/{accountId}")]
        [SwaggerOperation("Delete Account")]
        [SwaggerResponse(204)]
        public IActionResult Delete(Guid accountId)
        {
            _store.Users.RemoveAll(x => x.Id == accountId);

            return NoContent();
        }
    }
}
