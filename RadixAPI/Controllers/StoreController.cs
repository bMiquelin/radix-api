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
    public class StoreController : ControllerBase
    {
        private readonly RadixAPIContext ctx;
        private readonly Guid storeId;
        public StoreController(RadixAPIContext ctx)
        {
            this.ctx = ctx;
        }
        [HttpGet]
        [ServiceFilter(typeof(StoreAuthorization))]
        public ActionResult<Store> Get()
        {
            var storeId = Guid.Parse(Response.Headers["StoreId"]);
            return ctx.Stores
                .Include(store => store.StoreGatewayRules)
                .FirstOrDefault(store => store.Id == this.storeId);
        }

            
        [HttpPost]
        public void Post([FromBody] Store store)
        {
            this.ctx.Stores.Add(store);
        }
    }
}