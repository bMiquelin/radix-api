using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RadixAPI.Authorization;
using RadixAPI.Contract;
using RadixAPI.Data;
using RadixAPI.Managers;
using RadixAPI.Model.Entity;

namespace RadixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(StoreAuthorization))]
    public class GatewayRulesController : ControllerBase
    {
        private readonly RadixAPIContext ctx;
        private readonly Guid storeId;
        public GatewayRulesController(RadixAPIContext ctx)
        {
            this.ctx = ctx;
            this.storeId = Guid.Parse(Request.Headers["STORE_ID"]);
        }

        [HttpGet]
        public ActionResult<IEnumerable<StoreGatewayRule>> Get() => ctx.StoreGatewayRule
            .Where(rule => rule.Store.Id == this.storeId)
            .ToArray();
    }
}