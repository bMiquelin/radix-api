using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class TransactionController : ControllerBase
    {
        private readonly RadixAPIContext ctx;
        private readonly Guid storeId;
        public TransactionController(RadixAPIContext ctx)
        {
            this.ctx = ctx;
            this.storeId = Guid.Parse(Response.Headers["StoreId"]);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Transaction>> Get() => ctx.Transactions
            .Where(tran => tran.Store.Id == this.storeId)
            .ToArray();

        [HttpGet("{id}")]
        public ActionResult<Transaction> Get(Guid id) => ctx.Transactions
            .Where(tran => tran.Store.Id == this.storeId)
            .FirstOrDefault(tran => tran.Id == id);

        [HttpPost]
        public void Post([FromBody] TransactionRequest transactionRequest)
        {
            var store = ctx.Stores.First(s => s.Id == storeId);
            if (store.AntiFraud)
            {
                //TODO
            }
            var gatewayRules = store.StoreGatewayRules.OrderBy(rule => rule.Priority);
            var gateway = GatewayRuleManager.PickGateway(transactionRequest.Brand, gatewayRules);
            //var transactionResult = gateway.MakeTransaction(transactionRequest);
        }
    }
}