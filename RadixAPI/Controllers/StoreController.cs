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
        public StoreController(RadixAPIContext ctx)
        {
            this.ctx = ctx;
        }
        [HttpGet]
        [ServiceFilter(typeof(StoreAuthorization))]
        public ActionResult<Store> Get()
        {
            var storeId = Guid.Parse(Request.Headers["STORE_ID"]);
            return ctx.Stores
                .Include(store => store.StoreGatewayRules)
                .FirstOrDefault(store => store.Id == storeId);
        }

            
        [HttpPost]
        public object Post([FromBody] NewStoreRequest newStoreRequest)
        {
            var store = new Store {
                AntiFraud = newStoreRequest.AntiFraud,
                API_KEY = Guid.NewGuid(),
                Name = newStoreRequest.Name,
                StoreGatewayRules = newStoreRequest.StoreGatewayRules.Select(sgr => new StoreGatewayRule {
                    Brand = sgr.Brand,
                    Gateway = sgr.Gateway,
                    Priority = sgr.Priority
                }).ToList()
            };
            if (!store.StoreGatewayRules.Any(r => r.Brand == null))
                return new ErrorResult("Need at least one default rule");

            var addedStore = this.ctx.Stores.Add(store).Entity;
            foreach(var rule in store.StoreGatewayRules)
            {
                rule.Store = addedStore;
                this.ctx.StoreGatewayRule.Add(rule);
            }
            this.ctx.SaveChanges();
            return new {
                store_id = store.Id,
                api_key = store.API_KEY
            };
        }
    }
}